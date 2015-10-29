using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SoapFormula.Common.Interface;

namespace SoapFormula.Common.Entities
{
    public class Product : IBase
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public int Weight { get; set; }

        public int ManufacturerId { get; set; }

        public virtual ICollection<Category> Categories { get; set; }

        public virtual ICollection<File> Files { get; set; }

        public virtual Manufacturer Manufacturer { get; set; }
    }
}
