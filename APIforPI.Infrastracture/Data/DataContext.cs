
using APIforPI.Infrastracture.Models;
using APIforPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace APIforPI.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            
        }
        
        public DbSet<Sets> Sets { get; set; }
        public DbSet<Sushi> Sushi { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Cart> Carts { get; set; }
        




        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Sets>()  // Sets и Sushi Many-to-Many
                .HasMany(c => c.Sushis)
                .WithMany(x => x.Sets)
                .UsingEntity(j => j.ToTable("SushisSets"));

            modelBuilder.Entity<Product>().UseTpcMappingStrategy(); //Подход Table Per Class

            modelBuilder.Entity<Sushi>()
                .ToTable(x => x.HasCheckConstraint("Price", "Price>200"));
            
        }
       
    }
}
