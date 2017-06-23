using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HangMan.Repository
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> All { get; }
        T Delete(T entity);
        T Insert(T entity);
        T FindById(object Id);
        T Update(T entity, T oldEntity, out bool modified);
    }
}
