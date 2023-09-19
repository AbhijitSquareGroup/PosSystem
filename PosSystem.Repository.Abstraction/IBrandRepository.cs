using PosSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PosSystem.Repository.Abstraction
{
    public interface IBrandRepository :IRepository<Brand>
    {
        public Brand GetById(int id);
    }
}
