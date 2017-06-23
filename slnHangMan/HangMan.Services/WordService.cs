using AutoMapper;
using HangMan.Modelo;
using HangMan.Repository;
using HangMan.Services.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HangMan.Services
{
    public class WordService : BaseService<WordDTO, Word>, IWordService
    {

        private IWordRepository _WordRepository;

        public WordService(IUnitOfWork unitOfWork, IWordRepository wordRepository) 
            : base( unitOfWork, wordRepository)
        {
            _WordRepository = wordRepository;
        }

        public List<WordDTO> GetByCategoryId(int categoryId)
        {
            var list = _WordRepository.GetByCategoryId(categoryId);

            return list.Select(data => Mapper.Map<WordDTO>(data)).ToList();
        }
    }
}
