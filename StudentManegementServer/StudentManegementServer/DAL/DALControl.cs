using StudentManegementServer.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using StudentManegementServer.DAL.DataProvider;
using StudentManegementServer.Models.Class;
using System.Linq.Expressions;

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
        #region DAL Account
        public DataRow Login(Account account)
        {
            try
            {
                DataRow data = DataProvider.DataProvider.Instance.ExecuteQuery(SQLQuery.Account.ProcLogin,
                    new object[] { account.Username, account.Password }).Rows[0];

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
        #endregion
        #region DAL Class
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
        public bool DeleteClass(int Malop)
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
        public bool UpdateClass(ClassInfo classInfo)
        {
            try
            {
                return DataProvider.DataProvider.Instance.ExecuteNonQuery(SQLQuery.Class.ProcUpdateClass,
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
        #endregion
        #region DAL Student
        public DataTable GetAllStudent(int Malop)
        {
            try
            {
                return DataProvider.DataProvider.Instance.ExecuteQuery(SQLQuery.Student.ProcGetAllStudent,
                    new object[] { Malop });

            }
            catch (Exception e)
            {
                return null;
            }
        }
        public bool InsertNewStudent(Student student)
        {
            try
            {
                return DataProvider.DataProvider.Instance.ExecuteNonQuery(SQLQuery.Student.ProcInsertNewStudent,
                    new object[] {
                    student.MaLop,
                    student.Hoten,
                    student.NgaySinh,
                    student.GioiTinh,
                    student.NoiSinh,
                    student.TenNgGianHo,
                    student.SDT}) > 0;

            }
            catch (Exception e)
            {
                return false;
            }
        }
        public bool Updatetudent(Student student)
        {
            try
            {
                return DataProvider.DataProvider.Instance.ExecuteNonQuery(SQLQuery.Student.ProcUpdateStudent,
                    new object[] {
                    student.MaHS,
                    student.MaLop,
                    student.Hoten,
                    student.NgaySinh,
                    student.GioiTinh,
                    student.NoiSinh,
                    student.TenNgGianHo,
                    student.SDT}) > 0;

            }
            catch (Exception e)
            {
                return false;
            }
        }
        public bool DeleteStudent(int MaHS)
        {
            try
            {
                return DataProvider.DataProvider.Instance.ExecuteNonQuery(SQLQuery.Student.ProcDeleteStudent,
                    new object[] { MaHS }) > 0;

            }
            catch (Exception e)
            {
                return false;
            }
        }
        #endregion
        #region DAL Mark
        public DataTable GetAllMark(Mark mark)
        {
            
            try
            {
                DataTable dataTableMark = DataProvider.DataProvider.Instance.ExecuteQuery(SQLQuery.Mark.ProcGetAllMark,
                    new object[]
                    {
                        mark.maHS,
                        mark.maLop
                    });
                return dataTableMark;
            }
            catch (Exception e)
            {
                return null;
            }
        }
        public bool InsertMark(Mark mark)
        {
            try
            {
                return DataProvider.DataProvider.Instance.ExecuteNonQuery(SQLQuery.Mark.ProcInsertMark,
                new object[]
                {
                    mark.maHS,
                    mark.maMonHoc,
                    mark.loaiDiem,
                    mark.maLop,
                    mark.hocKy,
                    mark.giaTriDiem
                }) > 0;
            }
            catch(Exception e)
            {
                return false;
            }
            
        }
        public bool DeleteMark(int maDiem)
        {
            try
            {
                return DataProvider.DataProvider.Instance.ExecuteNonQuery(SQLQuery.Mark.ProDeleteMark, new object[] { maDiem }) > 0;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        #endregion
    }
}
