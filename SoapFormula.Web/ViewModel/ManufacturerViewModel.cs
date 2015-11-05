using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using SoapFormula.Common.Entities;
using SoapFormula.Common.Interface;
using SoapFormula.DAL.Repository.Interface;
using SoapFormula.Web.ViewModel.Interface;

namespace SoapFormula.Web.ViewModel
{
    public class ManufacturerViewModel : IBaseViewModel, ISelectListForViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public IEnumerable<SelectListItem> Products { get; set; }

        public void Init(IRepository repository)
        {
            Products = repository.Get<Product>()
                .Select(i => new SelectListItem
                {
                    Text = i.Name,
                    Value = i.Id.ToString()
                });
        } 
    }
}