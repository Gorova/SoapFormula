using System.Linq;

namespace SoapFormula.DAL.API.Repositories
{
    /// <summary>
    /// Contains signatures of 5 generic methods: 
    /// return all, single entity, add, remove and save changes
    /// </summary>
    public interface IRepository
    {
        /// <summary>
        /// Add entity
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="data">Entity`s type argument</param>
        void Add<T>(T data) where T : class;

        /// <summary>
        /// Get all entities
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns>Return IQueryable collection of entities</returns>
        IQueryable<T> Get<T>() where T : class;

        /// <summary>
        /// Get single entity
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="id">Integer argument</param>
        /// <returns>Return entity</returns>
        T Get<T>(int id) where T : class;

        /// <summary>
        /// Delete entity
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="id">Integer argument</param>
        void Delete<T>(int id) where T : class;

        /// <summary>
        /// Save changes to database
        /// </summary>
        void Save();
    }
}
