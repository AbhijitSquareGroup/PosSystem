using PosSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PosSystem.Repository.Abstraction
{
    public interface ICustomerRepository
    {
        public void Delete(int CustomerId);
        public Customer GetById(int id);
    }
}
