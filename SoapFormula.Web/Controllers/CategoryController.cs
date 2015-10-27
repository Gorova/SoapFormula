using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using Ninject;
using SoapFormula.Bootstrap;
using SoapFormula.Common.Entities;
using SoapFormula.DAL.Repository.Interface;
using SoapFormula.Web.ViewModel;

namespace SoapFormula.Web.Controllers
{
    public class CategoryController<T1, T2> : Controller 
                                             where T1 : class 
                                             where T2 : class 
    {
        private IKernel kernel;
        private IRepository repository;

        public CategoryController()
        {
            this.kernel = Kernel.Initialize();
            this.repository = kernel.Get<IRepository>();
        }
       
        public ActionResult Index()
        {
            var context = Mapper.Map<IEnumerable<T1>, IEnumerable<T2>>(repository.Get<T1>());

            return View(context);
        }
        
        public ActionResult Details(int id)
        {
            var context = Mapper.Map<T1, T2>(repository.Get<T1>(id));
            
            return View(context);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(T2 viewModel)
        {
            var context = Mapper.Map<T2,T1>(viewModel);
            repository.Add(context);
            repository.Save();

            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            var context = Mapper.Map<T1, T2>(repository.Get<T>(id));
            
            return View(context);
        }

        [HttpPost]
        public ActionResult Delete(T2 viewModel)
        {
            var context = Mapper.Map<T2, T1>(viewModel);
            repository.Delete(context);
            repository.Save();

            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            var context = Mapper.Map<T1, T2>(repository.Get<T>(id));
            
            return View(context);
        }

        [HttpPost]
        public ActionResult Edit(T2 viewModel)
        {
            var context = Mapper.Map<T2, T1>(viewModel);
            var categoryForEditig = repository.Get<Category>(context.Id);
            categoryForEditig.Name = context.Name;
            repository.Save();
            
            return RedirectToAction("Index");
        }
    }
}