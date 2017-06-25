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
    public class WordApiController : ApiController
    {
        private IWordService _WordService;

        public WordApiController(IWordService wordService)
        {
            _WordService = wordService;
        }

        [HttpPost]
        public ResponseDTO<WordDTO> Insert([FromBody]WordDTO dto)
        {
            ResponseDTO<WordDTO> result = new Base.ResponseDTO<WordDTO>();
            try
            {
                _WordService.Create(dto);
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

        [HttpPost]
        public ResponseDTO<WordDTO> Update([FromBody]WordDTO dto)
        {
            ResponseDTO<WordDTO> result = new Base.ResponseDTO<WordDTO>();
            try
            {
                _WordService.Update(dto.Id, dto);
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
        public ResponseDTO<WordDTO> Delete(int id)
        {
            ResponseDTO<WordDTO> result = new Base.ResponseDTO<WordDTO>();
            try
            {
                _WordService.Delete(id);
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
        public ResponseDTO<List<WordDTO>> GetAll()
        {
            ResponseDTO<List<WordDTO>> result = new Base.ResponseDTO<List<WordDTO>>();
            try
            {
                var list = _WordService.GetAll().ToList();
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
        public ResponseDTO<WordDTO> Get(int id)
        {
            ResponseDTO<WordDTO> result = new Base.ResponseDTO<WordDTO>();
            try
            {
                var dto = _WordService.FindById(id);
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

        [HttpGet]
        public ResponseDTO<List<WordDTO>> GetByCategoryId(int id)
        {
            ResponseDTO<List<WordDTO>> result = new Base.ResponseDTO<List<WordDTO>>();
            try
            {
                var list = _WordService.GetByCategoryId(id);
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
    }
}