using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using Ninject;
using SoapFormula.Bootstrap;
using SoapFormula.Common.Interface;
using SoapFormula.DAL.Repository.Interface;

namespace SoapFormula.Web.Controllers
{
    public abstract class BaseController<TModel, TViewModel> : Controller where TModel : class, IBase where TViewModel : class 
    {
        private IKernel kernel;
        private IRepository repository;

        protected BaseController()
        {
            this.kernel = Kernel.Initialize();
            this.repository = kernel.Get<IRepository>();
        }

        public virtual ActionResult Index()
        {
            var context = Mapper.Map<IEnumerable<TModel>, IEnumerable<TViewModel>>(repository.Get<TModel>());

            return View(context);
        }

        public virtual ActionResult Details(int id)
        {
             var context = Mapper.Map<TModel, TViewModel>(repository.Get<TModel>(id));

            return View(context);
        }

        public virtual ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public virtual ActionResult Create(TViewModel viewModel)
        {
            var context = Mapper.Map<TViewModel, TModel>(viewModel);
            repository.Add(context);
            repository.Save();

            return View();
        }

        public virtual ActionResult Delete(int id)
        {
            var context = Mapper.Map<TModel, TViewModel>(repository.Get<TModel>(id));

            return View(context);
        }

        [HttpPost]
        public virtual ActionResult Delete(TViewModel viewModel)
        {
            var contextForDeleting = Mapper.Map<TViewModel, TModel>(viewModel);
            var context = repository.Get<TModel>(contextForDeleting.Id);
            repository.Delete(context);
            repository.Save();

            return View();
        }

        public virtual ActionResult Edit(int id)
        {
            var context = Mapper.Map<TModel, TViewModel>(repository.Get<TModel>(id));

            return View(context);
        }

        public virtual ActionResult Edit(TViewModel viewModel)
        {
            var context = Mapper.Map<TViewModel, TModel>(viewModel);
            var contextForEditing = repository.Get<TModel>(context.Id);

            return View();
        }
    }
}