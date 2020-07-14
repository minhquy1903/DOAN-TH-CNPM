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
    /// Interaction logic for DeleteMarksWindow.xaml
    /// </summary>
    public partial class DeleteMarksWindow : Window
    {
        public bool isCorrected = false;
        iNotifierBox iNotifierBox = new iNotifierBox();

        public DeleteMarksWindow()
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

                string studentName = studentNameTb.Text;
                string subjectName = subjectNameTb.Text;
                string className = classNameTb.Text;
                string semester = semesterTb.Text;
                string type = typeTb.Text;
                double value = Convert.ToDouble(valueTb.Text);

                StudentMark studentMark = new StudentMark()
                {

                };

                //ResultYN resultYN = await Controllers.Controller.Instance.InsertNewClass(classInfo);
                //if (resultYN.Result)
                {
                    this.Hide();
                    isCorrected = true;
                    studentNameTb.Text = "";
                    subjectNameTb.Text = "";
                    classNameTb.Text = "";
                    semesterTb.Text = "";
                    typeTb.Text = "";
                    valueTb.Text = "";
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
