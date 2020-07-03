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

            public const string InsertNewClass = Base + "/Class/InsertNewClass";

            public const string DeleteLop = Base + "/Class/DeleteClass";
        }
        public static class Student
        {
            public const string GetAllStudent = Base + "/Student/GetAllStudent";

            public const string InsertNewStudent = Base + "/Student/InsertNewStudent";

            public const string DeleteStudent = Base + "/Student/DeleteStudent";
        }
    }
}
