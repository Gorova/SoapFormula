﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using Ninject;
using SoapFormula.Bootstrap;
using SoapFormula.Common.Entities;
using SoapFormula.DAL.Repository.Interface;
using SoapFormula.Web.ViewModel;

namespace SoapFormula.Web.Controllers
{
    public class CategoryController : Controller
    {
        private IKernel kernel;
        private IRepository repository;

        public CategoryController()
        {
            this.kernel = Kernel.Initialize();
            this.repository = kernel.Get<IRepository>();
        }
       
        public ActionResult Index()
        {
            var category = Mapper.Map<IEnumerable<Category>, IEnumerable<CategoryViewModel>>(repository.Get<Category>());
            return View(category);
        }
        
        public ActionResult Details(int id)
        {
            var category = repository.Get<Category>(id);

            return View(category);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Category category)
        {
            repository.Add(category);
            repository.Save();

            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            var category = repository.Get<Category>(id);

            return View(category);
        }

        [HttpPost]
        public ActionResult Delete(Category category)
        {
            var categoryForDeleting = repository.Get<Category>(category.Id);
            repository.Delete(categoryForDeleting);
            repository.Save();

            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            var category = repository.Get<Category>(id);

            return View(category);
        }

        [HttpPost]
        public ActionResult Edit(Category category)
        {
            var categoryForEditig = repository.Get<Category>(category.Id);
            categoryForEditig.Name = category.Name;
            repository.Save();
            
            return RedirectToAction("Index");
        }
    }
}