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
    public class CategoryController : Controller
    {
        private IHandler<CategoryDto> handler;
        private IKernel kernel;
        private IRepository repository;

        public CategoryController()
        {
            this.kernel = Kernel.Initialize();
            this.handler = kernel.Get<IHandler<CategoryDto>>();
            this.repository = kernel.Get<IRepository>();
        }

        public ActionResult Index()
        {
            var viewModel = Mapper.Map<IEnumerable<CategoryDto>, IEnumerable<CategoryViewModel>>(handler.Get());

            return View(viewModel);
        }

        public ActionResult Details(int id)
        {
            var viewModel = Mapper.Map<CategoryDto, CategoryViewModel>(handler.Get(id));

            return View(viewModel);
        }

        public ActionResult Create()
        {
            var viewModel = new CategoryViewModel();

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Create(CategoryViewModel viewModel)
        {
            var dto = Mapper.Map<CategoryViewModel, CategoryDto>(viewModel);
            handler.Add(dto);

            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            var dto = handler.Get(id);
            var viewModel = Mapper.Map<CategoryDto, CategoryViewModel>(dto);

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Delete(CategoryViewModel viewModel)
        {
            var model = repository.Get<Category>(viewModel.Id);
            if (model.Products.Count != 0)
            {
                return View("NotDelete", model);
            }
            
            var dto = Mapper.Map<CategoryViewModel, CategoryDto>(viewModel);
            handler.Delete(dto.Id);

            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            var dto = handler.Get(id);
            var viewModel = Mapper.Map<CategoryDto, CategoryViewModel>(dto);

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Edit(CategoryViewModel viewModel)
        {
            var dto = Mapper.Map<CategoryViewModel, CategoryDto>(viewModel);
            handler.Update(dto);

            return RedirectToAction("Index");
        }
    }
}