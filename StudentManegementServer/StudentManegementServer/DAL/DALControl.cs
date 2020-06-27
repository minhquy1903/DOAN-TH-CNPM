using StudentManegementServer.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using StudentManegementServer.DAL.DataProvider;

namespace StudentManegementServer.DAL.Controls
{ 
    public class DALControl
    {
        private static DALControl instance;

        public static DALControl Instance
        {
            get
            {
                if (instance == null)
                    instance = new DALControl();
                return instance;
            }
            set => instance = value;
        }

        public DataRow Login(Account account)
        {
            try
            {
                DataRow data = DataProvider.DataProvider.Instance.ExecuteQuery("cau query o day",
                    new object[] { account.Username,account.Password }).Rows[0];

                return data;  //--@id   @user @pass @name @acctype
            }
            catch (Exception e)
            {
                return null;
            }
        }
    }
}
