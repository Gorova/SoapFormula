using System.Collections.Generic;
using SoapFormula.Common.Interface;
using SoapFormula.DAL.Entities;

namespace SoapFormula.Common.DTO
{
    public class CategoryDto : IBase
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
