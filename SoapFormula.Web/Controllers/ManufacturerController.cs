using System.Collections.Generic;
using System.Web.Mvc;
using AutoMapper;
using Ninject;
using SoapFormula.BL.API.Handlers;
using SoapFormula.Bootstrap;
using SoapFormula.Common.DTO;
using SoapFormula.Web.ViewModel;

namespace SoapFormula.Web.Controllers
{
    public class ManufacturerController : Controller
    {
        private IHandler<ManufacturerDto> handler;
        private IKernel kernel;
        
        public ManufacturerController()
        {
            this.kernel = Kernel.Initialize();
            this.handler = kernel.Get<IHandler<ManufacturerDto>>();
        }

        public ActionResult Index()
        {
            var viewModel = Mapper.Map<IEnumerable<ManufacturerDto>, IEnumerable<ManufacturerViewModel>>(handler.Get());

            return View(viewModel);
        }

        public ActionResult Details(int id)
        {
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
            var dto = Mapper.Map<ManufacturerViewModel, ManufacturerDto>(viewModel);
            handler.Add(dto);

            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            var dto = handler.Get(id);
            var viewModel = Mapper.Map<ManufacturerDto, ManufacturerViewModel>(dto);

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Delete(ManufacturerViewModel viewModel)
        {
            var dto = Mapper.Map<ManufacturerViewModel, ManufacturerDto>(viewModel);
            handler.Delete(dto.Id);

            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            var dto = handler.Get(id);
            var viewModel = Mapper.Map<ManufacturerDto, ManufacturerViewModel>(dto);

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Edit(ManufacturerViewModel viewModel)
        {
            var dto = Mapper.Map<ManufacturerViewModel, ManufacturerDto>(viewModel);
            handler.Update(dto);

            return RedirectToAction("Index");
        }
    }
}