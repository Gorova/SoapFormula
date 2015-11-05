using System.Collections.Generic;
using SoapFormula.Common.Interface;

namespace SoapFormula.Common.Entities
{
    public class Manufacturer : IBase
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
