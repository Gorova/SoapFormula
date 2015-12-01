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
    /// <returns>Return View Index</returns>
    public class ManufacturerController : BaseCobtroller<ManufacturerDto>
    {
        /// <summary>
        /// Method Index form enumarable collection ManufacturerDto
        /// and map ManufacturerDto to ManufacturerViewModel
        /// </summary>
        /// <returns>Return view Index</returns>
        public ActionResult Index()
        {
            var viewModel = Mapper.Map<IEnumerable<ManufacturerDto>, IEnumerable<ManufacturerViewModel>>(handler.Get());

            return View(viewModel);
        }

        /// <summary>
        /// Method Details find ManufacturerDto type entity
        /// and map ManufacturerDto to ManufacturerViewModel
        /// </summary>
        /// <param name="id">Requires integer argument</param>
        /// <returns>Return view Details</returns>
        public ActionResult Details(int id)
        {
            var viewModel = Mapper.Map<ManufacturerDto, ManufacturerViewModel>(handler.Get(id));

            return View(viewModel);
        }

        /// <summary>
        /// Method craete new entity ManufacturerViewModel type
        /// </summary>
        /// <returns>Return view Create</returns>
        public ActionResult Create()
        {
            var viewModel = new ManufacturerViewModel();

            return View(viewModel);
        }

        /// <summary>
        /// Method Create(POST) map ManufacturerViewModel to ManufacturerDto
        /// calls ManufacturerDto`s method Add for adding entity
        /// </summary>
        /// <param name="viewModel">Requires ManufacturerViewModel entity</param>
        /// <returns>Redirect to method Index</returns>
        [HttpPost]
        public ActionResult Create(ManufacturerViewModel viewModel)
        {
            var dto = Mapper.Map<ManufacturerViewModel, ManufacturerDto>(viewModel);
            handler.Add(dto);

            return RedirectToAction("Index");
        }

        /// <summary>
        /// Method Details find ManufacturerDto type entity 
        /// and map ManufacturerDto to ManufacturerViewModel
        /// </summary>
        /// <param name="id">Requires integer argument</param>
        /// <returns>Return view Delete</returns>
        public ActionResult Delete(int id)
        {
            var dto = handler.Get(id);
            var viewModel = Mapper.Map<ManufacturerDto, ManufacturerViewModel>(dto);

            return View(viewModel);
        }

        /// <summary>
        /// Method Delete(POST) map ManufacturerViewModel to ManufacturerDto
        /// calls ManufacturerDto`s methos Delete for deleting entity
        /// </summary>
        /// <param name="viewModel">Requires ManufacturerViewModel type argument</param>
        /// <returns>Redirect to method Index</returns>
        [HttpPost]
        public ActionResult Delete(ManufacturerViewModel viewModel)
        {
            var dto = Mapper.Map<ManufacturerViewModel, ManufacturerDto>(viewModel);
            handler.Delete(dto.Id);

            return RedirectToAction("Index");
        }

        /// <summary>
        /// Method Edit find ManufacturerDto type entity
        /// and map ManufacturerDto to ManufacturerViewModel
        /// </summary>
        /// <param name="id">Requires integer argument</param>
        /// <returns>Return view Edit</returns>
        public ActionResult Edit(int id)
        {
            var dto = handler.Get(id);
            var viewModel = Mapper.Map<ManufacturerDto, ManufacturerViewModel>(dto);

            return View(viewModel);
        }

        /// <summary>
        /// Method Edit(POST) map ManufacturerViewModel to ManufacturerDto
        /// calls ManufacturerDto`s method for save changes in entity
        /// </summary>
        /// <param name="viewModel">Requires ManufacturerViewModel type argument</param>
        /// <returns>Redirect to method Index</returns>
        [HttpPost]
        public ActionResult Edit(ManufacturerViewModel viewModel)
        {
            var dto = Mapper.Map<ManufacturerViewModel, ManufacturerDto>(viewModel);
            handler.Update(dto);

            return RedirectToAction("Index");
        }
    }
}