using System.Web.Mvc;
using SoapFormula.Common.Entities;
using SoapFormula.Web.ViewModel;

namespace SoapFormula.Web.Controllers
{
    public class ManufacturerController : BaseController<Manufacturer, ManufacturerViewModel>
    {
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