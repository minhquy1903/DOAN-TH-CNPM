using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.API
{
    class APIRoute
    {
        private const string Root = "api";

        private const string Base = Root;

        public static class Account
        {
            public const string LogIn = Base + "/Account/login";

            public const string SignUp = Base + "/Account/signup";
        }
    }
}
