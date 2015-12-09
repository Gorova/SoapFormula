using System.Collections.Generic;
using System.Web.Mvc;
using AutoMapper;
using SoapFormula.Common.DTO;
using SoapFormula.Web.ViewModel;

namespace SoapFormula.Web.Controllers
{
    /// <summary>
    /// Class with functional for process incoming request
    /// to ManufacturerViewModel. Implements BaseCobtroller
    /// </summary>
    public class ManufacturerController : BaseCobtroller<ManufacturerDto>
    {
        /// <summary>
        /// Get all manufacturers
        /// </summary>
        /// <returns>Return view Index</returns>
        public ActionResult Index()
        {
            var viewModel = Mapper.Map<IEnumerable<ManufacturerDto>, IEnumerable<ManufacturerViewModel>>(handler.Get());

            return View(viewModel);
        }

        /// <summary>
        /// Get single manufacturer
        /// </summary>
        /// <param name="id">Requires integer argument</param>
        /// <returns>Return view Details</returns>
        public ActionResult Details(int id)
        {
            var viewModel = Mapper.Map<ManufacturerDto, ManufacturerViewModel>(handler.Get(id));

            return View(viewModel);
        }

        /// <summary>
        /// Method craete new manufacturers 
        /// </summary>
        /// <returns>Return view Create</returns>
        public ActionResult Create()
        {
            var viewModel = new ManufacturerViewModel();

            return View(viewModel);
        }

        /// <summary>
        /// Method(POST) add manufacturer
        /// </summary>
        /// <param name="viewModel">ManufacturerViewModel type entity</param>
        /// <returns>Redirect to method Index</returns>
        [HttpPost]
        public ActionResult Create(ManufacturerViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var dto = Mapper.Map<ManufacturerViewModel, ManufacturerDto>(viewModel);
                handler.Add(dto);

                return RedirectToAction("Index");
            }

            return View(viewModel);
        }

        /// <summary>
        /// Find single manufacturer
        /// </summary>
        /// <param name="id">integer argument</param>
        /// <returns>Return view Delete</returns>
        public ActionResult Delete(int id)
        {
            var dto = handler.Get(id);
            var viewModel = Mapper.Map<ManufacturerDto, ManufacturerViewModel>(dto);

            return View(viewModel);
        }

        /// <summary>
        /// Method(POST) delete one manufacturer
        /// </summary>
        /// <param name="viewModel">ManufacturerViewModel type argument</param>
        /// <returns>Redirect to method Index</returns>
        [HttpPost]
        public ActionResult Delete(ManufacturerViewModel viewModel)
        {
            var manufacturer = handler.Get(viewModel.Id);

            if (manufacturer.Products.Count != 0)
            {
                var manufacturerWithProducts = Mapper.Map(manufacturer, viewModel);

                return View("NotDelete", manufacturerWithProducts);
            }

            var dto = Mapper.Map<ManufacturerViewModel, ManufacturerDto>(viewModel);
            handler.Delete(dto.Id);

            return RedirectToAction("Index");
        }

        /// <summary>
        /// Find single manufacturer 
        /// </summary>
        /// <param name="id">integer argument</param>
        /// <returns>Return view Edit</returns>
        public ActionResult Edit(int id)
        {
            var dto = handler.Get(id);
            var viewModel = Mapper.Map<ManufacturerDto, ManufacturerViewModel>(dto);

            return View(viewModel);
        }

        /// <summary>
        /// Method Edit(POST) save changes in manufacturer
        /// </summary>
        /// <param name="viewModel">ManufacturerViewModel type argument</param>
        /// <returns>Redirect to method Index</returns>
        [HttpPost]
        public ActionResult Edit(ManufacturerViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var dto = Mapper.Map<ManufacturerViewModel, ManufacturerDto>(viewModel);
                handler.Update(dto);

                return RedirectToAction("Index");
            }

            return View(viewModel);
        }
    }
}