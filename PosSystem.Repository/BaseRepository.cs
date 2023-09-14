using PosSystem.Repository.Abstraction.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PosSystem.Repository
{
    public abstract class BaseRepository<T>:IRepository<T> where T : class
    {

    }
}
