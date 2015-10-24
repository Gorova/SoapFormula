using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SoapFormula.Web.ViewModel
{
    public class ProductViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public int Weight { get; set; }

        public int ManufacturerId { get; set; }
    }
}