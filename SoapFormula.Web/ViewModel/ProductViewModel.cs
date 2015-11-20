using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using SoapFormula.DAL.Entities;
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

        public Manufacturer Manufacturer { get; set; }

        public int[] SelectedIds { get; set; }

        public MultiSelectList CategoryItems { get; set; }

        public ICollection<Category> Categories { get; set; } 

        public IEnumerable<SelectListItem> FileItems { get; set; }

        public void Init(IRepository repository) 
        {
            ManufacturerItems = repository.Get<Manufacturer>()
                .Select(i => new SelectListItem
                {
                    Text = i.Name,
                    Value = i.Id.ToString()
                }).ToList();

            var categories = repository.Get<Category>()
                .Select(i => new {i.Id, i.Name}).ToList();
            CategoryItems = new MultiSelectList(categories, "Id", "Name");
        } 
    }
}