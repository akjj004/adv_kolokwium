using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Kolokwium.Model.Models
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }
        public DateTime DeliveryDate { get; set; }
        public DateTime OrderDate { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal TotalAmount { get; set; }
        public long TrackingNumber { get; set; }
        [ForeignKey("CustomerId")]
        public int CustomerId { get; set; }
        public virtual Customer? Customer { get; set; }
        [ForeignKey("Invoice")]
        public int Invoiceid { get; set; } = default!;
        public virtual Invoice? Invoice { get; set; }
        // one to many OrderProduct
        public virtual ICollection<OrderProduct>? OrderProducts { get; set; }
    }
}