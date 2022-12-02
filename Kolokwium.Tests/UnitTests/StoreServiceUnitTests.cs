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
    public class StoreServiceUnitTests : BaseUnitTests
    {
        private readonly IStoreService _storeService;
        public StoreServiceUnitTests(ApplicationDbContext dbContext, IStoreService storeService) : base(dbContext)
        {
            _storeService = storeService;
        }
        [Fact]
        public void GetStoreTest()
        {
            var store = _storeService.GetStore(s => s.AgreementNumber == 1111);
            Assert.NotNull(store);
        }
        [Fact]
        public void GetMultipleStoresTest()
        {
            var stores = _storeService.GetStores(s => s.StationaryStoreId >= 1 && s.StationaryStoreId <= 2);
            Assert.NotNull(stores);
            Assert.NotEmpty(stores);
            Assert.Equal(2, stores.Count());
        }

        [Fact]

        public void GetAllStoresTest()
        {
            var stores = _storeService.GetStores();
            Assert.NotNull(stores);
            Assert.NotEmpty(stores);
            Assert.Equal(stores.Count(), stores.Count());
        }

        [Fact]

        public void AddNewStoreTest()
        {
            var newStoreVm = new AddOrUpdateStoreVm()
            {

                AgreementNumber = 1111
            };
            var createdStore = _storeService.AddOrUpdateStore(newStoreVm);
            Assert.NotNull(createdStore);
            Assert.Equal(1111, createdStore.AgreementNumber);

        }

        [Fact]

        public void UpdateStoreTest()
        {
            var updateStoreVm = new AddOrUpdateStoreVm()
            {

                AgreementNumber = 1111
            };
            var editedStoreVm = _storeService.AddOrUpdateStore(updateStoreVm);
            Assert.NotNull(editedStoreVm);
            Assert.Equal(1111, editedStoreVm.AgreementNumber);

        }
    }
}