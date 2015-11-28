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
    public class ProductController : BaseCobtroller<ProductDto>
    {
        public ActionResult Index()
        {
            var viewModel = Mapper.Map<IEnumerable<ProductDto>, IEnumerable<ProductViewModel>>(handler.Get());

            return View(viewModel);
        }

        public ActionResult Details(int id)
        {
            var viewModel = Mapper.Map<ProductDto, ProductViewModel>(handler.Get(id));

            return View(viewModel);
        }

        public ActionResult Create()
        {
            var viewModel = new ProductViewModel();
            InitializeViewModel(viewModel);

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Create(ProductViewModel viewModel)
        {
            var dto = Mapper.Map<ProductViewModel, ProductDto>(viewModel);
            handler.Add(dto);

            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            var dto = handler.Get(id);
            var viewModel = Mapper.Map<ProductDto, ProductViewModel>(dto);

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Delete(ProductViewModel viewModel)
        {
            var dto = Mapper.Map<ProductViewModel, ProductDto>(viewModel);
            handler.Delete(dto.Id);

            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            var dto = handler.Get(id);
            var viewModel = Mapper.Map<ProductDto, ProductViewModel>(dto);
            InitializeViewModel(viewModel);
            
            return View(viewModel);
        }
        
        [HttpPost]
        public ActionResult Edit(ProductViewModel viewModel)
        {
            var dto = Mapper.Map<ProductViewModel, ProductDto>(viewModel);
            handler.Update(dto);

            return RedirectToAction("Index");
        }

        public void InitializeViewModel(ProductViewModel viewModel)
        {
            var categories = kernel.Get<IHandler<CategoryDto>>().Get();
            var listCategories = categories
                    .Select(i => new { i.Id, i.Name }).ToList();
            viewModel.CategoryItems = new MultiSelectList(listCategories, "Id", "Name");

            var manufacturers = kernel.Get<IHandler<ManufacturerDto>>().Get();
            viewModel.ManufacturerItems = manufacturers
                .Select(i => new SelectListItem
                {
                    Text = i.Name,
                    Value = i.Id.ToString()
                }).ToList();
        }
    }
}