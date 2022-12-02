using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kolokwium.DAL;
using Kolokwium.ViewModels.Interfaces;
using Kolokwium.ViewModels.VM;
using Xunit;

namespace Kolokwium.Tests.UnitTests
{
    // impl field
    
    public class AddressServiceUnitTest : BaseUnitTests
    {
        private readonly IAddressService _addressService;
        public AddressServiceUnitTest(ApplicationDbContext dbContext, IAddressService addressService) : base(dbContext)
        {
            _addressService = addressService;
        }

        [Fact]
        public void GetAdressTest()
        {
           var adress = _addressService.GetAddress(a => a.StreetName == "test");
           Assert.NotNull(adress);
        }
         [Fact] 
        public void GetMultipleAddressTest () { 
            var addresses = _addressService.GetAddresses (a => a.AddressId >= 1 && a.AddressId <= 2); 
            Assert.NotNull (addresses); 
            Assert.NotEmpty (addresses); 
            Assert.Equal (2, addresses.Count ()); 
        } 

        [Fact] 
        
        public void GetAllAddressTest () { 
            var addresses = _addressService.GetAddresses (); 
            Assert.NotNull (addresses); 
            Assert.NotEmpty (addresses); 
            Assert.Equal (addresses.Count (), addresses.Count ()); 
        } 
        
        [Fact] 
        
        public void AddNewAddressTest () { 
            var newAddressVm = new AddOrUpdateAddressVm () { 
                Id = 1,
                StreetName = "test",
                StreetNumber = 12,
                City = "test",
                PostCode = 98300
            }; 
                var createdAddress = _addressService.AddOrUpdateAddress (newAddressVm); 
                Assert.NotNull (createdAddress); 
                Assert.Equal ("test", createdAddress.StreetName); 
                
        }

        [Fact]

        public void UpdateAddressTest () { 
            var updateAddressVm = new AddOrUpdateAddressVm () { 
                Id = 1,
                StreetName = "test",
                StreetNumber = 23,
                City = "test",
                PostCode = 98300
            }; 
            var editedAddressVm = _addressService.AddOrUpdateAddress (updateAddressVm); 
            Assert.NotNull (editedAddressVm); 
            Assert.Equal ("test", editedAddressVm.StreetName); 
            Assert.Equal (23, editedAddressVm.StreetNumber); 
        } 
    }
}