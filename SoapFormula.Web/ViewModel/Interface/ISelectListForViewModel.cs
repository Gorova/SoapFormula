using System.Collections.Generic;
using System.Web.Mvc;
using SoapFormula.Common.Interface;
using SoapFormula.DAL.Repository.Interface;

namespace SoapFormula.Web.ViewModel.Interface
{
    public interface ISelectListForViewModel
    {
        IEnumerable<SelectListItem> Init<T> (IRepository repository) where T : class, IBase;
    }
}
