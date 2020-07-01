using StudentManegementServer.DAL.Controls;
using StudentManegementServer.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace StudentManegementServer.BUS
{
    public class BusControls
    {
        private BusControls instance;

        public BusControls Instance
        {
            get
            {
                if(instance == null)
                    instance = new BusControls();
                return instance;
            }
            set => instance = value;
        }

        public UserProfile Login(Account _account)
        {
            DataRow dataAccount = DALControl.Instance.Login(_account);
            if (dataAccount == null)
                return null;
            UserProfile userProfile = new UserProfile()
            {
                Email = dataAccount["Email"].ToString(),
                FullName = dataAccount["FullName"].ToString()
            };

            return userProfile;
        }

        public bool SignUp(Account account)
        {
            return DALControl.Instance.SignUp(account);
        }
    }
}
