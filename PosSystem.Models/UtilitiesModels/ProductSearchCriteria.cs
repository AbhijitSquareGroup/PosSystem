using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PosSystem.Models.UtilitiesModels
{
    public class ProductSearchCriteria
    {
        public decimal? FromPrice { get; set; }
        public decimal? ToPrice { get; set; }
        public string SearchKey { get; set; }
    }
}
