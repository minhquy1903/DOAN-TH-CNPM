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
    /// Interaction logic for EditMarksWindow.xaml
    /// </summary>
    public partial class EditMarksWindow : Window
    {
        public bool isCorrected = false;

        public EditMarksWindow()
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
                    MessageBox.Show("Tên học sinh không hợp lệ");
                    return;
                }

                if (!InputTester.IsAClassName(classNameTb.Text))
                {
                    MessageBox.Show("Tên lớp không hợp lệ");
                    return;
                }

                if (!InputTester.IsAFloatNumber(valueTb.Text))
                {
                    MessageBox.Show("Điểm không hợp lệ");
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

        public void FillInfo(string studentName = null, string subjectName = null, string className = null, string semester = null, string type = null, double value = 0)
        {
            classNameTb.Text = studentName;
            subjectNameTb.Text = subjectName;
            classNameTb.Text = className;
            semesterTb.Text = semester;
            typeTb.Text = type;
            valueTb.Text = value.ToString();
        }

    }
}
