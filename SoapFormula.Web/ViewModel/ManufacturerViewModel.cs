using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using SoapFormula.Common.Entities;
using SoapFormula.DAL.Repository.Interface;
using SoapFormula.Web.ViewModel.Interface;

namespace SoapFormula.Web.ViewModel
{
    public class ManufacturerViewModel : IBaseViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}