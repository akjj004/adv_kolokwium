using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kolokwium.ViewModels.VM;
using Kolokwium.Model.Models;
using System.Linq.Expressions;

namespace Kolokwium.ViewModels.Interfaces
{
    public interface IOrderService
    {
        OrderVm AddOrUpdateOrder(AddOrUpdateOrderVm addOrUpdateOrderVm);
        OrderVm GetOrder(Expression<Func<Order, bool>> filterExpression);
        IEnumerable<OrderVm> GetOrders(Expression<Func<Order, bool>>? filterExpression = null);

        bool DeleteOrder(Expression<Func<Order, bool>> filterExpression);
    }
}