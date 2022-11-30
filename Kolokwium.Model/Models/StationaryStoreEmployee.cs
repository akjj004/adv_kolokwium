using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kolokwium.Model.Models
{
    // Stationary will extends from user class
    // so no id for you!
    // will have AgreementNumber
    // will have Employmeent date
    // will have position
    // will have salary
    // navigate to StationaryStore add virtual
    public class StationaryStoreEmployee : User
    {

        public int AgreementNumber { get; set; }
        public DateTime EmploymeentDate { get; set; }
        public string Position { get; set; } = default!;
        public decimal Salary { get; set; }
        // one to many id fk and nav
        [ForeignKey("StationaryStoreId")]
        public int StationaryStoreId { get; set; }
        public virtual StationaryStore? StationaryStore { get; set; }
    }
}