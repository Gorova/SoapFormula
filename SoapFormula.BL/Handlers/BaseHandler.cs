using SoapFormula.DAL.API.Repositories;

namespace SoapFormula.BL.Handlers
{
    /// <summary>
    /// base class with constructor dependency injection 
    /// </summary>
    public abstract class BaseHandler
    {
        protected  IRepository repository;

        protected BaseHandler(IRepository repository)
        {
            this.repository = repository;
        }
    }
}
