using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kolokwium.ViewModels.VM;
using Kolokwium.Model.Models;
using System.Linq.Expressions;

namespace Kolokwium.ViewModels.Interfaces
{
    public interface IAdressService
    {
        AdressVm AddOrUpdateAdress(AddOrUpdateAdressVm addOrUpdateAdress);
        AdressVm GetAdress(Expression<Func<Adress, bool>> filterExpression);
        IEnumerable<AdressVm> GetAdresses(Expression<Func<Adress, bool>>? filterExpression = null);
        public IEnumerable<AdressVm> DeleteAdress(Expression<Func<Adress, bool>> filterExpression);
    }
}