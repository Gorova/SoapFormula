using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Web.Mvc;
using SoapFormula.Common.Entities;
using SoapFormula.Common.Interface;
using SoapFormula.DAL.Repository.Interface;
using SoapFormula.Web.ViewModel.Interface;

namespace SoapFormula.Web.ViewModel
{
    public class ProductViewModel : IBaseViewModel, ISelectListForViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public int Weight { get; set; }

        public int ManufacturerId { get; set; }

        public IEnumerable<SelectListItem> ManufacturerItems { get; set; }

        public MultiSelectList CategoryItems { get; set; }

        public int[] CategoryId { get; set; }

        public IEnumerable<SelectListItem> FileItems { get; set; }

        public void Init(IRepository repository) 
        {
            ManufacturerItems = repository.Get<Manufacturer>()
                .Select(i => new SelectListItem
                {
                    Text = i.Name,
                    Value = i.Id.ToString(),
                    
                });

            var categories = repository.Get<Category>()
                .Select(i => new {Id = i.Id, Name = i.Name}).ToList();
            CategoryItems = new MultiSelectList(categories, "Id", "Name");
        } 
    }
}