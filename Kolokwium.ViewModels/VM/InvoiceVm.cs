using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kolokwium.ViewModels.VM
{
    public class InvoiceVm
    {
        public decimal totalPrice { get; set; }
        public DateTime invoiceDate { get; set; }
    }
}