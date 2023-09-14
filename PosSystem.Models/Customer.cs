using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PosSystem.Models
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public string Name { get; set; }
        public String Address { get; set; }
        public string PhoneNo { get; set; }
        // Other properties

        // Navigation property to represent the relationship
        public ICollection<Sale> Sales { get; set; }

    }
}
