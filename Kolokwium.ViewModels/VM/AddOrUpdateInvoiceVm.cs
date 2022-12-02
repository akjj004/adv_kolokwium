using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Kolokwium.ViewModels.VM
{
    public class AddOrUpdateInvoiceVm
    {
        public int? Id { get; set; }
        [Required]
        public int InvoiceId { get; set; }
        [Required]
        public decimal TotalPrice { get; set; }
        [Required]
        public DateTime InvoiceDate { get; set; }
    }
}