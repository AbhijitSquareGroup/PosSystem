using PosSystem.Database;
using PosSystem.Models;
using PosSystem.Repository.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PosSystem.Repository
{
    public class BrandRepository :BaseRepository<Brand>,IBrandRepository
    {
        PosSystemDbContext db;
        public BrandRepository(PosSystemDbContext db)
        {
            this.db = db;
            _db = db;
        }
        public void Delete(int BrandId)
        {
            // Find the Brand by BrandId
            var brand = db.Brands.Find(BrandId);

            if (brand != null)
            {
                // Remove all related Products associated with the Brand
                foreach (var product in brand.Products.ToList())
                {
                    db.Products.Remove(product);
                }

                // Remove the Brand itself
                db.Brands.Remove(brand);

                // Save changes to the database
                db.SaveChanges();

                Console.WriteLine("Brand and its associated Products are deleted");
            }
            else
            {
                Console.WriteLine("Brand not found");
            }
        }

        public Brand GetById(int id)
        {
            var existingBrand = db.Brands.FirstOrDefault(p => p.BrandId == id);
            return existingBrand;
        }
    }
}
