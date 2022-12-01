using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Kolokwium.ViewModels.VM
{
    public class AddOrUpdateAdressVm
    {
        public int? Id { get; set; }
        [Required]
        public string StreetName { get; set; } = default!;
        [Required]
        public int StreetNumber { get; set; }
        [Required]
        public string City { get; set; } = default!;
        [Required]
        public string PostCode { get; set; } = default!;
    }
}