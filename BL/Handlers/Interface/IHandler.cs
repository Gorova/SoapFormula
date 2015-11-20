using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SoapFormula.Common.Interface;

namespace BL.Handlers.Interface
{
    public interface IHandler
    {
        void Add(IBase data);

        IBase Get(int id);

        void Delete(int id);

        void Update(IBase data);

        IEnumerable<IBase> GetAll();
    }
}
