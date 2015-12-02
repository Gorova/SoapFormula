using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using SoapFormula.DAL.Entities;
using SoapFormula.Web.ViewModel.Interface;

namespace SoapFormula.Web.ViewModel
{
    public class ProductViewModel : IBaseViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public int Weight { get; set; }

        public int ManufacturerId { get; set; }

        public Manufacturer Manufacturer { get; set; }

        public int[] SelectedCategoriesId { get; set; }

        public IEnumerable<SelectListItem> AllManufacturers { get; set; }

        public IEnumerable<SelectListItem> AllCategories { get; set; }
    }
}