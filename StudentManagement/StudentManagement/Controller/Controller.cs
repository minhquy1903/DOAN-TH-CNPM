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

        public async Task<ResultYN> SignUp(string _username, string _password, string _email, string _name)
        {
            Account account = new Account(_username, _password);
            account.Email = _email;
            account.Name = _name;
            return await APIHelper.Instance.Post<ResultYN>(APIRoute.Account.SignUp, account);
        }
        #endregion
        #region Control Class
        public async Task<List<ClassInfo>> GetAllClass()
        {
            //List<ClassInfo> classInfos = new List<ClassInfo>();
            return await APIHelper.Instance.Get<List<ClassInfo>>(APIRoute.Class.GetAllClass);
        }

        public async Task<ResultYN> InsertNewClass(ClassInfo classInfo)
        {
            return await APIHelper.Instance.Post<ResultYN>(APIRoute.Class.InsertNewClass, classInfo);
        }

        public async Task<ResultYN> DeleteClass(string MaLop)
        {
            return await APIHelper.Instance.Post<ResultYN>(APIRoute.Class.InsertNewClass, MaLop);
        }
        #endregion
        #region Control Student
        public async Task<List<Student>> GetAllStudent(string MaLop)
        {
            return await APIHelper.Instance.Post<List<Student>>(APIRoute.Student.GetAllStudent,MaLop);
        }
        public async Task<ResultYN> InsertNewStudent(Student student)
        {
            return await APIHelper.Instance.Post<ResultYN>(APIRoute.Student.InsertNewStudent, student);
        }
        public async Task<ResultYN> UpdateStudent(Student student)
        {
            return await APIHelper.Instance.Post<ResultYN>(APIRoute.Student.InsertNewStudent, student);
        }
        public async Task<ResultYN> DeleteStudent(string MaHS)
        {
            return await APIHelper.Instance.Post<ResultYN>(APIRoute.Student.InsertNewStudent, MaHS);
        }
        #endregion
    }
}

