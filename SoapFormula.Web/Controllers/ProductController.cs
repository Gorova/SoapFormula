using SoapFormula.Common.Entities;
using SoapFormula.Web.ViewModel;

namespace SoapFormula.Web.Controllers
{
    public class ProductController : BaseController<Product, ProductViewModel>
    {
        //public override ActionResult Create()
        //{
        //    var model = new ProductViewModel();
        //    model.ManufacturerItems = model.Init<Manufacturer>(repository);
        //    model.CategoryItems = model.Init<Category>(repository);

        //    return View(model);
        //}
    }
}