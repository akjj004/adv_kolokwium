using Kolokwium.Model.Models;
using Microsoft.EntityFrameworkCore;


namespace Kolokwium.DAL
{
    // first add UserIdentity
    // add rel OrderProduct
    // add DbSet Prop
    // add virtal lazy loading
    // we dont add users ex. customer, supplayer, stationaryStoreEmployeer
    public class ApplicationDbContext : DbContext
    {
        // add properites into Db
        public virtual DbSet<Category>? Categories { get; set; }
        public virtual DbSet<Product>? Products { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseLazyLoadingProxies();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // example of using Fluent API instead of attributes // to limit the length of a category name to 15 
            modelBuilder.Entity<Category>()
            .Property(category => category.CategoryName).IsRequired() // NOT NULL
            .HasMaxLength(15);
        }


    }
}
