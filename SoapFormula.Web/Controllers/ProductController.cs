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
        [HttpPost]
        public override ActionResult Create(ProductViewModel viewModel)
        {
            var model = Mapper.Map<ProductViewModel, Product>(viewModel);
            IList<Category> listCategories = new List<Category>();

            foreach (var categoryId in viewModel.SelectedIds)
            {
                var category = repository.Get<Category>().FirstOrDefault(i => i.Id == categoryId);
                listCategories.Add(category);
            }
            model.Categories = listCategories;
            repository.Add(model);
            repository.Save();

            return RedirectToAction("Index");
        }

        [HttpPost]
        public override ActionResult Edit(ProductViewModel viewModel)
        {
            var model = repository.Get<Product>(viewModel.Id);
            Mapper.Map(viewModel, model);
            IList<Category> listCategories = new List<Category>();

            foreach (var categoryId in viewModel.SelectedIds)
            {
                var category = repository.Get<Category>().FirstOrDefault(i => i.Id == categoryId);
                listCategories.Add(category);
            }
            model.Categories = listCategories;
            model.Manufacturer = repository.Get<Manufacturer>().FirstOrDefault(i => i.Id == viewModel.ManufacturerId);
            repository.Save();

            return RedirectToAction("Index");
        }
    }
}