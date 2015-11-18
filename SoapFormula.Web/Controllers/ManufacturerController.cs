using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using AutoMapper;
using SoapFormula.Common.Entities;
using SoapFormula.Web.ViewModel;

namespace SoapFormula.Web.Controllers
{
    public class ManufacturerController : BaseController<Manufacturer, ManufacturerViewModel>
    {
        [HttpPost]
        public override ActionResult Create(ManufacturerViewModel viewModel)
        {
            var model = Mapper.Map<ManufacturerViewModel, Manufacturer>(viewModel);
            model.Products = viewModel.SelectedIds.Select(i => repository.Get<Product>(i)).ToList();
            repository.Add(model);
            repository.Save();

            return RedirectToAction("Index");
        }

        [HttpPost]
        public override ActionResult Edit(ManufacturerViewModel viewModel)
        {
            var model = repository.Get<Manufacturer>(viewModel.Id);
            Mapper.Map(viewModel, model);
            model.Products = viewModel.SelectedIds.Select(i => repository.Get<Product>(i)).ToList();
            repository.Save();

            return RedirectToAction("Index");
        }

        [HttpPost]
        public override ActionResult Delete(ManufacturerViewModel viewModel)
        {
            var model = repository.Get<Manufacturer>(viewModel.Id);
            if (model.Products.Count != 0)
            {
                return View("NotDelete", model);
            }
            repository.Delete(model);
            repository.Save();

            return RedirectToAction("Index");
        }
    }
}