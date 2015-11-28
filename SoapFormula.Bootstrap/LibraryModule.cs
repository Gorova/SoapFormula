﻿using System.Data.Entity;
using Ninject.Modules;
using SoapFormula.BL.API.Handlers;
using SoapFormula.BL.Handlers;
using SoapFormula.Common.DTO;
using SoapFormula.DAL;
using SoapFormula.DAL.API.Repositories;
using SoapFormula.DAL.Repositories;

namespace SoapFormula.Bootstrap
{
    /// <summary>
    /// class with functional of creating a link between 
    /// the interfaces and implementation of the class
    /// </summary>
    public class LibraryModule : NinjectModule
    {
        /// <summary>
        /// impplementation of basic method Load
        /// which calls method of creating a link between 
        /// the interfaces and implementation of the class
        /// </summary>
        public override void Load()
        {
            this.InitializeRepositories();
        }

        private void InitializeRepositories()
        {
            Bind<DbContext>().To<SoapFormulaContext>();
            Bind<IRepository>().To<Repository>();
            Bind<IHandler<ManufacturerDto>>().To<ManufacturerHandler>();
            Bind<IHandler<CategoryDto>>().To<CategoryHandler>();
            Bind<IHandler<ProductDto>>().To<ProductHandler>();
        }
    }
}
