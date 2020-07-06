using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    public class APIResponse<T>
    {
        public bool Result { get; set; }
        public T Data { get; set; }
        public int Error { get; set; }
        public APIResponse(T data)
        {
            Result = true;
            Data = data;
        }
    }
}
