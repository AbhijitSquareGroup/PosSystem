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
    public class CustomerRepository : BaseRepository<Customer>, ICustomerRepository
    {
        PosSystemDbContext db;
        public CustomerRepository(PosSystemDbContext db)
        {
            this.db = db;
            _db = db;
        }
        public void Delete(int CustomerId)
        {
            // Find the customer by CustomerId
            var customer = db.Customers.Find(CustomerId);

            if (customer != null)
            {
                // Remove the customer
                db.Customers.Remove(customer);

                // Save changes to the database
                db.SaveChanges();

                Console.WriteLine("Customer is deleted");
            }
            else
            {
                Console.WriteLine("Customer not found");
            }
        }

        public Customer GetById(int id)
        {
            var existingCustomer = db.Customers.FirstOrDefault(p => p.CustomerId == id);
            return existingCustomer;
        }
       
    }
}
