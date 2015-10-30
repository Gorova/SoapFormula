using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using Ninject;
using SoapFormula.Bootstrap;
using SoapFormula.Common.Entities;
using SoapFormula.DAL.Repository;
using SoapFormula.DAL.Repository.Interface;
using SoapFormula.Web.ViewModel;

namespace SoapFormula.Web.Controllers
{
    public class ManufacturerController : BaseController<Manufacturer, ManufacturerViewModel>
    {
        private IKernel kernel;
        private IRepository repository;

        public ManufacturerController() : base()
        {
            this.kernel = Kernel.Initialize();
            this.repository = kernel.Get<Repository>();
        }

        public override ActionResult Index()
        {
            var manufacturer = Mapper.Map<IEnumerable<Manufacturer>,IEnumerable<ManufacturerViewModel>>(repository.Get<Manufacturer>());

            return View(manufacturer);
        }

        public override ActionResult Details(int id)
        {
            var manufacturer = Mapper.Map<Manufacturer, ManufacturerViewModel>(repository.Get<Manufacturer>(id));

            return View(manufacturer);
        }

        public override ActionResult Create()
        {
           
            return View();
        }

        [HttpPost]
        public override ActionResult Create(ManufacturerViewModel viewModel)
        {
            var manufacturer = Mapper.Map<ManufacturerViewModel, Manufacturer>(viewModel);
            repository.Add(manufacturer);
            repository.Save();

            return RedirectToAction("Index");
        }

        public override ActionResult Delete(int id)
        {
            var manufacturer = Mapper.Map<Manufacturer, ManufacturerViewModel>(repository.Get<Manufacturer>(id));

            return View(manufacturer);
        }

        [HttpPost]
        public override ActionResult Delete(ManufacturerViewModel viewModel)
        {
            var manufacturerForDeleting = Mapper.Map<ManufacturerViewModel, Manufacturer>(viewModel);
            var manufacturer = repository.Get<Manufacturer>(manufacturerForDeleting.Id);
            repository.Delete(manufacturer);
            repository.Save();

            return RedirectToAction("Index");
        }

        public override ActionResult Edit(int id)
        {
            var manufacturer = Mapper.Map<Manufacturer, ManufacturerViewModel>(repository.Get<Manufacturer>(id));

            return View(manufacturer);
        }

        [HttpPost]
        public override ActionResult Edit(ManufacturerViewModel viewModel)
        {
            var manufacturerForEditing = Mapper.Map<ManufacturerViewModel, Manufacturer>(viewModel);
            var manufacturer = repository.Get<Manufacturer>(manufacturerForEditing.Id);
            manufacturer.Name = viewModel.Name;
            repository.Save();

            return RedirectToAction("Index");
        }
    }
}