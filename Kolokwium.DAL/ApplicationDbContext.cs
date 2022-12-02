using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Kolokwium.Model.Models;


namespace Kolokwium.DAL
{
    // first add UserIdentity
    // add rel OrderProduct
    // add DbSet Prop
    // add virtal lazy loading
    // we dont add users ex. customer, supplayer, stationaryStoreEmployeer
    public class ApplicationDbContext : IdentityDbContext<User, IdentityRole<int>, int>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseLazyLoadingProxies();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // one to many rel Order Product
            modelBuilder.Entity<OrderProduct>().HasKey(o => new { o.ProductId, o.OrderId });
            // we will need to add one to many because of FK
            // first start with product to OrderProducts set to productId
            modelBuilder.Entity<OrderProduct>().HasOne(p => p.Product).WithMany(op => op.OrderProducts).HasForeignKey(p => p.ProductId).OnDelete(DeleteBehavior.Restrict);
            // second start with order
            modelBuilder.Entity<OrderProduct>().HasOne(o => o.Order).WithMany(op => op.OrderProducts).HasForeignKey(o => o.OrderId).OnDelete(DeleteBehavior.Restrict);
            // stationary employee store one to many
            modelBuilder.Entity<StationaryStoreEmployee>().HasOne(ss => ss.StationaryStore).WithMany(sse => sse.StationaryStoreEmployees).HasForeignKey(ss => ss.StationaryStoreId).OnDelete(DeleteBehavior.Restrict);
            // add UserRoles
            modelBuilder.Entity<User>()
            .ToTable("AspNetUsers")
            .HasDiscriminator<int>("UserType")
            .HasValue<User>(0)
            .HasValue<Customer>(1)
            .HasValue<Supplier>(2)
            .HasValue<StationaryStoreEmployee>(3);
        }

        public virtual DbSet<Address> Addresses { get; set; } = default!;
        public virtual DbSet<Category> Categories { get; set; } = default!;
        public virtual DbSet<Invoice> Invoices { get; set; } = default!;
        public virtual DbSet<Order> Orders { get; set; } = default!;
        public virtual DbSet<OrderProduct> OrderProducts { get; set; } = default!;
        public virtual DbSet<ProductStock> ProductStocks { get; set; } = default!;
        public virtual DbSet<Product> Products { get; set; } = default!;
        public virtual DbSet<StationaryStore> StationaryStores { get; set; } = default!;
    }
}
