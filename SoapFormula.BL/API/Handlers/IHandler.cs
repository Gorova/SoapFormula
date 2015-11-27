using System.Collections.Generic;
using SoapFormula.Common.Interface;

namespace SoapFormula.BL.API.Handlers
{
    public interface IHandler<TDto> where TDto : class, IBase
    {
        TDto Get(int id);

        IEnumerable<TDto> Get();

        void Add(TDto data);

        void Update(TDto data);

        void Delete(int id);
    }
}
