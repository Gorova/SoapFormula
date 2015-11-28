using System.Linq;

namespace SoapFormula.DAL.API.Repositories
{
    /// <summary>
    /// defining an interface 
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
        void Add<T>(T data) where T : class;

        IQueryable<T> Get<T>() where T : class;

        T Get<T>(int id) where T : class;

        void Delete<T>(int id) where T : class;

        void Save();
    }
}
