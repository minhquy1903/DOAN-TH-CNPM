using StudentManegementServer.DAL.Controls;
using StudentManegementServer.Models;
using StudentManegementServer.Models.Class;
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
        private static BusControls instance;

        public static BusControls Instance
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
        public List<ClassInfo> GetAllClass()
        {
            DataTable classinfo = DALControl.Instance.GetAllClass();

            List<ClassInfo> classInfos = new List<ClassInfo>();
            
            foreach (DataRow row in classinfo.Rows)
            {
                ClassInfo classInfo = new ClassInfo();
                classInfo.MaLop = row["MALOP"].ToString();
                classInfo.TenLop = row["TENLOP"].ToString();
                classInfo.SiSo = Convert.ToInt32(row["SISO"]);
                classInfo.TenGVCN = row["TENGV"].ToString();
                classInfo.Khoi = row["KHOI"].ToString();
                classInfo.NienKhoa = row["TENNAMHOC"].ToString();
                classInfos.Add(classInfo);
            }
            return classInfos;
        }
        public bool InsertNewClass(ClassInfo classInfo)
        {
            return DALControl.Instance.InsertNewClass(classInfo);
        }

        public bool DeleteClass(string MaLop)
        {
            return DALControl.Instance.DeleteClass(MaLop);
        }
    }
}
