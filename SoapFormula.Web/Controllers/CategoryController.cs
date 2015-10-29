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
    public class CategoryController : BaseController<Category,CategoryViewModel> 
    {
        private IKernel kernel;
        private IRepository repository;

        public CategoryController() : base()
        {
            this.kernel = Kernel.Initialize();
            this.repository = kernel.Get<IRepository>();
        }

        public override ActionResult Index()
        {
            var category = Mapper.Map<IEnumerable<Category>, IEnumerable<CategoryViewModel>>(repository.Get<Category>());

            return View(category);
        }

        public override ActionResult Details(int id)
        {
            var category = Mapper.Map<Category, CategoryViewModel>(repository.Get<Category>(id));

            return View(category);
        }

        public override ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public override ActionResult Create(CategoryViewModel viewModel)
        {
            var category = Mapper.Map<CategoryViewModel, Category>(viewModel);
            repository.Add(category);
            repository.Save();

            return RedirectToAction("Index");
        }

        public override ActionResult Delete(int id)
        {
            var category = Mapper.Map<Category, CategoryViewModel>(repository.Get<Category>(id));

            return View(category);
        }

        [HttpPost]
        public override ActionResult Delete(CategoryViewModel viewModel)
        {
            var categoryForDeleting = Mapper.Map<CategoryViewModel, Category>(viewModel);
            var category = repository.Get<Category>(categoryForDeleting.Id);
            repository.Delete(category);
            repository.Save();

            return RedirectToAction("Index");
        }

        public override ActionResult Edit(int id)
        {
            var category = Mapper.Map<Category, CategoryViewModel>(repository.Get<Category>(id));

            return View(category);
        }

        [HttpPost]
        public override ActionResult Edit(CategoryViewModel viewModel)
        {
            var categoryForEditig = Mapper.Map<CategoryViewModel, Category>(viewModel);
            var category= repository.Get<Category>(categoryForEditig.Id);
            category.Name = viewModel.Name;
            repository.Save();
            
            return RedirectToAction("Index");
        }
    }
}