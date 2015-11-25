using System.Collections.Generic;
using System.Web.Mvc;
using AutoMapper;
using Ninject;
using SoapFormula.BL.API.Handlers;
using SoapFormula.Bootstrap;
using SoapFormula.Common.DTO;
using SoapFormula.DAL.API.Repositories;
using SoapFormula.DAL.Entities;
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
            viewModel.Init(repository);

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
            var model = repository.Get<Product>(viewModel.Id);
            if (model.Categories.Count != 0)
            {
                return View("NotDelete", model);
            }

            var dto = Mapper.Map<ProductViewModel, ProductDto>(viewModel);
            handler.Delete(dto.Id);

            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            var dto = handler.Get(id);
            var viewModel = Mapper.Map<ProductDto, ProductViewModel>(dto);
            viewModel.Init(repository);

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Edit(ProductViewModel viewModel)
        {
            var dto = Mapper.Map<ProductViewModel, ProductDto>(viewModel);
            handler.Update(dto);

            return RedirectToAction("Index");
        }
    }
}