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
        /// Get all categories
        /// </summary>
        /// <returns>Return View Index</returns>
        public ActionResult Index()
        {
            var viewModel = Mapper.Map<IEnumerable<CategoryDto>, IEnumerable<CategoryViewModel>>(handler.Get());

            return View(viewModel);
        }

        /// <summary>
        /// Get single category
        /// </summary>
        /// <param name="id">Requires integer argument</param>
        /// <returns>Return view Details</returns>
        public ActionResult Details(int id)
        {
            var viewModel = Mapper.Map<CategoryDto, CategoryViewModel>(handler.Get(id));

            return View(viewModel);
        }

        /// <summary>
        /// Method craete new category 
        /// </summary>
        /// <returns>Return view Create</returns>
        public ActionResult Create()
        {
            var viewModel = new CategoryViewModel();

            return View(viewModel);
        }

        /// <summary>
        /// Method(POST) add category
        /// </summary>
        /// <param name="viewModel">CategoryViewModel type entity</param>
        /// <returns>Redirect to method Index</returns>
        [HttpPost]
        public ActionResult Create(CategoryViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var dto = Mapper.Map<CategoryViewModel, CategoryDto>(viewModel);
                handler.Add(dto);

                return RedirectToAction("Index");
            }

            return View(viewModel);
        }

        /// <summary>
        /// Find single category
        /// </summary>
        /// <param name="id">integer argument</param>
        /// <returns>Return view Delete</returns>
        public ActionResult Delete(int id)
        {
            var dto = handler.Get(id);
            var viewModel = Mapper.Map<CategoryDto, CategoryViewModel>(dto);

            return View(viewModel);
        }

        /// <summary>
        /// Method(POST) delete one category
        /// </summary>
        /// <param name="viewModel">CategoryViewModel type argument</param>
        /// <returns>Redirect to method Index</returns>
        [HttpPost]
        public ActionResult Delete(CategoryViewModel viewModel)
        {
            var category = handler.Get(viewModel.Id);

            if (category.Products.Count != 0)
            {
                var viewModelWithProducts = Mapper.Map(category, viewModel);

                return View("NotDelete", viewModelWithProducts);
            }

            var dto = Mapper.Map<CategoryViewModel, CategoryDto>(viewModel);
            handler.Delete(dto.Id);

            return RedirectToAction("Index");
        }

        /// <summary>
        /// Find single category 
        /// </summary>
        /// <param name="id">integer argument</param>
        /// <returns>Return view Edit</returns>
        public ActionResult Edit(int id)
        {
            var dto = handler.Get(id);
            var viewModel = Mapper.Map<CategoryDto, CategoryViewModel>(dto);

            return View(viewModel);
        }

        /// <summary>
        /// Method Edit(POST) save changes in category
        /// </summary>
        /// <param name="viewModel">CategoryViewModel type argument</param>
        /// <returns>Redirect to method Index</returns>
        [HttpPost]
        public ActionResult Edit(CategoryViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var dto = Mapper.Map<CategoryViewModel, CategoryDto>(viewModel);
                handler.Update(dto);

                return RedirectToAction("Index");
            }

            return View(viewModel);
        }
    }
}