using System.Collections.Generic;
using System.Web.Mvc;
using AutoMapper;
using Ninject;
using SoapFormula.Bootstrap;
using SoapFormula.Common.Entities;
using SoapFormula.Common.Interface;
using SoapFormula.DAL.Repository.Interface;
using SoapFormula.Web.ViewModel.Interface;

namespace SoapFormula.Web.Controllers
{
    public abstract class BaseController<TModel, TViewModel> : Controller
        where TModel : class, IBase, new()
        where TViewModel : class, IBaseViewModel, ISelectListForViewModel, new()
    {
        private IKernel kernel;
        protected IRepository repository;
       
        protected BaseController()
        {
            this.kernel = Kernel.Initialize();
            this.repository = kernel.Get<IRepository>();
        }

        public virtual ActionResult Index()
        {
            var model = Mapper.Map<IEnumerable<TModel>, IEnumerable<TViewModel>>(repository.Get<TModel>());

            return View(model);
        }

        public virtual ActionResult Details(int id)
        {
            var model = Mapper.Map<TModel, TViewModel>(repository.Get<TModel>(id));

            return View(model);
        }

        public virtual ActionResult Create()
        {
            var viewModel = new TViewModel();
            viewModel.Init(repository);
            
            return View(viewModel);
        }

        [HttpPost]
        public virtual ActionResult Create(TViewModel viewModel)
        {
            var model = Mapper.Map<TViewModel, TModel>(viewModel);
            repository.Add(model);
            repository.Save();

            return RedirectToAction("Index");
        }

        public virtual ActionResult Delete(int id)
        {
            var model = Mapper.Map<TModel, TViewModel>(repository.Get<TModel>(id));

            return View(model);
        }

        [HttpPost]
        public virtual ActionResult Delete(TViewModel viewModel)
        {
            var model = repository.Get<TModel>(viewModel.Id);
            repository.Delete(model);
            repository.Save();

            return RedirectToAction("Index");
        }
        
        public virtual ActionResult Edit(int id)
        {
            var model = Mapper.Map<TModel, TViewModel>(repository.Get<TModel>(id));
            model.Init(repository);

            return View(model);
        }

        [HttpPost]
        public virtual ActionResult Edit(TViewModel viewModel)
        {
            var model = repository.Get<TModel>(viewModel.Id);
            Mapper.Map(viewModel, model);
            repository.Save();
            
            return RedirectToAction("Index");
        }
    }
}