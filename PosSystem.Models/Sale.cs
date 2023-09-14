using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PosSystem.Models
{
    public class Sale
    {

        public int SaleId { get; set; }
        public decimal TotalPrice {get; set; }
        // Other properties

        [ForeignKey("Customer")]
        public int CustomerId { get; set; }

        // Navigation property to represent the relationship
        public Customer Customer { get; set; }
    }
}
