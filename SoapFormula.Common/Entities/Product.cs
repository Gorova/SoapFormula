using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoapFormula.Common.Entities
{
    public class Product
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public int Weight { get; set; }

        public virtual ICollection<Category> Categories { get; set; }

        public virtual ICollection<File> Files { get; set; } 
    }
}
