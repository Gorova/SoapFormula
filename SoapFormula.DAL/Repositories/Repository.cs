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
        /// <param name="context">Requires the data context instance</param>
        public Repository(DbContext context)
        {
            this.context = context;
        }

        /// <summary>
        /// Generic method Add with reference type parameters
        /// adds it to the table of DbSet
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="data">Requires entity </param>
        public void Add<T>(T data) where T : class
        {
            this.context.Set<T>().Add(data);
        }

        /// <summary>
        /// Generic method Get with reference type parameters
        /// method is intended to return all entities as an queryable
        /// collection
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns>Return IQueryable collection of entities</returns>
        public IQueryable<T> Get<T>() where T : class
        {
            return this.context.Set<T>();
        }

        /// <summary>
        /// Generic method Get with reference type parameters
        /// finds single entity by Id
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="id">Requires integer argument</param>
        /// <returns>Return entity</returns>
        public T Get<T>(int id) where T : class
        {
            return this.context.Set<T>().Find(id);
        }

        /// <summary>
        /// Generic method Delete with reference type parameters
        /// remove entity from the DbSet
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="id">Requires integer argument</param>
        public void Delete<T>(int id) where T : class
        {
            this.context.Set<T>().Remove(this.context.Set<T>().Find(id));
        }

        /// <summary>
        /// Method Save saves the changes to database
        /// </summary>
        public void Save()
        {
            this.context.SaveChanges();
        }
    }
}
