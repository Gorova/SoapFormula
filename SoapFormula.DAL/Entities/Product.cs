using System.Collections.Generic;

namespace SoapFormula.DAL.Entities
{
    public class Product 
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public int Weight { get; set; }

        public int ManufacturerId { get; set; }

        public virtual Manufacturer Manufacturer { get; set; }

        public virtual ICollection<Category> Categories { get; set; }

        public virtual ICollection<File> Files { get; set; }
    }
}
