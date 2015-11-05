using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using SoapFormula.Common.Entities;
using SoapFormula.Common.Interface;
using SoapFormula.DAL.Repository.Interface;
using SoapFormula.Web.ViewModel.Interface;

namespace SoapFormula.Web.ViewModel
{
    public class CategoryViewModel : IBaseViewModel, ISelectListForViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int ProductId { get; set; }

        public IEnumerable<SelectListItem> ProductItems { get; set; }

        public void Init(IRepository repository)
        {
            ProductItems = repository.Get<Product>()
                .Select(i => new SelectListItem
                {
                    Text = i.Name,
                    Value = i.Id.ToString()
                });
        } 
    }
}