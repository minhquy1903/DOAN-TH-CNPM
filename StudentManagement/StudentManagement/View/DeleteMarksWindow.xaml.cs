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
        public DeleteMarksWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (studentNameTb.Text != "" &&
                  subjectNameTb.Text != "" &&
                  classNameTb.Text != "" &&
                  semesterTb.Text != "" &&
                  typeTb.Text != "" &&
                  valueTb.Text != "")
            {
                string studentName = studentNameTb.Text;
                string subjectName = subjectNameTb.Text;
                string className = classNameTb.Text;
                string semester = semesterTb.Text;
                string type = typeTb.Text;
                double value = Convert.ToDouble(valueTb.Text);
                this.Close();
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
    }
}
