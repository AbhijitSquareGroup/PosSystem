using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PosSystem.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        // Other properties


        [ForeignKey("Brand")]
        public int BrandId { get; set; }

        // Navigation property to represent the relationship
        public Brand Brand { get; set; }
    }
}
