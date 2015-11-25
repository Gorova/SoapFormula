using System.Data.Entity;
using Ninject.Modules;
using SoapFormula.BL.API.Handlers;
using SoapFormula.BL.Handlers;
using SoapFormula.Common.DTO;
using SoapFormula.DAL;
using SoapFormula.DAL.API.Repositories;
using SoapFormula.DAL.Repository;

namespace SoapFormula.Bootstrap
{
    public class LibraryModule : NinjectModule
    {
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
