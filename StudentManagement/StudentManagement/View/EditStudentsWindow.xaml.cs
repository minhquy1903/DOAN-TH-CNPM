using DTO;
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
                    MessageBox.Show("Tên học sinh không hợp lệ");
                    return;
                }

                if (!InputTester.IsADate(dobTb.Text))
                {
                    MessageBox.Show("Ngày không hợp lệ");
                    return;
                }

                if (!InputTester.IsAName(countryTb.Text))
                {
                    MessageBox.Show("Tên quê không hợp lệ");
                    return;
                }

                if (!InputTester.IsAName(parentNameTb.Text))
                {
                    MessageBox.Show("Tên phụ huynh không hợp lệ");
                    return;
                }

                if (!InputTester.IsANumber(phoneNumberTb.Text, 10))
                {
                    MessageBox.Show("Số điện thoại không hợp lệ");
                    return;
                }

                if (!InputTester.IsAClassName(currentClassTb.Text))
                {
                    MessageBox.Show("Tên lớp không hợp lệ");
                    return;
                }

                Student student = new Student()
                {
                    MaHS = Convert.ToInt32(studentNameTb.Text),
                    Hoten = studentNameTb.Text,
                    GioiTinh = sexTb.Text,
                    NgaySinh = dobTb.Text,
                    NoiSinh = countryTb.Text,
                    TenNgGianHo = parentNameTb.Text,
                    SDT = phoneNumberTb.Text,
                    MaLop = currentClassTb.Text
                };

                ResultYN resultYN = await Controllers.Controller.Instance.UpdateStudent(student);
                if (resultYN.Result)
                {
                    this.Close();
                    isCorrected = true;
                }
            }
            else
            {
                MessageBox.Show("Please fill out the form");
            }

        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
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
