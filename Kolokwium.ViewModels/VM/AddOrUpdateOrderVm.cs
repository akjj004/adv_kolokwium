using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Kolokwium.ViewModels.VM
{
    public class AddOrUpdateOrderVm
    {
        public int? Id { get; set; }
        [Required]
        public DateTime OrderDate { get; set; }
        [Required]
        public DateTime DeliveryDate { get; set; }

        [Required]
        public decimal TotalAmount { get; set; }

        [Required]
        public long TrackingNumber { get; set; }
    }
}