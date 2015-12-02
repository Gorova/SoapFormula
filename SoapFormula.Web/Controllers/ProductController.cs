using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using AutoMapper;
using Ninject;
using SoapFormula.BL.API.Handlers;
using SoapFormula.Common.DTO;
using SoapFormula.Web.ViewModel;

namespace SoapFormula.Web.Controllers
{
    /// <summary>
    /// Class with functional for process incoming request
    /// to ProductViewModel. Implements BaseCobtroller
    /// </summary>
    public class ProductController : BaseCobtroller<ProductDto>
    {
        /// <summary>
        /// Get all products
        ///  </summary>
        /// <returns>Return View Index</returns>
        public ActionResult Index()
        {
            var viewModel = Mapper.Map<IEnumerable<ProductDto>, IEnumerable<ProductViewModel>>(handler.Get());

            return View(viewModel);
        }

        /// <summary>
        /// Get single product
        /// </summary>
        /// <param name="id">integer argument</param>
        /// <returns>Return view Details</returns>
        public ActionResult Details(int id)
        {
            var dto = handler.Get(id);
            var viewModel = Mapper.Map<ProductDto, ProductViewModel>(dto);
            viewModel.AllCategories = dto.Categories.Select(i => new SelectListItem{Text = i.Name});

            return View(viewModel);
        }

        /// <summary>
        /// Method craete new product
        /// and initialize SeletLists 
        /// </summary>
        /// <returns>Return view Create</returns>
        public ActionResult Create()
        {
            var viewModel = new ProductViewModel();
            InitializeViewModel(viewModel);

            return View(viewModel);
        }

        /// <summary>
        /// Method(POST) add product
        /// </summary>
        /// <param name="viewModel">ProductViewModel type entity</param>
        /// <returns>Redirect to method Index</returns>
        [HttpPost]
        public ActionResult Create(ProductViewModel viewModel)
        {
            var dto = Mapper.Map<ProductViewModel, ProductDto>(viewModel);
            handler.Add(dto);

            return RedirectToAction("Index");
        }

        /// <summary>
        /// Find single product
        /// </summary>
        /// <param name="id">integer argument</param>
        /// <returns>Return view Delete</returns>
        public ActionResult Delete(int id)
        {
            var dto = handler.Get(id);
            var viewModel = Mapper.Map<ProductDto, ProductViewModel>(dto);

            return View(viewModel);
        }

        /// <summary>
        /// Method(POST) delete one product
        /// </summary>
        /// <param name="viewModel">ProductViewModel type argument</param>
        /// <returns>Redirect to method Index</returns>
        [HttpPost]
        public ActionResult Delete(ProductViewModel viewModel)
        {
            var dto = Mapper.Map<ProductViewModel, ProductDto>(viewModel);
            handler.Delete(dto.Id);

            return RedirectToAction("Index");
        }

        /// <summary>
        /// Find single product and initialize SeletLists 
        /// </summary>
        /// <param name="id">integer argument</param>
        /// <returns>Return view Edit</returns>
        public ActionResult Edit(int id)
        {
            var dto = handler.Get(id);
            var viewModel = Mapper.Map<ProductDto, ProductViewModel>(dto);
            InitializeViewModel(viewModel);
            
            return View(viewModel);
        }

        /// <summary>
        /// Method Edit(POST) save changes in product
        /// </summary>
        /// <param name="viewModel">ProductViewModel type argument</param>
        /// <returns>Redirect to method Index</returns>
        [HttpPost]
        public ActionResult Edit(ProductViewModel viewModel)
        {
            var dto = Mapper.Map<ProductViewModel, ProductDto>(viewModel);
            handler.Update(dto);

            return RedirectToAction("Index");
        }

        private void InitializeViewModel(ProductViewModel viewModel)
        {
            var categories = kernel.Get<IHandler<CategoryDto>>().Get();
            viewModel.AllCategories = categories
                .Select(i => new SelectListItem
                {
                    Text = i.Name,
                    Value = i.Id.ToString()
                }).ToList();
            
            var manufacturers = kernel.Get<IHandler<ManufacturerDto>>().Get();
            viewModel.AllManufacturers = manufacturers
                .Select(i => new SelectListItem
                {
                    Text = i.Name,
                    Value = i.Id.ToString()
                }).ToList();
        }
    }
}