using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kolokwium.Model.Models
{
    public class Supplier : User
    {
        public virtual ICollection<Product>? Products { get; set; }
    }
}