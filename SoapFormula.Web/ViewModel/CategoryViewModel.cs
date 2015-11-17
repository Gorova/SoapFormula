using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using SoapFormula.Common.Entities;
using SoapFormula.DAL.Repository.Interface;
using SoapFormula.Web.ViewModel.Interface;

namespace SoapFormula.Web.ViewModel
{
    public class CategoryViewModel : IBaseViewModel, ISelectListForViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int [] SelectedIds { get; set; }

        public MultiSelectList ProductItems { get; set; }

        public ICollection<Product> Products { get; set; } 

        public void Init(IRepository repository)
        {
            var products = repository.Get<Product>()
                .Select(i => new {i.Id, i.Name});
            ProductItems = new MultiSelectList(products, "Id", "Name");
        } 
    }
}