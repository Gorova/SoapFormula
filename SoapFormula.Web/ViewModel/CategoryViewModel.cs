using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SoapFormula.Web.ViewModel.Interface;

namespace SoapFormula.Web.ViewModel
{
    public class CategoryViewModel : IBaseViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}