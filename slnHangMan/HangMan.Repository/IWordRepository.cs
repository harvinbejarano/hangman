using HangMan.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HangMan.Repository
{
    public interface IWordRepository : IRepository<Word>
    {
        IEnumerable<Word> GetByCategoryId(int categoryId);
    }
}
