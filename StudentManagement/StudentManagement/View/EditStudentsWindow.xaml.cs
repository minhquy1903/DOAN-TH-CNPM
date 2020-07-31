using DTO;
using StudentManagement.mUC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace StudentManagement
{
    /// <summary>
    /// Interaction logic for EditStudentsWindow.xaml
    /// </summary>
    public partial class EditStudentsWindow : Window
    {
        public bool isCorrected = false;
        iNotifierBox iNotifierBox = new iNotifierBox();

        public EditStudentsWindow()
        {
            InitializeComponent();
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            if (studentNameTb.Text != "" &&
                  sexTb.Text != "" &&
                  dobTb.Text != "" &&
                  countryTb.Text != "" &&
                  parentNameTb.Text != "" &&
                  phoneNumberTb.Text != "" &&
                  currentClassTb.Text != "")
            {
                if (!InputTester.IsAName(studentNameTb.Text))
                {
                    iNotifierBox.Text = "Tên học sinh không hợp lệ";
                    iNotifierBox.ShowDialog();
                    return;
                }

                if (!InputTester.IsADate(dobTb.Text))
                {
                    iNotifierBox.Text = "Ngày không hợp lệ";
                    iNotifierBox.ShowDialog();
                    return;
                }

                if (!InputTester.IsAName(countryTb.Text))
                {
                    iNotifierBox.Text = "Tên quê không hợp lệ";
                    iNotifierBox.ShowDialog();
                    return;
                }

                if (!InputTester.IsAName(parentNameTb.Text))
                {
                    iNotifierBox.Text = "Tên phụ huynh không hợp lệ";
                    iNotifierBox.ShowDialog();
                    return;
                }

                if (!InputTester.IsANumber(phoneNumberTb.Text, 10))
                {
                    iNotifierBox.Text = "Số điện thoại không hợp lệ";
                    iNotifierBox.ShowDialog();
                    return;
                }

                if (!InputTester.IsAClassName(currentClassTb.Text))
                {
                    iNotifierBox.Text = "Tên lớp không hợp lệ";
                    iNotifierBox.ShowDialog();
                    return;
                }

                Student student = new Student()
                {
                    Hoten = studentNameTb.Text,
                    GioiTinh = sexTb.Text,
                    NgaySinh = Convert.ToDateTime(dobTb.Text),
                    NoiSinh = countryTb.Text,
                    TenNgGianHo = parentNameTb.Text,
                    SDT = phoneNumberTb.Text,
                    MaLop = currentClassTb.Text
                };

                bool resultYN = await Controllers.Controller.Instance.UpdateStudent(student);
                if (resultYN)
                {
                    this.Hide();
                    isCorrected = true;
                    studentNameTb.Text = "";
                    sexTb.Text = "";
                    dobTb.Text = "";
                    countryTb.Text = "";
                    parentNameTb.Text = "";
                    phoneNumberTb.Text = "";
                    currentClassTb.Text = "";
                    iNotifierBox.Text = "Sửa thành công !";
                    iNotifierBox.ShowDialog();
                }
            }
            else
            {
                iNotifierBox.Text = "Vui lòng điền đầy đủ thông tin";
                iNotifierBox.ShowDialog();
            }

        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
        }

        public void FillInfo(string name = null, string sex = null, string dob = null, string country = null, string parentname = null, int phonenumber = 0, string currentclass = null)
        {
            studentNameTb.Text = name;
            sexTb.Text = sex;
            dobTb.Text = dob;
            countryTb.Text = country;
            parentNameTb.Text = parentname;
            phoneNumberTb.Text = phonenumber.ToString();
            currentClassTb.Text = currentclass;
        }

    }
}
