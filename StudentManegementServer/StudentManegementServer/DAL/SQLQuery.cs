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

            public const string ProcSignUp = "EXECUTE SignUpAccount @username , @password , @email , @name";
        }
        public static class Class
        {
            public const string ProcGetAllClass = "EXECUTE GetAllClass";

            public const string ProcInsertClass = "EXECUTE InsertNewClass @malop , @tenlop , @siso , @tengv , @khoi , @tennamhoc";

            public const string ProcDeleteClass = "EXECUTE DeleteClass @malop";

            public const string ProcUpdateClass = "EXECUTE UpdateClass @malop , @tenlop , @siso , @tengv , @khoi , @tennamhoc";
        }
        public static class Student
        {
            public const string ProcGetAllStudent = "EXECUTE GetAllHS @malop";

            public const string ProcInsertNewStudent = "EXECUTE InsertNewStudent @mahs , @malop , @hoten , @ngaysinh , @gioitinh , @noisinh , @tennggiamho , @sodt";

            public const string ProcUpdateStudent = "EXECUTE UpdateStudent @mahs , @malop , @hoten , @ngaysinh , @gioitinh , @noisinh , @tennggiamho , @sodt";

            public const string ProcDeleteStudent = "EXECUTE DeleteStudent @mahs";
        }
    }
}
