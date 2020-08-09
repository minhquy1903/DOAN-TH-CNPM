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
                if (instance == null)
                    instance = new BusControls();
                return instance;
            }
            set => instance = value;
        }

        #region Bus Account
        public UserProfile Login(Account _account)
        {
            DataRow dataAccount = DALControl.Instance.Login(_account);
            if (dataAccount == null)
            {
                UserProfile user = new UserProfile()
                {
                    Result = false
                };
                return user;
            }    
                
            UserProfile userProfile = new UserProfile()
            {
                Result = true,
                Email = dataAccount["Email"].ToString(),
                FullName = dataAccount["FullName"].ToString()
            };

            return userProfile;
        }
        public bool SignUp(Account account)
        {
            return DALControl.Instance.SignUp(account);
        }
        #endregion

        #region BUs Class
        public List<ClassInfo> GetAllClass()
        {
            DataTable classinfo = DALControl.Instance.GetAllClass();
            if (classinfo == null)
                return null;
            List<ClassInfo> classInfos = new List<ClassInfo>();
            
            foreach (DataRow row in classinfo.Rows)
            {
                ClassInfo classInfo = new ClassInfo();
                classInfo.MaLop = Convert.ToInt32(row["MALOP"]);
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

        public bool DeleteClass(int MaLop)
        {
            return DALControl.Instance.DeleteClass(MaLop);
        }
        public bool UpdateClass(ClassInfo classInfo)
        {
            return DALControl.Instance.UpdateClass(classInfo);
        }
        #endregion

        #region Bus Student

        public List<Student> GetAllStudent(int Malop)
        {
            DataTable dataTableStudent = DALControl.Instance.GetAllStudent(Malop);
            List<Student> students = new List<Student>();
            foreach (DataRow row in dataTableStudent.Rows)
            {
                Student student = new Student();
                student.MaHS = Convert.ToInt32(row["MAHS"]);
                student.MaLop = row["MALOP"].ToString();
                student.Hoten = row["HOTEN"].ToString();
                student.NgaySinh = Convert.ToDateTime(row["NGAYSINH"]);
                student.GioiTinh = row["GIOITINH"].ToString();
                student.NoiSinh = row["NOISINH"].ToString();
                student.TenNgGianHo = row["TENNGGIAMHO"].ToString();
                student.SDT = row["SODT"].ToString();
                students.Add(student);
            }
            return students;
        }
        public bool InsertNewStudent(Student student)
        {
            return DALControl.Instance.InsertNewStudent(student);
        }
        public bool UpdateStudent(Student student)
        {
            return DALControl.Instance.Updatetudent(student);
        }
        public bool DeleteStudent(int MaHS)
        {
            return DALControl.Instance.DeleteStudent(MaHS);
        }
        #endregion

        #region Bus Mark
        public List<Mark> GetAllMark(int mahs)
        {
            DataTable dataTableMark = DALControl.Instance.GetAllMark(mahs);
            List<Mark> marks = new List<Mark>();
            foreach (DataRow row in dataTableMark.Rows)
            {
                Mark mark = new Mark();
                mark.maDiem = Convert.ToInt32(row["MADIEM"]);
                mark.loaiDiem = row["LOAIDIEM"].ToString();
                mark.maHS = Convert.ToInt32(row["MAHS"]);
                mark.maMonHoc = row["MAMONHOC"].ToString();
                mark.hocKy = row["HOCKY"].ToString();
                mark.maLop = Convert.ToInt32(row["MALOP"]);
                mark.giaTriDiem = (float)Convert.ToDouble(row["GIATRIDIEM"]);
                marks.Add(mark);
            }
            return marks;
        }
        public bool InsertMark(Mark mark)
        {
            return DALControl.Instance.InsertMark(mark);
        }
        public bool DeleteMark(int maDiem)
        {
            return DALControl.Instance.DeleteMark(maDiem);
        }
        #endregion

    }
}
