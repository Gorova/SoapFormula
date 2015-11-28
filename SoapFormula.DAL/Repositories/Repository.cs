using System.Data.Entity;
using System.Linq;
using SoapFormula.DAL.API.Repositories;

namespace SoapFormula.DAL.Repositories
{ 
    /// <summary>
    /// class with IRepository implementation
    /// contains methods uses EF data context
    /// for queries and other database oparation
    /// </summary>
    public class Repository : IRepository
    {
        private readonly DbContext context;
        /// <summary>
        /// constructor dependency injection 
        /// that accepts the data context instance 
        /// </summary>
        /// <param name="context"></param>
        public Repository(DbContext context)
        {
            this.context = context;
        }
        /// <summary>
        /// generic method with reference type parameters
        /// accepts entity and adds it to the table of DbSet
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="data"></param>
        public void Add<T>(T data) where T : class
        {
            this.context.Set<T>().Add(data);
        }
        /// <summary>
        /// generic method with reference type parameters
        /// method is intended to return all entities as an queryable
        /// collection
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public IQueryable<T> Get<T>() where T : class
        {
            return this.context.Set<T>();
        }
        /// <summary>
        /// generic method with reference type parameters
        /// method accepts an id representing a entity
        /// and returns a single entity matching that id
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="id"></param>
        /// <returns></returns>
        public T Get<T>(int id) where T : class
        {
            return this.context.Set<T>().Find(id);
        }
        /// <summary>
        /// generic method with reference type parameters
        /// method accepts an id and removes that entity from the DbSet
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="id"></param>
        public void Delete<T>(int id) where T : class
        {
            this.context.Set<T>().Remove(this.context.Set<T>().Find(id));
        }
        /// <summary>
        /// method saves the changes to database
        /// </summary>
        public void Save()
        {
            this.context.SaveChanges();
        }
    }
}
