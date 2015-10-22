using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ninject;
using SoapFormula.Bootstrap;
using SoapFormula.Common.Entities;
using SoapFormula.DAL.Repository.Interface;

namespace SoapFormula.Web.Controllers
{
    public class ProductController : Controller
    {
        private IKernel kernel;
        private IRepository repository;

        public ProductController()
        {
            this.kernel = new StandardKernel(new LibraryModule());
            this.repository = kernel.Get<IRepository>();
        }

        public ActionResult Index()
        {
            var product = repository.Get<Product>();

            return View(product);
        }

        public ActionResult Details(int id)
        {
            var product = repository.Get<Product>(id);

            return View(product);
        }

        public ActionResult Create()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Create(Product product)
        {
            var manufacture = repository.Get<Manufacturer>().FirstOrDefault(i => i.Name == product.Manufacturer.Name);
            if (product.Manufacturer.Name != null && manufacture != null)
            {
                product.Manufacturer = manufacture;
                repository.Add(product);
                repository.Save();
            }
            
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            var product = repository.Get<Product>(id);

            return View(product);
        }

        [HttpPost]
        public ActionResult Delete(Product product)
        {
            var productForDeleting = repository.Get<Product>(product.Id);
            repository.Delete(productForDeleting);
            repository.Save();

            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            var product = repository.Get<Product>(id);

            return View(product);
        }

        [HttpPost]
        public ActionResult Edit(Product product)
        {
            var productForEditing = repository.Get<Product>(product.Id);
            productForEditing.Name = product.Name;
            productForEditing.Price = product.Price;
            productForEditing.Weight = product.Weight;
            productForEditing.Manufacturer = product.Manufacturer;
            repository.Save();

            return RedirectToAction("Index");
        }
    }
}