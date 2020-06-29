using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    public class LoginResult
    {
        [JsonProperty("result")]
        public bool Result { get; set; }

        [JsonProperty("error")]
        public int Error { get; set; }

        [JsonProperty("data")]
        public Data Data { get; set; }
    }

    public class Data
    {
        [JsonProperty("fullName")]
        public string fullName { get; set; }
    }
}
