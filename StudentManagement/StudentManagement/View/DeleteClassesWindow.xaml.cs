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
        public DeleteClassesWindow()
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
    }
}
