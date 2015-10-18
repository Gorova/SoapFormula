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

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>()
                .HasMany(c => c.Products)
                .WithMany(p => p.Categories)
                .Map(m =>
                {
                    m.ToTable("ProductsCategories");
                    m.MapLeftKey("CategoryId");
                    m.MapRightKey("ProductId");
                }); 
        }
    }
}
