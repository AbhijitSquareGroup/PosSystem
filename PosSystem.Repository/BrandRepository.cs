using PosSystem.Database;
using PosSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PosSystem.Repository
{
    public class BrandRepository :BaseRepository<Brand>
    {
        PosSystemDbContext db;
        public BrandRepository(PosSystemDbContext db)
        {
            
        }

    }
}
