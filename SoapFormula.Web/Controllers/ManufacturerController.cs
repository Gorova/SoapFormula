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
    public class ManufacturerController : Controller
    {
        private IHandler<ManufacturerDto> handler;
        private IKernel kernel;
        private IRepository repository;

        public ManufacturerController()
        {
            this.kernel = Kernel.Initialize();
            this.handler = kernel.Get<IHandler<ManufacturerDto>>();
            this.repository = kernel.Get<IRepository>();
        }

        public ActionResult Index()
        {
            Mapper.CreateMap<ManufacturerDto, ManufacturerViewModel>();
            var viewModel = Mapper.Map<IEnumerable<ManufacturerDto>, IEnumerable<ManufacturerViewModel>>(handler.GetAll());

            return View(viewModel);
        }

        public ActionResult Details(int id)
        {
            Mapper.CreateMap<ManufacturerDto, ManufacturerViewModel>();
            var viewModel = Mapper.Map<ManufacturerDto, ManufacturerViewModel>(handler.Get(id));

            return View(viewModel);
        }

        public ActionResult Create()
        {
            var viewModel = new ManufacturerViewModel();

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Create(ManufacturerViewModel viewModel)
        {
            Mapper.CreateMap<ManufacturerViewModel, ManufacturerDto>();
            var dto = Mapper.Map<ManufacturerViewModel, ManufacturerDto>(viewModel);
            handler.Add(dto);

            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            var dto = handler.Get(id);
            Mapper.CreateMap<ManufacturerDto, ManufacturerViewModel>();
            var viewModel = Mapper.Map<ManufacturerDto, ManufacturerViewModel>(dto);

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Delete(ManufacturerViewModel viewModel)
        {
            var model = repository.Get<Manufacturer>(viewModel.Id);
            if (model.Products.Count != 0)
            {
                return View("NotDelete", model);
            }
            Mapper.CreateMap<ManufacturerViewModel, ManufacturerDto>();
            var dto = Mapper.Map<ManufacturerViewModel, ManufacturerDto>(viewModel);
            handler.Delete(dto.Id);

            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            var dto = handler.Get(id);
            Mapper.CreateMap<ManufacturerDto, ManufacturerViewModel>();
            var viewModel = Mapper.Map<ManufacturerDto, ManufacturerViewModel>(dto);

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Edit(ManufacturerViewModel viewModel)
        {
            Mapper.CreateMap<ManufacturerViewModel, ManufacturerDto>();
            var dto = Mapper.Map<ManufacturerViewModel, ManufacturerDto>(viewModel);
            handler.Update(dto);

            return RedirectToAction("Index");
        }
    }
}