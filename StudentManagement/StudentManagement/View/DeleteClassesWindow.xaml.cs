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
    /// Interaction logic for DeleteClassesWindow.xaml
    /// </summary>
    public partial class DeleteClassesWindow : Window
    {
        public bool isCorrected = false;
        iNotifierBox iNotifierBox = new iNotifierBox();

        public DeleteClassesWindow()
        {
            InitializeComponent();
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            if (classNameTb.Text != "" &&
                  gradeTb.Text != "" &&
                  teacherNameTb.Text != "" &&
                  countTb.Text != "" &&
                  yearTb.Text != "")
            {
                if (!InputTester.IsAClassName(classNameTb.Text))
                {
                    iNotifierBox.Text = "Tên lớp không hợp lệ";
                    iNotifierBox.ShowDialog();
                    return;
                }

                if (!InputTester.IsAName(teacherNameTb.Text))
                {
                    iNotifierBox.Text = "Tên giáo viên không hợp lệ";
                    iNotifierBox.ShowDialog();
                    return;
                }

                if (!InputTester.IsANumber(countTb.Text, 2))
                {
                    iNotifierBox.Text = "Sĩ số không hợp lệ";
                    iNotifierBox.ShowDialog();
                    return;
                }

                if (!InputTester.IsANumber(yearTb.Text, 4))
                {
                    iNotifierBox.Text = "Năm không hợp lệ";
                    iNotifierBox.ShowDialog();
                    return;
                }

                ClassInfo classInfo = new ClassInfo()
                {
                    tenLop = classNameTb.Text,
                    khoi = gradeTb.Text,
                    tenGVCN = teacherNameTb.Text,
                    siSo = Convert.ToInt32(countTb.Text),
                    nienKhoa = yearTb.Text
                };

                ResultYN resultYN = await Controllers.Controller.Instance.DeleteClass(classInfo.maLop);
                if (resultYN.Result)
                {
                    this.Hide();
                    isCorrected = true;
                    classNameTb.Text = "";
                    gradeTb.Text = "";
                    teacherNameTb.Text = "";
                    countTb.Text = "";
                    yearTb.Text = "";
                    iNotifierBox.Text = "Xoá thành công !";
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
    }
}
