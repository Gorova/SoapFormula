using System.Data.Entity;
using Ninject.Modules;
using SoapFormula.BL.Handlers;
using SoapFormula.BL.Handlers.Interface;
using SoapFormula.Common.DTO;
using SoapFormula.DAL;
using SoapFormula.DAL.Repository;
using SoapFormula.DAL.Repository.Interface;

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
        }
    }
}
