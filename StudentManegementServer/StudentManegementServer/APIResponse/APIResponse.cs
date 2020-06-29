using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentManegementServer.APIResponse
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
        public APIResponse(int error)
        {
            Result = false;
            Error = error;
        }

    }
}
