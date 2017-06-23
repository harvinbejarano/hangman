using HangMan.Services.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HangMan.Services
{
    public interface IWordService : IService<WordDTO>
    {
        List<WordDTO> GetByCategoryId(int categoryId);
    }
}
