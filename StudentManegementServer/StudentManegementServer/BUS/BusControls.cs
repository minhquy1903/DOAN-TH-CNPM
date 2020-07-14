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
        #endregion

        #region BUs Class
        public List<ClassInfo> GetAllClass()
        {
            DataTable classinfo = DALControl.Instance.GetAllClass();

            List<ClassInfo> classInfos = new List<ClassInfo>();

            foreach (DataRow row in classinfo.Rows)
            {
                ClassInfo classInfo = new ClassInfo();
                classInfo.MaLop = (int)row["MALOP"];
                classInfo.TenLop = row["TENLOP"].ToString();
                classInfo.SiSo = (int)row["SISO"];
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
                student.MaHS = (int)row["MAHS"];
                student.MaLop = row["MALOP"].ToString();
                student.Hoten = row["HOTEN"].ToString();
                student.NgaySinh = row["NGAYSINH"].ToString();
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
        public List<Mark> GetAllMark(Mark _mark)
        {
            DataTable dataTableMark = DALControl.Instance.GetAllMark(_mark);
            List<Mark> marks = new List<Mark>();
            foreach (DataRow row in dataTableMark.Rows)
            {
                Mark mark = new Mark();
                mark.maDiem = (int)row["MADIEM"];
                mark.loaiDiem = row["LOAIDIEM"].ToString();
                mark.maHS = (int)row["MAHS"];
                mark.maMonHoc = row["MAMONHOC"].ToString();
                mark.hocKy = row["HOCKY"].ToString();
                mark.maLop = (int)row["MALOP"];
                mark.giaTriDiem = (int)row["GIATRIDIEM"];
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
