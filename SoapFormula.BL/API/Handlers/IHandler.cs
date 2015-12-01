using System.Collections.Generic;
using SoapFormula.Common.Interface;

namespace SoapFormula.BL.API.Handlers
{
    /// <summary>
    /// Contains signatures of 5 generic method for DbSet entities: get entities, 
    /// get single entity, add, edit, delete
    /// </summary>
    /// <typeparam name="TDto">Reference and IBase implement type </typeparam>
    public interface IHandler<TDto> where TDto : class, IBase
    {
        /// <summary>
        /// Get single entity 
        /// </summary>
        /// <param name="id">Integer argument</param>
        /// <returns>Return entity</returns>
        TDto Get(int id);

        /// <summary>
        /// Get all entities
        /// </summary>
        /// <returns>Return IEnumerable collection of entities</returns>
        IEnumerable<TDto> Get();

        /// <summary>
        /// Add entity
        /// </summary>
        /// <param name="data">Entity`s type argument</param>
        void Add(TDto data);

        /// <summary>
        /// Save modified entity 
        /// </summary>
        /// <param name="data">Entity`s type argument</param>
        void Update(TDto data);

        /// <summary>
        /// Remove entity
        /// </summary>
        /// <param name="id">Integer argument</param>
        void Delete(int id);
    }
}
