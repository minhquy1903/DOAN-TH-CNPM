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
    /// Interaction logic for AddStudentsWindow.xaml
    /// </summary>
    public partial class AddStudentsWindow : Window
    {
        public AddStudentsWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (studentNameTb.Text != "" &&
                  sexTb.Text != "" &&
                  dobTb.Text != "" &&
                  countryTb.Text != "" &&
                  parentNameTb.Text != "" &&
                  phoneNumberTb.Text != "" &&
                  currentClassTb.Text != "")
            {
                string studentName = studentNameTb.Text;
                string sex = sexTb.Text;
                string dob = dobTb.Text;
                string country = countryTb.Text;
                string parentName = parentNameTb.Text;
                int phoneNumber = Convert.ToInt32(phoneNumberTb.Text);
                string currentClassName = currentClassTb.Text;
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
