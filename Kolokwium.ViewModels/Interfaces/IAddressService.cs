using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kolokwium.ViewModels.VM;
using Kolokwium.Model.Models;
using System.Linq.Expressions;

namespace Kolokwium.ViewModels.Interfaces
{
    public interface IAddressService
    {
        AddressVm AddOrUpdateAddress(AddOrUpdateAddressVm addOrUpdateAddressVm);
        AddressVm GetAddress(Expression<Func<Address, bool>> filterExpression);
        IEnumerable<AddressVm> GetAddresses(Expression<Func<Address, bool>>? filterExpression = null);
        bool DeleteAdress(Expression<Func<Address, bool>> filterExpression);
    }
}