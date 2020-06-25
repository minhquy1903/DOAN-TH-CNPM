using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using StudentManagement.API;

namespace StudentManagement.Controller
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

        public async Task<Login> Login(string username, string password)
        {
            Account user = new Account();
            user.Username = username;
            user.Password = password;

            return await API<Login>.Instance.Post("api/login", user);
        }


    }
}
