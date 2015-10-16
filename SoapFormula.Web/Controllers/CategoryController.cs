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
        private IRepository repo;

        public CategoryController()
        {
            this.kernel = new StandardKernel(new LibraryModule());
            this.repo = kernel.Get<IRepository>();
        }
        
        public ActionResult Index()
        {
            var category = repo.Get<Category>();

            return View(category);
        }

        [HttpGet]
        public ActionResult Get(int id)
        {
            var category = repo.Get<Category>(id);

            return View("Get", category);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Category category)
        {
            repo.Add(category);
            repo.Save();

            return Redirect("Index");
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var category = repo.Get<Category>(id);
            return View(category);
        }

        [HttpPost]
        public ActionResult Deleting(int id)
        {
            var containsId = repo.Get<Category>(id);
            repo.Delete(containsId);
            repo.Save();

            return Redirect("Index");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var category = repo.Get<Category>(id);
            return View(category);
        }

        [HttpPost]
        public ActionResult Editing(Category category)
        {
            foreach (var c in repo.Get<Category>())
            {
                if (c.Id == category.Id)
                {
                    c.Name = category.Name;
                }
            }
            repo.Save();
            
            return Redirect("Index");
        }
    }
}