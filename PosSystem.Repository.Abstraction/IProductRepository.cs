using PosSystem.Models;
using PosSystem.Models.UtilitiesModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PosSystem.Repository.Abstraction
{
    public interface IProductRepository : IRepository<Product>
    {
        public Product GetById(int id);
        public ICollection<Product> SearchProduct(ProductSearchCriteria searchCriteria);
    }
}
