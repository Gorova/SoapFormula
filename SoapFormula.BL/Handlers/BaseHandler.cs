using SoapFormula.DAL.Repository.Interface;

namespace SoapFormula.BL.Handlers
{
    public abstract class BaseHandler
    {
        public IRepository repository;

        public BaseHandler(IRepository repository)
        {
            this.repository = repository;
        }
    }
}
