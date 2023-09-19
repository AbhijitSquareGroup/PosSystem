using Microsoft.EntityFrameworkCore;
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
            var existingProduct = db.Products.FirstOrDefault(p => p.ProductId == id);
            return existingProduct;
        }

        public ICollection<Product> SearchProduct(ProductSearchCriteria searchCriteria)
        {
            var searchKey = searchCriteria.SearchKey;
            //string searchKey = "";
            var products = db.Products
                             .Include(c => c.Brand).AsQueryable();

            if (!string.IsNullOrEmpty(searchKey))
            {
                products = db.Products
                    .Where(c => c.Name.ToLower().Contains(searchKey.ToLower())
                        || c.Description.ToLower().Contains(searchKey.ToLower())
                    || (c.Brand == null ? false : c.Brand.Name.ToLower().Contains(searchKey.ToLower()))
                    );
            }
            if (searchCriteria.FromPrice != null)
            {
                products = products.Where(c => c.Price > searchCriteria.FromPrice);
            }
            if (searchCriteria.ToPrice != null)
            {
                products = products.Where(c => c.Price <= searchCriteria.ToPrice);
            }
            return products.ToList();

        }
    }
}
