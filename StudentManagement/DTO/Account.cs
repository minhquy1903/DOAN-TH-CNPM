using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    public class Account
    {
        public string IDAccount { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public Account(string _username, string _password)
        {
            Username = _username;
            Password = _password;
        }
    }
}
