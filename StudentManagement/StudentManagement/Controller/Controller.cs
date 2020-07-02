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
        public async Task<LoginResult> Login(string _username, string _password)
        {
            Account user = new Account(_username, _password);
           
            return await API<LoginResult>.Instance.Post(APIRoute.Account.Login, user);
        }

        public async Task<ResultYN> SignUp(string _username, string _password, string _email, string _name)
        {
            Account account = new Account(_username, _password);
            account.Email = _email;
            account.Name = _name;
            return await API<ResultYN>.Instance.Post(APIRoute.Account.SignUp, account);
        }

        public async Task<ResultYN> GetAllClass()
        {
            return await API<ResultYN>.Instance.Get(APIRoute.Class.GetAllClass);
        }
    }
}
