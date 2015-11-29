using System.Collections.Generic;
using SoapFormula.Common.Interface;

namespace SoapFormula.BL.API.Handlers
{
    /// <summary>
    /// Defining of generic interface IHandler
    /// contains signatures of 5 generic methods
    /// with reference type parameters:
    /// get all entities, get single entity,
    /// adding, edition and deleting of entity
    /// </summary>
    /// <typeparam name="TDto">Requires reference type of parameter
    /// and implement IBase interface </typeparam>
    public interface IHandler<TDto> where TDto : class, IBase
    {
        /// <summary>
        /// Method Get finds single entity by Id
        /// </summary>
        /// <param name="id">Requires integer argument</param>
        /// <returns>Return entity</returns>
        TDto Get(int id);

        /// <summary>
        /// Method Get returns collection of entities
        /// </summary>
        /// <returns>Return IEnumerable collection of entities</returns>
        IEnumerable<TDto> Get();

        /// <summary>
        /// Method Add adds entities
        /// </summary>
        /// <param name="data">Requires entity`s type argument</param>
        void Add(TDto data);

        /// <summary>
        /// Method Update saves modified entity 
        /// </summary>
        /// <param name="data">Requires entity`s type argument</param>
        void Update(TDto data);

        /// <summary>
        /// Method Delete remove entity
        /// </summary>
        /// <param name="id">Requires integer argument</param>
        void Delete(int id);
    }
}
