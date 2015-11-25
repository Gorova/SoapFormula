using System.Collections.Generic;
using System.Web.Mvc;
using AutoMapper;
using Ninject;
using SoapFormula.BL.Handlers.Interface;
using SoapFormula.Bootstrap;
using SoapFormula.Common.DTO;
using SoapFormula.DAL.Entities;
using SoapFormula.DAL.Repository.Interface;
using SoapFormula.Web.ViewModel;

namespace SoapFormula.Web.Controllers
{
    public class ProductController : Controller
    {
        private IHandler<ProductDto> handler;
        private IKernel kernel;
        private IRepository repository;

        public ProductController()
        {
            this.kernel = Kernel.Initialize();
            this.handler = kernel.Get<IHandler<ProductDto>>();
            this.repository = kernel.Get<IRepository>();
        }

        public ActionResult Index()
        {
            Mapper.CreateMap<ProductDto, ProductViewModel>();
            var viewModel = Mapper.Map<IEnumerable<ProductDto>, IEnumerable<ProductViewModel>>(handler.GetAll());

            return View(viewModel);
        }

        public ActionResult Details(int id)
        {
            Mapper.CreateMap<ProductDto, ProductViewModel>();
            var viewModel = Mapper.Map<ProductDto, ProductViewModel>(handler.Get(id));

            return View(viewModel);
        }

        public ActionResult Create()
        {
            var viewModel = new ProductViewModel();
            viewModel.Init(repository);

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Create(ProductViewModel viewModel)
        {
            Mapper.CreateMap<ProductViewModel, ProductDto>();
            var dto = Mapper.Map<ProductViewModel, ProductDto>(viewModel);
            handler.Add(dto);

            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            var dto = handler.Get(id);
            Mapper.CreateMap<ProductDto, ProductViewModel>();
            var viewModel = Mapper.Map<ProductDto, ProductViewModel>(dto);

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Delete(ProductViewModel viewModel)
        {
            var model = repository.Get<Product>(viewModel.Id);
            if (model.Categories.Count != 0)
            {
                return View("NotDelete", model);
            }
            Mapper.CreateMap<ProductViewModel, ProductDto>();
            var dto = Mapper.Map<ProductViewModel, ProductDto>(viewModel);
            handler.Delete(dto.Id);

            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            var dto = handler.Get(id);
            Mapper.CreateMap<ProductDto, ProductViewModel>();
            var viewModel = Mapper.Map<ProductDto, ProductViewModel>(dto);
            viewModel.Init(repository);

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Edit(ProductViewModel viewModel)
        {
            Mapper.CreateMap<ProductViewModel, ProductDto>();
            var dto = Mapper.Map<ProductViewModel, ProductDto>(viewModel);
            handler.Update(dto);

            return RedirectToAction("Index");
        }
    }
}