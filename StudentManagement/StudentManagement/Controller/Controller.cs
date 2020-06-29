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

        public async Task<LoginResult> Login(string _username, string _password )
        {
            Account user = new Account(_username, _password);
            return await API<LoginResult>.Instance.Post(APIRoute.Account.LogIn, user);
        }

        public async Task<SignUpResult> SignUp(Account account)
        {
            return await API<SignUpResult>.Instance.Post(APIRoute.Account.SignUp, account);
        }
    }
}
