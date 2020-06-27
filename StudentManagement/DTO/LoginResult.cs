using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    public class LoginResult
    {
        public bool Result { get; set; }
        public int Error { get; set; }
        public Data Data { get; set; }
    }

    public class Data
    {
        public string ID { get; set; }
        public string Name { get; set; }
    }
}
