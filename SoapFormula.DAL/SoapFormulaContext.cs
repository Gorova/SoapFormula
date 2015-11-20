using System.Data.Entity;
using SoapFormula.DAL.Entities;

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

        public DbSet<Manufacturer> Manufacturers { get; set; } 

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

            modelBuilder.Entity<Product>()
                .HasRequired<Manufacturer>(i => i.Manufacturer)
                .WithMany(i => i.Products)
                .HasForeignKey(i => i.ManufacturerId);
        }
    }
}
