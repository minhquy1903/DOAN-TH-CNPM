using StudentManegementServer.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using StudentManegementServer.DAL.DataProvider;
using Microsoft.AspNetCore.Mvc;

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
                DataRow data = DataProvider.DataProvider.Instance.ExecuteQuery("EXECUTE LoginAccount @username , @password",
                    new object[] { account.Username,account.Password }).Rows[0];

                return data;  //--@id   @user @pass @name @acctype
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public bool SignUp(Account account)
        {
            try
            {
                DataTable accountTable = DataProvider.DataProvider.Instance.ExecuteQuery("EXECUTE GetAllAccount");

                for(int i=0;i<accountTable.Columns.Count;i++)
                {
                    if (account.Username == accountTable.Rows[0].ToString())
                        return false;
                }

                return DataProvider.DataProvider.Instance.ExecuteNonQuery("EXECUTE SignUpAccount @username , @password , @email , @name ", new object[] {account.Username }) > 0;
            }
            catch(Exception e)
            {
                return false;
            }
        }
    }
}
