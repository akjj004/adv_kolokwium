using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
namespace Kolokwium.Model.Models
{
    // M : M Relations Order && Product
    public class OrderProduct
    {
        [ForeignKey("OrderId")]
        public int OrderId { get; set; }
        public virtual Order? Order { get; set; }
        [ForeignKey("ProductId")]
        public int ProductId { get; set; }
        public virtual Product? Product { get; set; }
        public int Quantity { get; set; }
    }
}