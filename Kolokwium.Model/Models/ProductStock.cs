using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace Kolokwium.Model.Models
{
    public class ProductStock
    {
        // one to many
        // need id
        // add FK Product
        [Key]
        public int ProductStockId { get; set; }
        [ForeignKey("ProductId")]
        public int ProductId { get; set; }
        public virtual Product? Product { get; set; }
        public int Quantity { get; set; }
    }
}