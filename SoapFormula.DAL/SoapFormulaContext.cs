using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SoapFormula.Common.Entities;

namespace SoapFormula.DAL
{
    public class SoapFormulaContext : DbContext
    {
        public SoapFormulaContext() 
            : base("SoapFormula")
        {
        }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<File> Files { get; set; }
    }
}
