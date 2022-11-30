using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace Kolokwium.Model.Models
{
    // id
    // Name
    // Tag
    // List of products
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }
        public string Name { get; set; } = default!;
        public string Tag { get; set; } = default!;
        public virtual ICollection<Product>? Products { get; set; }

    }
}