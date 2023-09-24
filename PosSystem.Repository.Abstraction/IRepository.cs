using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PosSystem.Repository.Abstraction
{
    public interface IRepository<T> where T : class
    {
        ICollection<T> GetAll();
        bool Add(List<T> item);
        bool Add(T item);
        bool Remove(T item);
        bool Update(T item);
    }
}
