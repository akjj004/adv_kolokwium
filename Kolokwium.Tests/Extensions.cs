using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kolokwium.DAL;
using Kolokwium.Model.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace Kolokwium.Tests
{
    public static class Extensions
    {
        // Create sample data
        public static async void SeedData(this IServiceCollection services)
        {
            var serviceProvider = services.BuildServiceProvider();
            var dbContext = serviceProvider.GetRequiredService<ApplicationDbContext>();
            var userManager = serviceProvider.GetRequiredService<UserManager<User>>();
            var roleManager = serviceProvider
        .GetRequiredService<RoleManager<IdentityRole<int>>>();
            // other seed data ...
            //Suppliers
            // other seed data ... 

            //Suppliers 
            var supplier1 = new Supplier()
            {
                Id = 1,
                FirstName = "Adam",
                LastName = "Bednarski",
                UserName = "supp1@eg.eg",
                Email = "supp1@eg.eg",
                RegistrationDate = new DateTime(2010, 1, 1),
            };
            await userManager.CreateAsync(supplier1, "User1234");

            //Categories 
            var category1 = new Category()
            {
                CategoryId = 1,
                Name = "Computers",
                Tag = "#computer"
            };
            await dbContext.AddAsync(category1);

            //Products 
            var p1 = new Product()
            {
                ProductId = 1,
                CategoryId = category1.CategoryId,
                SupplierId = supplier1.Id,
                Description = "Bardzo praktyczny monitor 32 cale",
                ImageBytes = new byte[] { 0xff, 0xff, 0xff, 0x80 },
                Name = "Monitor Dell 32",
                Price = 1000,
                Weight = 20,
            };
            await dbContext.AddAsync(p1);

            var p2 = new Product()
            {
                ProductId = 2,
                CategoryId = category1.CategoryId,
                SupplierId = supplier1.Id,
                Description = "Precyzyjna mysz do pracy",
                ImageBytes = new byte[] { 0xff, 0xff, 0xff, 0x70 },
                Name = "Mysz Logitech",
                Price = 500,
                Weight = 0.5f,
            };
            await dbContext.AddAsync(p2);

            //Invoice
            var i1 = new Invoice()
            {

                InvoiceId = 1,
                TotalPrice = 10,
                InvoiceDate = new DateTime()
            };
            await dbContext.AddAsync(i1);
            var i2 = new Invoice()
            {

                InvoiceId = 2,
                TotalPrice = 20,
                InvoiceDate = new DateTime()
            };
            await dbContext.AddAsync(i2);

            //Address

            var a1 = new Address()
            {
                AddressId = 1,
                StreetName = "test",
                StreetNumber = 12,
                City = "test",
                PostCode = 98300

            };
            await dbContext.AddAsync(a1);
            var a2 = new Address()
            {
                AddressId = 2,
                StreetName = "test",
                StreetNumber = 14,
                City = "test",
                PostCode = 93400

            };
            await dbContext.AddAsync(a2);
            var a3 = new Address()
            {
                AddressId = 3,
                StreetName = "test",
                StreetNumber = 23,
                City = "test",
                PostCode = 93600

            };
            await dbContext.AddAsync(a3);

            //Order

            var o1 = new Order()
            {
                OrderId = 1,
                DeliveryDate = new DateTime(),
                OrderDate = new DateTime(),
                TotalAmount = 1987.89m,
                TrackingNumber = 876677,
                InvoiceId = 234,
                CustomerId = 1
            };
            await dbContext.AddAsync(o1);

            var o2 = new Order()
            {
                OrderId = 2,
                DeliveryDate = new DateTime(),
                OrderDate = new DateTime(),
                TotalAmount = 2111.89m,
                TrackingNumber = 34343,
                InvoiceId = 543,
                CustomerId = 3
            };
            await dbContext.AddAsync(o2);

            //Stores

            var s1 = new StationaryStore()
            {


                AgreementNumber = 1111


            };
            await dbContext.AddAsync(s1);

            var s2 = new StationaryStore()
            {


                AgreementNumber = 2222
            };
            await dbContext.AddAsync(s2);
            // save changes

            // save changes
            await dbContext.SaveChangesAsync();
        }
    }
}
