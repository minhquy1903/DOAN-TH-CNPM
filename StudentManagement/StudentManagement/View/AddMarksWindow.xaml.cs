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
    /// Interaction logic for AddMarksWindow.xaml
    /// </summary>
    public partial class AddMarksWindow : Window
    {
        public bool isCorrected = false;
        iNotifierBox iNotifierBox = new iNotifierBox();

        public int savedMaHS;
        public int savedMaLop;

        public AddMarksWindow()
        {
            InitializeComponent();
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            if (studentNameTb.Text != "" &&
                  subjectNameTb.Text != "" &&
                  classNameTb.Text != "" &&
                  semesterTb.Text != "" &&
                  typeTb.Text != "" &&
                  valueTb.Text != "")
            {
                if (!InputTester.IsAName(studentNameTb.Text))
                {
                    iNotifierBox.Text = "Tên học sinh không hợp lệ";
                    iNotifierBox.ShowDialog();
                    return;
                }

                if (!InputTester.IsAClassName(classNameTb.Text))
                {
                    iNotifierBox.Text = "Tên lớp không hợp lệ";
                    iNotifierBox.ShowDialog();
                    return;
                }

                if (!InputTester.IsAFloatNumber(valueTb.Text))
                {
                    iNotifierBox.Text = "Điểm không hợp lệ";
                    iNotifierBox.ShowDialog();
                    return;
                }

                StudentMark studentMark = new StudentMark()
                {
                    loaiDiem = typeTb.Text,
                    maHS = savedMaHS,
                    maLop = savedMaLop,
                    maMonHoc = subjectNameTb.Text,
                    hocKy = semesterTb.Text,
                    giaTriDiem = (float)Convert.ToDouble(valueTb.Text)
                };

                bool resultYN = await Controllers.Controller.Instance.InsertMark(studentMark);
                if (resultYN)
                {
                    this.Hide();
                    isCorrected = true;
                    studentNameTb.Text = "";
                    subjectNameTb.Text = "";
                    classNameTb.Text = "";
                    semesterTb.Text = "";
                    typeTb.Text = "";
                    valueTb.Text = "";
                    iNotifierBox.Text = "Thêm thành công !";
                    iNotifierBox.ShowDialog();
                }
                else
                {
                    iNotifierBox.Text = "Lỗi";
                    iNotifierBox.ShowDialog();
                }
            }
            else
            {
                iNotifierBox.Text = "Vui lòng điền đầy đủ thông tin";
                iNotifierBox.ShowDialog();
            }

        }

        public void FillSelectedItem(string TenHS, string TenLop)
        {
            studentNameTb.Text = TenHS;
            classNameTb.Text = TenLop;
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
        }
    }
}
