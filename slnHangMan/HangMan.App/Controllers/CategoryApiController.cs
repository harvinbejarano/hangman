using HangMan.App.Base;
using HangMan.Services;
using HangMan.Services.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace HangMan.App.Controllers.Rest
{
    public class CategoryApiController : ApiController
    {
        //URI: /api/CategoryApi/

        private ICategoryService _CategoryService;

        public CategoryApiController(ICategoryService categoryService)
        {
            _CategoryService = categoryService;
        }

        [HttpPost]
        public ResponseDTO<CategoryDTO> Insert([FromBody]CategoryDTO dto)
        {
            ResponseDTO<CategoryDTO> result = new Base.ResponseDTO<CategoryDTO>();
            try
            {
                _CategoryService.Create(dto);
                result.StatusCode = 200; //OK
                result.Data = dto;
            }
            catch(Exception e)
            {
                result.StatusCode = 500; //Error
                result.Message = e.Message;
            }

            return result;
        }

        [HttpPost]
        public ResponseDTO<CategoryDTO> Update([FromBody]CategoryDTO dto)
        {
            ResponseDTO<CategoryDTO> result = new Base.ResponseDTO<CategoryDTO>();
            try
            {
                _CategoryService.Update(dto.Id,dto);
                result.StatusCode = 200; //OK
                result.Data = dto;
            }
            catch (Exception e)
            {
                result.StatusCode = 500; //Error
                result.Message = e.Message;
            }

            return result;
        }

        [HttpDelete]
        public ResponseDTO<CategoryDTO> Delete(int id)
        {
            ResponseDTO<CategoryDTO> result = new Base.ResponseDTO<CategoryDTO>();
            try
            {
                _CategoryService.Delete(id);
                result.StatusCode = 200; //OK
            }
            catch (Exception e)
            {
                result.StatusCode = 500; //Error
                result.Message = e.Message;
            }

            return result;
        }

        [HttpGet]
        public ResponseDTO<List<CategoryDTO>> GetAll()
        {
            ResponseDTO<List<CategoryDTO>> result = new Base.ResponseDTO<List<CategoryDTO>>();
            try
            {
                var list = _CategoryService.GetAll().ToList();
                result.StatusCode = 200; //OK
                result.Data = list;
            }
            catch (Exception e)
            {
                result.StatusCode = 500; //Error
                result.Message = e.Message;
            }

            return result;
        }

        [HttpGet]
        public ResponseDTO<CategoryDTO> Get(int id)
        {
            ResponseDTO<CategoryDTO> result = new Base.ResponseDTO<CategoryDTO>();
            try
            {
                var dto = _CategoryService.FindById(id);
                result.StatusCode = 200; //OK
                result.Data = dto;
            }
            catch (Exception e)
            {
                result.StatusCode = 500; //Error
                result.Message = e.Message;
            }

            return result;
        }


    }
}
