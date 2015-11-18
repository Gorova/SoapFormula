using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using AutoMapper;
using SoapFormula.Common.Entities;
using SoapFormula.Web.ViewModel;

namespace SoapFormula.Web.Controllers
{
    public class ProductController : BaseController<Product, ProductViewModel>
    {
        public override ActionResult Create()
        {
            var viewModel = new ProductViewModel();
            viewModel.Init(repository);

            return View(viewModel);
        }

        [HttpPost]
        public override ActionResult Create(ProductViewModel viewModel)
        {
            var model = Mapper.Map<ProductViewModel, Product>(viewModel);
            model.Categories = viewModel.SelectedIds.Select(i => repository.Get<Category>(i)).ToList();
            repository.Add(model);
            repository.Save();

            return RedirectToAction("Index");
        }

        [HttpPost]
        public override ActionResult Edit(ProductViewModel viewModel)
        {
            var model = repository.Get<Product>(viewModel.Id);
            Mapper.Map(viewModel, model);
            model.Categories = viewModel.SelectedIds.Select(i => repository.Get<Category>(i)).ToList();
            model.Manufacturer = repository.Get<Manufacturer>(viewModel.ManufacturerId);
            repository.Save();

            return RedirectToAction("Index");
        }

        public override ActionResult Edit(int id)
        {
            var model = Mapper.Map<Product,ProductViewModel>(repository.Get<Product>(id));
            model.Init(repository);

            return View(model);
        }

        [HttpPost]
        public override ActionResult Delete(ProductViewModel viewModel)
        {
            var model = repository.Get<Product>(viewModel.Id);
            if (model.Categories.Count != 0)
            {
                return View("NotDelete", model);
            }
            repository.Delete(model);
            repository.Save();

            return RedirectToAction("Index");
        }
    }
}