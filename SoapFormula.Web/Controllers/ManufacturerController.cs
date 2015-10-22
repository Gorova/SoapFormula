using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ninject;
using SoapFormula.Bootstrap;
using SoapFormula.Common.Entities;
using SoapFormula.DAL.Repository;
using SoapFormula.DAL.Repository.Interface;

namespace SoapFormula.Web.Controllers
{
    public class ManufacturerController : Controller
    {
        private IKernel kernel;
        private IRepository repository;

        public ManufacturerController()
        {
            this.kernel = Kernel.Initialize();
            this.repository = kernel.Get<Repository>();
        }
        
        public ActionResult Index()
        {
            var manufacturer = repository.Get<Manufacturer>();

            return View(manufacturer);
        }

        public ActionResult Details(int id)
        {
            var manufacturer = repository.Get<Manufacturer>(id);

            return View(manufacturer);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Manufacturer manufacturer)
        {
            repository.Add(manufacturer);
            repository.Save();

            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            var manufacturer = repository.Get<Manufacturer>(id);

            return View(manufacturer);
        }

        [HttpPost]
        public ActionResult Delete(Manufacturer manufacturer)
        {
            var manufacturerForDeleting = repository.Get<Manufacturer>(manufacturer.Id);
            repository.Delete(manufacturerForDeleting);
            repository.Save();

            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            var manufacturer = repository.Get<Manufacturer>(id);

            return View(manufacturer);
        }

        [HttpPost]
        public ActionResult Edit(Manufacturer manufacturer)
        {
            var manufacturerForEditing = repository.Get<Manufacturer>(manufacturer.Id);
            manufacturerForEditing.Name = manufacturer.Name;
            repository.Save();

            return RedirectToAction("Index");
        }
    }
}