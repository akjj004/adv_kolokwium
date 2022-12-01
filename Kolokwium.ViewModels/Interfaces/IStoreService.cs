using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kolokwium.ViewModels.VM;
using Kolokwium.Model.Models;
using System.Linq.Expressions;

namespace Kolokwium.ViewModels.Interfaces
{
    public interface IStoreService
    {
        StoreVm AddOrUpdateStore(AddOrUpdateStoreVm addOrUpdateStore);
        StoreVm GetStore(Expression<Func<StationaryStore, bool>> filterExpression);
        IEnumerable<StoreVm> GetStores(Expression<Func<StationaryStore, bool>>? filterExpression = null);
        bool DeleteStore(Expression<Func<StationaryStore, bool>> filterExpression);
    }
}