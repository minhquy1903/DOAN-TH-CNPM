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
    /// Interaction logic for EditClassesWindow.xaml
    /// </summary>
    public partial class EditClassesWindow : Window
    {
        public EditClassesWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (classNameTb.Text != "" &&
                  gradeTb.Text != "" &&
                  teacherNameTb.Text != "" &&
                  countTb.Text != "" &&
                  yearTb.Text != "")
            {
                string className = classNameTb.Text;
                int grade = Convert.ToInt32(gradeTb.Text);
                string teacherName = teacherNameTb.Text;
                int count = Convert.ToInt32(countTb.Text);
                int year = Convert.ToInt32(yearTb.Text);

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

        public void FillInfo(string name = null, int grade = 0, string teacher = null, int count = 0, int year = 0)
        {
            classNameTb.Text = name;
            gradeTb.Text = grade.ToString();
            teacherNameTb.Text = teacher;
            countTb.Text = count.ToString();
            yearTb.Text = year.ToString();
        }

    }
}
