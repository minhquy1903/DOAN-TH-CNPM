using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentManegementServer.DAL
{
    public static class SQLQuery
    {
        public static class Account
        {
            public const string ProcLogin = "EXECUTE LoginAccount @username , @password";

            public const string ProcSignUp = "EXECUTE SignUpAccount @username , @password , @email , @name ";
        }
        public static class Class
        {
            public const string ProcGetAllClass = "EXECUTE GetAllClass";
        }
    }
}
