using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PosSystem.Models
{
    public class SalesDetail
    {
        public int SalesDetailId { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public decimal Discount { get; set;}

        // Other properties

        [ForeignKey("Sale")]
        public int SaleId { get; set; }
        [ForeignKey("Product")]
        public int ProductId { get; set; }

        // Navigation properties to represent the relationships
        public Sale Sale { get; set; }
        public Product Product { get; set; }
    }
}

