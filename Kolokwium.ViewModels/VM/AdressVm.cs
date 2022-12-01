using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kolokwium.ViewModels.VM
{
    public class AdressVm
    {
        public string StreetName { get; set; } = default!;
        public int StreetNumber { get; set; } = default!;
        public string City { get; set; } = default!;
        public int PostCode { get; set; } = default!;
    }
}