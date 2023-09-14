using PosSystem.Database;
using PosSystem.Models;
using PosSystem.Models.UtilitiesModels;
using PosSystem.Repository.Abstraction;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PosSystem.Repository
{
    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        PosSystemDbContext db;
        public ProductRepository(PosSystemDbContext db)
        {
            this.db = db;
            _db = db;
        }
        public void Delete(int productId)
        {
            var product = db.Products.Find(productId);
            if (product != null)
            {
                db.Products.Remove(product);
                db.SaveChanges();
                Console.WriteLine("Product is Deleted");
            }
        }

        public Product GetById(int id)
        {
            throw new NotImplementedException();
        }

        public ICollection<Product> SearchProduct(ProductSearchCriteria searchCriteria)
        {
            throw new NotImplementedException();
        }
    }
}
