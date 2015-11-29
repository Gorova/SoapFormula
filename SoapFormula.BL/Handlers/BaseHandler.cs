using SoapFormula.DAL.API.Repositories;

namespace SoapFormula.BL.Handlers
{
    /// <summary>
    /// Base class BaseHandler with constructor dependency injection 
    /// accept argument IRepository type
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
