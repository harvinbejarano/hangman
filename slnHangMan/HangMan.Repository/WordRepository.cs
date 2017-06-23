using HangMan.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HangMan.Repository
{
    public class WordRepository : BaseRepository<Word>, IWordRepository
    {
        public WordRepository(hangmanEntities dataContext) 
            : base(dataContext)
        {
        }

        public IEnumerable<Word> GetByCategoryId(int categoryId)
        {
            return _dbSet.Where(c => c.CategoryId == categoryId).AsEnumerable();
        }
    }
}
