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
    public class CategoryService : BaseService<CategoryDTO, Category>, ICategoryService
    {
        public CategoryService(IUnitOfWork unitOfWork, ICategoryRepository categoryRepository) 
            : base( unitOfWork, categoryRepository)
        {
        }
    }
}
