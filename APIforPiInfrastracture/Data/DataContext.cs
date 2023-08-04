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
      
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Sets>()
                .HasMany(c => c.Sushis)
                .WithMany(x => x.Sets)
                .UsingEntity(j => j.ToTable("SushisSets"));
                
        }
       
    }
}
