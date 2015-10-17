using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ninject;
using SoapFormula.Bootstrap;
using SoapFormula.Common.Entities;
using SoapFormula.DAL.Repository.Interface;

namespace SoapFormula.Web.Controllers
{
    public class CategoryController : Controller
    {
        private IKernel kernel;
        private IRepository repository;

        public CategoryController()
        {
            this.kernel = new StandardKernel(new LibraryModule());
            this.repository = kernel.Get<IRepository>();
        }
       
        public ActionResult Index()
        {
            var category = repository.Get<Category>();

            return View(category);
        }
        
        public ActionResult Details(int id)
        {
            var category = repository.Get<Category>(id);

            return View(category);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Category category)
        {
            repository.Add(category);
            repository.Save();

            return Redirect("Index");
        }

        public ActionResult Delete(int id)
        {
            var category = repository.Get<Category>(id);

            return View(category);
        }

        [HttpPost]
        public ActionResult Delete(Category category)
        {
            var categoryForDeleting = repository.Get<Category>(category.Id);
            repository.Delete(categoryForDeleting);
            repository.Save();

            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            var category = repository.Get<Category>(id);

            return View(category);
        }

        [HttpPost]
        public ActionResult Edit(Category category)
        {
            foreach (var c in repository.Get<Category>())
            {
                if (c.Id == category.Id)
                {
                    c.Name = category.Name;
                }
            }
            repository.Save();
            
            return RedirectToAction("Index");
        }
    }
}