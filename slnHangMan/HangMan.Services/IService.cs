using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HangMan.Services
{
    public interface IService<TDTO> where TDTO : class
    {
        IEnumerable<TDTO> GetAll();
        void Create(TDTO dto);
        void Delete(object id);
        void Update(object id, TDTO dto);
        TDTO FindById(object Id);
    }
}
