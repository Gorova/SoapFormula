using System.Collections.Generic;
using SoapFormula.Common.Interface;

namespace SoapFormula.BL.API.Handlers
{
    /// <summary>
    /// defining of generic interface
    /// type argument is reference type 
    /// and implement IBase interfase
    /// contains signatures of 5 generic methods
    /// with reference type parameters:
    /// get all entities, get single entity,
    /// adding, edition and deleting of entity
    /// </summary>
    /// <typeparam name="TDto"></typeparam>
    public interface IHandler<TDto> where TDto : class, IBase
    {
        TDto Get(int id);

        IEnumerable<TDto> Get();

        void Add(TDto data);

        void Update(TDto data);

        void Delete(int id);
    }
}
