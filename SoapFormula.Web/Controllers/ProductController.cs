using System.Collections.Generic;
using System.Data.Entity.Core.Metadata.Edm;
using System.Linq;
using System.Web.Mvc;
using AutoMapper;
using SoapFormula.Common.Entities;
using SoapFormula.Common.Interface;
using SoapFormula.Web.ViewModel;

namespace SoapFormula.Web.Controllers
{
    public class ProductController : BaseController<Product, ProductViewModel>
    {
        public override ActionResult Create()
        {
            var product = new Product();
            var model = new ProductViewModel();
            var s = Mapper.Map<Product, ProductViewModel>(product);
            model.ManufacturerItems = repository.Get<Manufacturer>().CreateList<Manufacturer>(model.ManufacturerId);
            
            return View(model);
        }
    }

    static class ListForViewModel
    {
        public static IEnumerable<SelectListItem> CreateList<TModel>(this IEnumerable<TModel> context , int selectedId) where TModel : IBase
        {
            return context.OrderBy(i => i.Name)
                .Select(i => new SelectListItem
                {
                    Selected = (i.Id == selectedId),
                    Text = i.Name,
                    Value = i.Id.ToString()
                });
        }
    }
}