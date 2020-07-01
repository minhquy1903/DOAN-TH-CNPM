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

    public partial class Data
    {
        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("fullName")]
        public string FullName { get; set; }
    }
}
