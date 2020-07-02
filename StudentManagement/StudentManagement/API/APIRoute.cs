using System;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.API
{
    public class APIRoute
    {
        public const string Root = "api";
        public const string Base = Root;

        public static class Account
        {
            public const string Login = Base + "/Account/login";

            public const string SignUp = Base + "/Account/signup";
        }
        public static class Class
        {
            public const string GetAllClass = Base + "/Class/getall";
        }
    }
}
