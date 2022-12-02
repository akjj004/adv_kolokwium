using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
namespace Kolokwium.Model.Models
{
    // we need to change not to store in filed but in obj instead
    // Adress create collection of Adresses
    // Add the ForeginKey to BillingAddres and ShippingAddress
    // Remember to add virtual
    // Remember to add ? nullabe on Adress
    public class Customer : User
    {
        public virtual ICollection<Address> Adresses { get; set; } = default!;
        public virtual ICollection<Order> Orders { get; set; } = default!;
        [ForeignKey("BillingAddresId")]
        public virtual Address? BillingAddres { get; set; }
        public int? BillingAddresId { get; set; }
        [ForeignKey("ShippingAddressId")]
        public virtual Address? ShippingAddress { get; set; }
        public int? ShippingAddressId { get; set; }
    }
}