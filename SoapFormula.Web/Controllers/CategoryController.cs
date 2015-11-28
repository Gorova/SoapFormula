using System.Collections.Generic;
using System.Web.Mvc;
using AutoMapper;
using SoapFormula.Common.DTO;
using SoapFormula.Web.ViewModel;

namespace SoapFormula.Web.Controllers
{
    public class CategoryController : BaseCobtroller<CategoryDto>
    {
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