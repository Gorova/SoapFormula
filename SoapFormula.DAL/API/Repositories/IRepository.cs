using System.Linq;

namespace SoapFormula.DAL.API.Repositories
{
    /// <summary>
    /// Defining an interface IRepository
    /// contains signatures of 5 generic methods
    /// type argument must be a reference type:
    /// return all entities as a quaryable collection, 
    /// return a single entity matching by Id, 
    /// adding into the DbSet,
    /// remove entity from DbSet,
    /// saving the changes to database
    /// </summary>
    public interface IRepository
    {
        /// <summary>
        /// Method add entities
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="data">Requires entity`s type argument</param>
        void Add<T>(T data) where T : class;

        /// <summary>
        /// Method Get return collection of entities
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns>Return IQueryable collection of entities</returns>
        IQueryable<T> Get<T>() where T : class;

        /// <summary>
        /// Method Get find single entity by Id
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="id">Requires integer argument</param>
        /// <returns>Return entity</returns>
        T Get<T>(int id) where T : class;

        /// <summary>
        /// Method Delete remove entity
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="id">Requires integer argument</param>
        void Delete<T>(int id) where T : class;

        /// <summary>
        /// Method Save saves the changes to database
        /// </summary>
        void Save();
    }
}
