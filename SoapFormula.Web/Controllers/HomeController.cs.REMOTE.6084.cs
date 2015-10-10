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
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            IKernel kernel = new StandardKernel(new LibraryModule());
            var repo = kernel.Get<IRepository>();
            //repo.Add(new Category { Name = "ScrubSoap" });
            //repo.Add(new Category { Name = "Baby`s" });
            //repo.Save();
            var category = repo.Get<Category>();
            Session["repository"] = repo;
            Session["category"] = category;
            return View(category);
      }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(string name)
        {
            var repo = (IRepository) Session["repository"];
            var category = (IQueryable)Session["category"];
            repo.Add(new Category { Name = name});
            repo.Save(); 
            Session["repository"] = repo;
            Session["category"] = category;

            return Redirect("Index");
        }

        [HttpPost]
        public ActionResult Delete(string name)
        {
            var repo = (IRepository)Session["repository"];
            var category = (IQueryable)Session["category"];
           // var del = category.FirstOrDefault(i => i.Name == name);
           // repo.Delete(category.FirstOrDefault(i => i.Name == name));

            return Redirect("Index");
        }

        [HttpPost]
        public ActionResult Edit()
        {
            return View();
        }

        public ActionResult Get()
        {
            var category = (IQueryable)Session["category"];
            ViewBag.Category = new SelectList(category, "Id", "Name", 0);
            Session["category"] = category;
            return View();
        }

        public ActionResult Get(int id)
        {
            return View();
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