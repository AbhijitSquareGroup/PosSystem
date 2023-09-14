using Microsoft.EntityFrameworkCore;
using PosSystem.Repository.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PosSystem.Repository
{
    public abstract class BaseRepository<T> : IRepository<T> where T : class
    {
        protected DbContext _db;
        private DbSet<T> Table
        {
            get
            {
                return _db.Set<T>();
            }
        }
        

        public virtual bool Add(List<T> item)
        {
            Table.AddRange(item);
            return _db.SaveChanges() > 0;
        }

        public virtual ICollection<T> GetAll()
        {
            return Table.ToList();
        }

        public virtual bool Remove(T item)
        {
            Table.Remove(item);
            return (_db.SaveChanges() > 0);
        }

        public virtual bool Update(T item)
        {
            Table.Update(item);
            return _db.SaveChanges() > 0;
        }
    }
}
