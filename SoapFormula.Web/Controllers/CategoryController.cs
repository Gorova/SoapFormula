using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using AutoMapper;
using SoapFormula.Common.Entities;
using SoapFormula.Web.ViewModel;

namespace SoapFormula.Web.Controllers
{
    public class CategoryController : BaseController<Category, CategoryViewModel> 
    {
        [HttpPost]
        public override ActionResult Create(CategoryViewModel viewModel)
        {
            var model = Mapper.Map<CategoryViewModel, Category>(viewModel);
            IList<Product> listProducts = new List<Product>();

            foreach (var productId in viewModel.SelectedIds)
            {
                var product = repository.Get<Product>(productId);
                listProducts.Add(product);
            }
            model.Products = listProducts;
            repository.Add(model);
            repository.Save();

            return RedirectToAction("Index");
        }

        [HttpPost]
        public override ActionResult Edit(CategoryViewModel viewModel)
        {
            var model = repository.Get<Category>(viewModel.Id);
            Mapper.Map(viewModel, model);
            model.Products = viewModel.SelectedIds.Select(i => repository.Get<Product>(i)).ToList();
            repository.Save();

            return RedirectToAction("Index");
        }

        [HttpPost]
        public override ActionResult Delete(CategoryViewModel viewModel)
        {
            var model = repository.Get<Category>(viewModel.Id);
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