using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Kolokwium.Model.Models
{
    // will add the Category FK
    // 
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        [ForeignKey("CategoryId")]
        public int CategoryId { get; set; } = default!;
        public string Description { get; set; } = default!;
        public byte[] ImageBytes { get; set; } = default!;
        public string Name { get; set; } = default!;

        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }
        public virtual Supplier? Supplier { get; set; }
        [ForeignKey("SupplierId")]
        public int SupplierId { get; set; }
        public float Weight { get; set; }

        // one to many ProductStock
        public virtual ICollection<ProductStock>? ProductStocks { get; set; }
        // one to many OrderProduct
        public virtual ICollection<OrderProduct>? OrderProducts { get; set; }
    }
}