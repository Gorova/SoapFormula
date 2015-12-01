using System.Collections.Generic;
using SoapFormula.DAL.Entities;
using SoapFormula.Web.ViewModel.Interface;

namespace SoapFormula.Web.ViewModel
{
    public class ManufacturerViewModel : IBaseViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}