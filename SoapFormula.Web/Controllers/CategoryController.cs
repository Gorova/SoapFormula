using System.Web.Mvc;
using SoapFormula.Common.Entities;
using SoapFormula.Web.ViewModel;

namespace SoapFormula.Web.Controllers
{
    public class CategoryController : BaseController<Category, CategoryViewModel> 
    {
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