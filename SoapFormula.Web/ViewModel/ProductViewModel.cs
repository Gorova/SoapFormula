using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using SoapFormula.DAL.Entities;
using SoapFormula.Web.ViewModel.Interface;

namespace SoapFormula.Web.ViewModel
{
    public class ProductViewModel : IBaseViewModel
    {
        public int Id { get; set; }

        [DisplayName("NAME")]
        [Required(ErrorMessage = "Required '{0}' field")]
        [StringLength(20, ErrorMessage = "Max length of field '{0}' - 20 symbols")]
        public string Name { get; set; }

        [DisplayName("PRICE, UAH")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:N}")]
        [Required(ErrorMessage = "Required '{0}' field")]
        [Range(1.0, 1000.0, ErrorMessage = "The field '{0}' must be min 1 to 1000.00 and not be a negative number")]
        public decimal? Price { get; set; }

        [DisplayName("WEIGHT, gram")]
        [Required(ErrorMessage = "Required '{0}' field")]
        [Range(50, 1000, ErrorMessage = "The field '{0}' must be min 50gram and not be a negative number")]
        public int? Weight { get; set; }

        [DisplayName("MANUFACTURER")]
        [Required(ErrorMessage = "Required '{0}' field")]
        public int ManufacturerId { get; set; }
        
        public Manufacturer Manufacturer { get; set; }

        [DisplayName("CATEGORIES")]
        [Required(ErrorMessage = "Required '{0}' field")]
        public int[] SelectedCategoriesId { get; set; }

        public IEnumerable<SelectListItem> AllManufacturers { get; set; }

        public IEnumerable<SelectListItem> AllCategories { get; set; }
    }
}