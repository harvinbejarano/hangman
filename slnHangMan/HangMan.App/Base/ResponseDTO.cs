using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HangMan.App.Base
{
    public class ResponseDTO<T>
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }

    }
}