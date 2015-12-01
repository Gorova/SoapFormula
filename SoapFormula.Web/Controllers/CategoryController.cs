using System.Collections.Generic;
using System.Web.Mvc;
using AutoMapper;
using SoapFormula.Common.DTO;
using SoapFormula.Web.ViewModel;

namespace SoapFormula.Web.Controllers
{
    /// <summary>
    /// Class with functional for process incoming request
    /// to CategoryViewModel. Implements BaseCobtroller
    /// </summary>
    public class CategoryController : BaseCobtroller<CategoryDto>
    {
        /// <summary>
        /// Method Index form enumarable collection CategoryDto
        /// and map CategoryDto to CategoryViewModel
        /// </summary>
        /// <returns>Return View Index</returns>
        public ActionResult Index()
        {
            var viewModel = Mapper.Map<IEnumerable<CategoryDto>, IEnumerable<CategoryViewModel>>(handler.Get());

            return View(viewModel);
        }

        /// <summary>
        /// Method Details find CategoryDto type entity 
        /// and map CategoryDto to CategoryViewModel
        /// </summary>
        /// <param name="id">Requires integer argument</param>
        /// <returns>Return view Details</returns>
        public ActionResult Details(int id)
        {
            var viewModel = Mapper.Map<CategoryDto, CategoryViewModel>(handler.Get(id));

            return View(viewModel);
        }

        /// <summary>
        /// Method craete new entity CategoryViewModel type
        /// </summary>
        /// <returns>Return view Create</returns>
        public ActionResult Create()
        {
            var viewModel = new CategoryViewModel();

            return View(viewModel);
        }

        /// <summary>
        /// Method Create(POST) map CategoryViewModel to CategoryDto
        /// calls CategoryDto`s method Add for adding entity
        /// </summary>
        /// <param name="viewModel">Requires CategoryViewModel entity</param>
        /// <returns>Redirect to method Index</returns>
        [HttpPost]
        public ActionResult Create(CategoryViewModel viewModel)
        {
            var dto = Mapper.Map<CategoryViewModel, CategoryDto>(viewModel);
            handler.Add(dto);

            return RedirectToAction("Index");
        }

        /// <summary>
        /// Method Details find CategoryDto type entity 
        /// and map CategoryDto to CategoryViewModel
        /// </summary>
        /// <param name="id">Requires integer argument</param>
        /// <returns>return view Delete</returns>
        public ActionResult Delete(int id)
        {
            var dto = handler.Get(id);
            var viewModel = Mapper.Map<CategoryDto, CategoryViewModel>(dto);

            return View(viewModel);
        }

        /// <summary>
        /// Method Delete(POST) map CategoryViewModel to CategoryDto
        /// calls CategoryDto`s methos Delete for deleting entity
        /// </summary>
        /// <param name="viewModel">Requires CategoryViewModel type argument</param>
        /// <returns>Redirect to method Index</returns>
        [HttpPost]
        public ActionResult Delete(CategoryViewModel viewModel)
        {
            var dto = Mapper.Map<CategoryViewModel, CategoryDto>(viewModel);
            handler.Delete(dto.Id);

            return RedirectToAction("Index");
        }

        /// <summary>
        /// Method Edit find CategoryDto type entity 
        /// and map CategoryDto to CategoryViewModel
        /// </summary>
        /// <param name="id">Requires integer argument</param>
        /// <returns>Return view Edit</returns>
        public ActionResult Edit(int id)
        {
            var dto = handler.Get(id);
            var viewModel = Mapper.Map<CategoryDto, CategoryViewModel>(dto);

            return View(viewModel);
        }

        /// <summary>
        /// Method Edit(POST)  map CategoryViewModel to CategoryDto
        /// calls CategoryDto`s method for save changes in entity
        /// </summary>
        /// <param name="viewModel">Requires CategoryViewModel type argument</param>
        /// <returns>Redirect to method Index</returns>
        [HttpPost]
        public ActionResult Edit(CategoryViewModel viewModel)
        {
            var dto = Mapper.Map<CategoryViewModel, CategoryDto>(viewModel);
            handler.Update(dto);

            return RedirectToAction("Index");
        }
    }
}