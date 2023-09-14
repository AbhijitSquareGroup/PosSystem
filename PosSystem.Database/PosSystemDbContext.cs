using Microsoft.EntityFrameworkCore;
using PosSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PosSystem.Database
{
    public class PosSystemDbContext : DbContext
    {
        public PosSystemDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Sale> Sales { get; set; }
        public DbSet<SalesDetail> SalesDetails { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Brand> Brands { get; set; }

        
        /*protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure any additional constraints or relationships here
        }*/
    }
}
