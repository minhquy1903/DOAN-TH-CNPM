using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    public class APIResponse<T>
    {
        public T Data { get; set; }
        public APIResponse(T data)
        {
            Data = data;
        }
    }
}
