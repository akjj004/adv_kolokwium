// using System;
// using System.Collections.Generic;
// using System.Linq;
// using System.Threading.Tasks;
// using Kolokwium.DAL;
// using Kolokwium.ViewModels.Interfaces;
// using Kolokwium.ViewModels.VM;
// using Xunit;

// namespace Kolokwium.Tests.UnitTests
// {
//     public class AddressServiceUnitTest : BaseUnitTests
//     {
//         // add filed
//         private readonly IAdressService _adressService;
//         public AddressServiceUnitTest(ApplicationDbContext dbContext, IAdressService adressService) : base(dbContext)
//         {
//             _adressService = adressService;
//         }

//         [Fact]
//         public void GetAddressTest()
//         {

//             var address = _adressService.GetAdress(c => c.City == "Markqo");
//             Assert.NotNull(address);
//         }

//         // [Fact]
//         // public void GetMultipleAddressTest()
//         // {
//         //     var addresses = _adressService.GetAdresses(a => a.AdressId >= 1 && a.AdressId <= 2);
//         //     Assert.NotNull(addresses);
//         //     Assert.NotEmpty(addresses);
//         //     Assert.Equal(2, addresses.Count());
//         // }

//         // [Fact]
//         // public void GetAllAddressTest()
//         // {
//         //     var addresses = _adressService.GetAdresses();
//         //     Assert.NotNull(addresses);
//         //     Assert.NotEmpty(addresses);
//         //     Assert.Equal(addresses.Count(), addresses.Count());
//         // }

//         // [Fact]
//         // public void AddNewAddressTest()
//         // {
//         //     var newAddressVm = new AddOrUpdateAdressVm
//         //     {
//         //         City = "Monahium",
//         //         StreetName = "Shaise",
//         //         PostCode = "93821"
//         //     };
//         //     var createAddress = _adressService.AddOrUpdateAdress(newAddressVm);
//         //     Assert.NotNull(createAddress);
//         //     Assert.Equal("Shaise", createAddress.StreetName);
//         // }

//         // [Fact]
//         // public void UpdateAddressTest()
//         // {
//         //     var updateAddressVm = new AddOrUpdateAdressVm()
//         //     {
//         //         Id = 2,
//         //         City = "Ludz",
//         //         StreetName = "Piracka",
//         //         PostCode = "85612"
//         //     };

//         //     var editedAddressVm = _adressService.AddOrUpdateAdress(updateAddressVm);
//         //     Assert.NotNull(editedAddressVm);
//         //     Assert.Equal(85612, editedAddressVm.PostCode);
//         // }

//         // [Fact]
//         // public void DeleteAddressTest()
//         // {
//         //     var changeAddresses = _adressService.DeleteAdress(a => a.AdressId == 1);
//         //     Assert.Equal(1, changeAddresses.Count());
//         // }

//     }
// }