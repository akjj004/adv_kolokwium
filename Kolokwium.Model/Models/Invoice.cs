using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Kolokwium.Model.Models
{
    // id
    // decimal priceTotal
    // invoiceDate
    // Collection of Irder
    public class Invoice
    {
        [Key]
        public int InvoiceId { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal TotalPrice { get; set; }
        public DateTime InvoiceDate { get; set; }
        public virtual ICollection<Order>? Order { get; set; }
    }
}