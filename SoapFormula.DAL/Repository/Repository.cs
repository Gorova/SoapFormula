using System.Data.Entity;
using System.Linq;
using SoapFormula.DAL.API.Repositories;

namespace SoapFormula.DAL.Repository
{ 
    public class Repository : IRepository
    {
        private readonly DbContext context;

        public Repository(DbContext context)
        {
            this.context = context;
        }

        public void Add<T>(T data) where T : class
        {
            this.context.Set<T>().Add(data);
        }

        public IQueryable<T> Get<T>() where T : class
        {
            return this.context.Set<T>();
        }

        public T Get<T>(int id) where T : class
        {
            return this.context.Set<T>().Find(id);
        }

        public void Delete<T>(int id) where T : class
        {
            this.context.Set<T>().Remove(this.context.Set<T>().Find(id));
        }

        public void Save()
        {
            this.context.SaveChanges();
        }
    }
}
