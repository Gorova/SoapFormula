using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations.Model;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ninject;
using SoapFormula.Bootstrap;
using SoapFormula.Common.Entities;
using SoapFormula.DAL.Repository.Interface;

namespace SoapFormula.Web.Controllers
{
    public class HomeController : Controller
    {
        private IKernel kernel;
        private IRepository repo;

        public HomeController()
        {
            this.kernel = new StandardKernel(new LibraryModule());
            this.repo = kernel.Get<IRepository>();
        }
        public ActionResult Index()
        {

            //repo.Add(new Category { Name = "ScrubSoap" });
            //repo.Add(new Category { Name = "Baby's" });
            //repo.Save();
            var category = repo.Get<Category>();
            return View(category);
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

        public ActionResult Delete()
        {
            var list = repo.Get<Category>();
            ViewBag.Category = new SelectList(list, "Id", "Name", 2);

            return View();
        }

        [HttpPost]
        public ActionResult Delete(string category)
        {
            int a = Int32.Parse(category);
            var comp = repo.Get<Category>().FirstOrDefault(i => i.Id == a);
            repo.Delete(comp);
            repo.Save();

            return Redirect("Index");
        }

        public ActionResult Edit()
        {
            return ViewBag();
        }

        [HttpPost]
        public ActionResult Edit(Category category)
        {
            return View();
        }

        [HttpPost]
        public ActionResult Get(int id)
        {
            var a = repo.Get<Category>().FirstOrDefault(i => i.Id == id);
            ViewBag.Inform = "Вы выбрали категорию" + a.Name;
            return View("Get");
        }
        

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}