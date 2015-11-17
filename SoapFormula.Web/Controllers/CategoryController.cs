using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using AutoMapper;
using SoapFormula.Common.Entities;
using SoapFormula.Web.ViewModel;

namespace SoapFormula.Web.Controllers
{
    public class CategoryController : BaseController<Category,CategoryViewModel> 
    {
        [HttpPost]
        public override ActionResult Create(CategoryViewModel viewModel)
        {
            var model = Mapper.Map<CategoryViewModel, Category>(viewModel);
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
        public override ActionResult Edit(CategoryViewModel viewModel)
        {
            var model = repository.Get<Category>(viewModel.Id);
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