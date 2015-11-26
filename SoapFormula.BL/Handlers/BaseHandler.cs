using SoapFormula.DAL.API.Repositories;

namespace SoapFormula.BL.Handlers
{
    public abstract class BaseHandler
    {
        protected  IRepository repository;

        protected BaseHandler(IRepository repository)
        {
            this.repository = repository;
        }
    }
}
