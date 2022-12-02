using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AutoMapper;
using Kolokwium.DAL;
using Kolokwium.Model.Models;
using Kolokwium.ViewModels.Interfaces;
using Kolokwium.ViewModels.VM;
using Microsoft.Extensions.Logging;

namespace Kolokwium.Services.ConcreteServices
{

    public class AddressService : BaseService, IAddressService
    {
        public AddressService(ApplicationDbContext dbContext, IMapper mapper, ILogger logger) : base(dbContext, mapper, logger)
        {
        }

        public AddressVm AddOrUpdateAddress(AddOrUpdateAddressVm addOrUpdateAddressVm)
        {
            try
            {
                if (addOrUpdateAddressVm == null) throw new ArgumentNullException("View Model parameter is null");
                var addressEntity = Mapper.Map<Address>(addOrUpdateAddressVm);
                if (addOrUpdateAddressVm.Id.HasValue || addOrUpdateAddressVm.Id == 0)
                    DbContext.Addresses.Update(addressEntity);
                else DbContext.Addresses.Add(addressEntity);
                DbContext.SaveChanges();
                var addressVm = Mapper.Map<AddressVm>(addressEntity);
                return addressVm;

            }
            catch (Exception ex)
            {
                Logger.LogError(ex, ex.Message);
                throw;
            }
        }

        public bool DeleteAdress(Expression<Func<Address, bool>> filterExpression)
        {
            throw new NotImplementedException();
        }

        public AddressVm GetAddress(Expression<Func<Address, bool>> filterExpression)
        {
            try
            {
                if(filterExpression == null) throw new ArgumentNullException("Filter param is null");
                var addressEntity = DbContext.Addresses.FirstOrDefault(filterExpression);
                var addressVm = Mapper.Map<AddressVm>(addressEntity);
                return addressVm;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, ex.Message);
                throw;
            }
        }

        public IEnumerable<AddressVm> GetAddresses(Expression<Func<Address, bool>>? filterExpression = null)
        {
            try
            {
                var addressQuery = DbContext.Addresses.AsQueryable();
                if(filterExpression != null) addressQuery = addressQuery.Where(filterExpression);
                var addressVm = Mapper.Map<IEnumerable<AddressVm>>(addressQuery);
                return addressVm;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, ex.Message);
                throw;
            }
        }
    }

}