using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using SoapFormula.Web.ViewModel.Interface;

namespace SoapFormula.Web.ViewModel
{
    public class CategoryViewModel : IBaseViewModel
    {
        public int Id { get; set; }

        [DisplayName("NAME")]
        [Required(ErrorMessage = "Required '{0}' field")]
        [StringLength(20, ErrorMessage = "Max length of field '{0}'- 20 symbols")]
        public string Name { get; set; }
    }
}