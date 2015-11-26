using System.Collections.Generic;
using SoapFormula.Common.Interface;
using SoapFormula.DAL.Entities;

namespace SoapFormula.Common.DTO
{
    public class ProductDto : IBase
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public int Weight { get; set; }

        public int ManufacturerId { get; set; }

        public int[] SelectedIds { get; set; }

        public ICollection<Category> Categories { get; set; }

        public ICollection<File> Files { get; set; }

        public Manufacturer Manufacturer { get; set; }
    }
}
