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
            IList<Product> listProducts = new List<Product>();

            foreach (var productId in viewModel.SelectedIds)
            {
                var product = repository.Get<Product>().FirstOrDefault(i => i.Id == productId);
                listProducts.Add(product);
            }
            model.Products = listProducts;
            repository.Add(model);
            repository.Save();

            return RedirectToAction("Index");
        }

        [HttpPost]
        public override ActionResult Edit(ManufacturerViewModel viewModel)
        {
            var model = repository.Get<Manufacturer>(viewModel.Id);
            Mapper.Map(viewModel, model);
            IList<Product> listProducts = new List<Product>();

            foreach (var productId in viewModel.SelectedIds)
            {
                var product = repository.Get<Product>().FirstOrDefault(i => i.Id == productId);
                listProducts.Add(product);
            }
            model.Products = listProducts;
            repository.Save();

            return RedirectToAction("Index");
        }
    }
}