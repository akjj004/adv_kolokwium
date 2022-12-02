using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Kolokwium.Model.Models
{
    // new class
    // add Id
    // add adress
    // add orders to store
    // add AgreementNumber
    // add collection of StationaryStoreEmployess
    public class StationaryStore
    {
        [Key]
        public int StationaryStoreId { get; set; }
        public virtual Address? Adress { get; set; }
        public virtual ICollection<Order>? Orders { get; set; }
        public int AgreementNumber { get; set; }
        public virtual ICollection<StationaryStoreEmployee>? StationaryStoreEmployees { get; set; }
    }
}