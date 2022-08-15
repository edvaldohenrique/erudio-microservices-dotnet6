using Microsoft.EntityFrameworkCore;

namespace GeekShooping.ProductAPI.Model.Context
{
    public class MySqlContext : DbContext
    {
        public MySqlContext()
        {

        }

        public MySqlContext(DbContextOptions<MySqlContext> options) : base(options) { } 

        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData(
                new Product()
                {
                    Id = 2,
                    Name = "Caderno",
                    CategoryName = "Papelaria",
                    Price = new decimal(10.90),
                    Description = "Caderno de escrever",
                    ImagemUrl = ""
                });
            modelBuilder.Entity<Product>().HasData(
                new Product()
                {
                    Id = 3,
                    Name = "Caneta azul",
                    CategoryName = "Papelaria",
                    Price = new decimal(2.50),
                    Description = "Caneta de escrever",
                    ImagemUrl = ""
                });
            modelBuilder.Entity<Product>().HasData(
                new Product()
                {
                    Id = 4,
                    Name = "Caneta Vermelha",
                    CategoryName = "Papelaria",
                    Price = new decimal(2.50),
                    Description = "Caneta de escrever",
                    ImagemUrl = ""
                });
        }
    }
}
