using System.Data.Entity;
using System.Linq;
using SoapFormula.DAL.API.Repositories;

namespace SoapFormula.DAL.Repositories
{ 
    /// <summary>
    /// Class Repository with IRepository implementation
    /// contains methods uses EF data context
    /// for queries and other database oparation
    /// </summary>
    public class Repository : IRepository
    {
        private readonly DbContext context;
        /// <summary>
        /// Constructor dependency injection 
        /// </summary>
        /// <param name="context">Data context instance</param>
        public Repository(DbContext context)
        {
            this.context = context;
        }

        /// <summary>
        /// Add entity
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="data">Entity`s type argument</param>
        public void Add<T>(T data) where T : class
        {
            this.context.Set<T>().Add(data);
        }

        /// <summary>
        /// Get all entities
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns>Return IQueryable collection of entities</returns>
        public IQueryable<T> Get<T>() where T : class
        {
            return this.context.Set<T>();
        }

        /// <summary>
        /// Get single entity
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="id">Integer argument</param>
        /// <returns>Return entity</returns>
        public T Get<T>(int id) where T : class
        {
            return this.context.Set<T>().Find(id);
        }

        /// <summary>
        /// Delete entity
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="id">Integer argument</param>
        public void Delete<T>(int id) where T : class
        {
            this.context.Set<T>().Remove(this.context.Set<T>().Find(id));
        }

        /// <summary>
        /// Save changes to database
        /// </summary>
        public void Save()
        {
            this.context.SaveChanges();
        }
    }
}
