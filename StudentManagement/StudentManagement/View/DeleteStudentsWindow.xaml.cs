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
    /// Interaction logic for DeleteStudentsWindow.xaml
    /// </summary>
    public partial class DeleteStudentsWindow : Window
    {
        public bool isCorrected = false;

        public DeleteStudentsWindow()
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

                isCorrected = true;
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
