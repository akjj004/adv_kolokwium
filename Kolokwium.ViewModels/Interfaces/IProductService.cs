using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kolokwium.ViewModels.VM;
using Kolokwium.Model.Models;
using System.Linq.Expressions;

namespace Kolokwium.ViewModels.Interfaces
{
    public interface IProductService
    {
        ProductVm AddOrUpdateProduct(AddOrUpdateProductVm addOrUpdateProductVm);
        ProductVm GetProduct(Expression<Func<Product, bool>> filterExpression);
        IEnumerable<ProductVm> GetProducts(Expression<Func<Product, bool>>? filterExpression = null);
    }
}