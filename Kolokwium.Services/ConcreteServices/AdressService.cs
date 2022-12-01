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
    public class AddressService : BaseService, IAdressService
    {
        public AddressService(ApplicationDbContext dbContext, IMapper mapper, ILogger logger) : base(dbContext, mapper, logger)
        {
        }

        public AdressVm AddOrUpdateAdress(AddOrUpdateAdressVm addOrUpdateAdressVm)
        {
            try
            {
                if (addOrUpdateAdressVm == null)
                    throw new ArgumentNullException("View model parameter is null");
                var adressEntity = Mapper.Map<Adress>(addOrUpdateAdressVm);
                if (addOrUpdateAdressVm.Id.HasValue || addOrUpdateAdressVm.Id == 0)
                    DbContext.Adresses.Update(adressEntity);
                else
                    DbContext.Adresses.Add(adressEntity);
                DbContext.SaveChanges();
                var adressVm = Mapper.Map<AdressVm>(adressEntity);
                return adressVm;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, ex.Message);
                throw;
            }
        }

        public IEnumerable<AdressVm> GetAddresses(Expression<Func<Adress, bool>>? filterExpression = null)
        {
            try
            {
                var adressQuery = DbContext.Adresses.AsQueryable();
                if (filterExpression != null)
                    adressQuery = adressQuery.Where(filterExpression);
                var adressVms = Mapper.Map<IEnumerable<AdressVm>>(adressQuery);
                return adressVms;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, ex.Message);
                throw;
            }
        }

        public AdressVm GetAdress(Expression<Func<Adress, bool>> filterExpression)
        {
            try
            {
                if (filterExpression == null)
                    throw new ArgumentNullException("Filter expression parameter is null");
                var adressEntity = DbContext.Adresses.FirstOrDefault(filterExpression);
                var adressVm = Mapper.Map<AdressVm>(adressEntity);
                return adressVm;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, ex.Message);
                throw;
            }
        }
    }
}