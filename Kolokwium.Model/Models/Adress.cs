using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Kolokwium.Model.Models
{
    // Adress 
    // Should have an name number city, postcode
    public class Adress
    {
        [Key]
        public int AdressId { get; set; }
        public string StreetName { get; set; } = default!;
        public int StreetNumber { get; set; }
        public string City { get; set; } = default!;
        public int PostCode { get; set; }
    }
}