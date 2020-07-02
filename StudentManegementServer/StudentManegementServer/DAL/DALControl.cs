using StudentManegementServer.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using StudentManegementServer.DAL.DataProvider;
using StudentManegementServer.Models.Class;

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
                DataRow data = DataProvider.DataProvider.Instance.ExecuteQuery(SQLQuery.Account.ProcLogin,
                    new object[] { account.Username,account.Password }).Rows[0];

                return data; 
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
                return DataProvider.DataProvider.Instance.ExecuteNonQuery(SQLQuery.Account.ProcSignUp, 
                    new object[] { 
                        account.Username, 
                        account.Password, 
                        account.Email, 
                        account.Name }) > 0;
               
            }
            catch (Exception e)
            {
                return false;
            }
        }
        public DataTable GetAllClass()
        {
            try
            {
                return DataProvider.DataProvider.Instance.ExecuteQuery(SQLQuery.Class.ProcGetAllClass);

            }
            catch (Exception e)
            {
                return null;
            }
        }
        public bool InsertNewClass(ClassInfo classInfo)
        {
            try
            {
                return DataProvider.DataProvider.Instance.ExecuteNonQuery(SQLQuery.Class.ProcInsertClass, 
                    new object[] { 
                        classInfo.MaLop, 
                        classInfo.TenLop, 
                        classInfo.SiSo, 
                        classInfo.TenGVCN, 
                        classInfo.Khoi, 
                        classInfo.NienKhoa }) > 0;

            }
            catch (Exception e)
            {
                return false;
            }
        }
        public bool DeleteClass(string Malop)
        {
            try
            {
                return DataProvider.DataProvider.Instance.ExecuteNonQuery(SQLQuery.Class.ProcDeleteClass,
                    new object[] { Malop }) > 0;

            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}
