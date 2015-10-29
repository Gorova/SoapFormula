using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using AutoMapper;
using Ninject;
using SoapFormula.Bootstrap;
using SoapFormula.Common.Entities;
using SoapFormula.DAL.Repository.Interface;
using SoapFormula.Web.ViewModel;

namespace SoapFormula.Web.Controllers
{
    public class ProductController : BaseController<Product, ProductViewModel>
    {
        private IKernel kernel;
        private IRepository repository;

        public ProductController() : base ()
        {
            this.kernel = Kernel.Initialize();
            this.repository = kernel.Get<IRepository>();
        }

        public override ActionResult Index()
        {
            var product = Mapper.Map<IEnumerable<Product>, IEnumerable<ProductViewModel>>(repository.Get<Product>());

            return View(product);
        }

        public override ActionResult Details(int id)
        {
            var product = Mapper.Map<Product, ProductViewModel>(repository.Get<Product>(id));

            return View(product);
        }

        public override ActionResult Create()
        {
            var model = Mapper.Map<IEnumerable<Manufacturer>,IEnumerable<ManufacturerViewModel> >(repository.Get<Manufacturer>());
            var model2 = new ProductViewModel();
           model2.ManufacturerItems = from m in model
                                     select new SelectListItem{ Text = m.Id.ToString(), Value = m.Name };

           return View(model2);
        }

        [HttpPost]
        public override ActionResult Create(ProductViewModel viewModel)
        {
            var product = Mapper.Map<ProductViewModel, Product>(viewModel);
            var manufacturer = Mapper.Map<Manufacturer, ManufacturerViewModel>(product.Manufacturer);
            //product.Manufacturer = repository.Get<Manufacturer>().FirstOrDefault(i => i.Name == viewModel.Manufacturer)
            //var manufacture =
            //    Mapper.Map<ManufacturerViewModel, Manufacturer>(
            //        repository.Get<ManufacturerViewModel>(viewModel.ManufacturerId));
            //var man = repository.Get<Manufacturer>().FirstOrDefault(i => i.Name == manufacture.Name);
            //if (man.Name != null)
            //    product.Manufacturer = man;
            repository.Add(product);
            repository.Save();
            
            return RedirectToAction("Index");
        }

        public override ActionResult Delete(int id)
        {
            var product = Mapper.Map<Product, ProductViewModel>(repository.Get<Product>(id));

            return View(product);
        }

        [HttpPost]
        public override ActionResult Delete(ProductViewModel viewModel)
        {
            var productForDeleting = Mapper.Map<ProductViewModel, Product>(viewModel);
            var product = repository.Get<Product>(productForDeleting.Id);
            repository.Delete(product);
            repository.Save();

            return RedirectToAction("Index");
        }

        public override ActionResult Edit(int id)
        {
            var product = Mapper.Map<Product, ProductViewModel>(repository.Get<Product>(id));

            return View(product);
        }

        [HttpPost]
        public override ActionResult Edit(ProductViewModel viewModel)
        {
            var productForEditing = Mapper.Map<ProductViewModel, Product>(viewModel);
            var product = repository.Get<Product>(productForEditing.Id);
            product.Name = viewModel.Name;
            product.Price = viewModel.Price;
            product.Weight = viewModel.Weight;
            //product.Manufacturer = viewModel.Manufacturer;
            repository.Save();

            return RedirectToAction("Index");
        }
    }
}