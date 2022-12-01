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
    public class StoreService : BaseService, IStoreService
    {
        public StoreService(ApplicationDbContext dbContext, IMapper mapper, ILogger logger) : base(dbContext, mapper, logger)
        {
        }

        public StoreVm AddOrUpdateStore(AddOrUpdateStoreVm addOrUpdateStoreVm)
        {
            try
            {
                if (addOrUpdateStoreVm == null)
                    throw new ArgumentNullException("View model parameter is null");
                var storeEntity = Mapper.Map<StationaryStore>(addOrUpdateStoreVm);
                if (addOrUpdateStoreVm.Id.HasValue || addOrUpdateStoreVm.Id == 0)
                    DbContext.StationaryStores.Update(storeEntity);
                else
                    DbContext.StationaryStores.Add(storeEntity);
                DbContext.SaveChanges();
                var storeVm = Mapper.Map<StoreVm>(storeEntity);
                return storeVm;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, ex.Message);
                throw;
            }
        }

        public bool DeleteStore(Expression<Func<StationaryStore, bool>> filterExpression)
        {
            throw new NotImplementedException();
        }

        public StoreVm GetStore(Expression<Func<StationaryStore, bool>> filterExpression)
        {
            try
            {
                if (filterExpression == null)
                    throw new ArgumentNullException("Filter expression parameter is null");
                var storeEntity = DbContext.StationaryStores.FirstOrDefault(filterExpression);
                var storeVm = Mapper.Map<StoreVm>(storeEntity);
                return storeVm;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, ex.Message);
                throw;
            }
        }

        public IEnumerable<StoreVm> GetStores(Expression<Func<StationaryStore, bool>>? filterExpression = null)
        {
            try
            {
                var storesQuery = DbContext.StationaryStores.AsQueryable();
                if (filterExpression != null)
                    storesQuery = storesQuery.Where(filterExpression);
                var storeVms = Mapper.Map<IEnumerable<StoreVm>>(storesQuery);
                return storeVms;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, ex.Message);
                throw;
            }
        }
    }
}