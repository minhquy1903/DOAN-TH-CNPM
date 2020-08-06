using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using StudentManagement.API;

namespace StudentManagement.Controllers
{
    public class Controller
    {
        public static Controller _instance = null;
        public static Controller Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new Controller();
                }
                return _instance;
            }
        }
        #region Control Account
        public async Task<LoginResult> Login(string _username, string _password)
        {
            Account user = new Account(_username, _password);

            return await APIHelper.Instance.Post<LoginResult>(APIRoute.Account.Login, user);
        }

        public async Task<bool> SignUp(string _username, string _password, string _email, string _name)
        {
            Account account = new Account(_username, _password);
            account.Email = _email;
            account.Name = _name;
            return await APIHelper.Instance.Post<bool>(APIRoute.Account.SignUp, account);
        }
        #endregion
        #region Control Class
        public async Task<List<ClassInfo>> GetAllClass()
        {
            //List<ClassInfo> classInfos = new List<ClassInfo>();
            return await APIHelper.Instance.Get<List<ClassInfo>>(APIRoute.Class.GetAllClass);
        }

        public async Task<bool> InsertNewClass(ClassInfo classInfo)
        {
            return await APIHelper.Instance.Post<bool>(APIRoute.Class.InsertNewClass, classInfo);
        }
        public async Task<bool> UpdateClass(ClassInfo classInfo)
        {
            return await APIHelper.Instance.Post<bool>(APIRoute.Class.UpdateClass, classInfo);
        }
        public async Task<bool> DeleteClass(int MaLop)
        {
            return await APIHelper.Instance.Post<bool>(APIRoute.Class.DeleteClass, MaLop);
        }
        #endregion
        #region Control Student
        public async Task<List<Student>> GetAllStudent(int MaLop)
        {
            return await APIHelper.Instance.Post<List<Student>>(APIRoute.Student.GetAllStudent,MaLop);
        }
        public async Task<bool> InsertNewStudent(Student student)
        {
            return await APIHelper.Instance.Post<bool>(APIRoute.Student.InsertNewStudent, student);
        }
        public async Task<bool> UpdateStudent(Student student)
        {
            return await APIHelper.Instance.Post<bool>(APIRoute.Student.UpdateStudent, student);
        }
        public async Task<bool> DeleteStudent(int MaHS)
        {
            return await APIHelper.Instance.Post<bool>(APIRoute.Student.DeleteStudent, MaHS);
        }
        #endregion
        #region Control Mark
        public async Task<List<StudentMark>> GetAllMark(int MaHocSinh)
        {
            return await APIHelper.Instance.Post<List<StudentMark>>(APIRoute.Mark.GetAllMark, MaHocSinh);
        }
        public async Task<bool> InsertMark(StudentMark studentMark)
        {
            return await APIHelper.Instance.Post<bool>(APIRoute.Mark.InsertMark, studentMark);
        }
        public async Task<bool> DeleteMark(int maDiem)
        {
            return await APIHelper.Instance.Post<bool>(APIRoute.Mark.GetAllMark, maDiem);
        }
        #endregion
    }

}

