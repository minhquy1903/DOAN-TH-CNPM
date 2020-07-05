using DTO;
using StudentManagement.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Interaction logic for RegisterWindow.xaml
    /// </summary>
    public partial class RegisterWindow : Window
    {
        public RegisterWindow()
        {
            InitializeComponent();
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            string username = usernameTb.Text;
            string password = passwordBox.Password.ToString();
            string email = emailTb.Text;
            string name = nameTb.Text;

            if (!IsValidEmail(email))
            {
                MessageBox.Show("Email không hợp lệ");
                return;
            }    
             
            if(!IsValidUsername(username))
            {
                MessageBox.Show("Username không hợp lệ");
                return;
            }
            

            /*Regex regex1 = new Regex("^[a-zA-Z]+[a-zA-Z0-9]+[[a-zA-Z0-9-_.!#$%'*+/=?^]{1,20}@[a-zA-Z0-9]{1,20}.[a-zA-Z]{2,3}$")*/;

            ResultYN result = await Controller.Instance.SignUp(username, password, email, name);

            if (result.Result)
            {
                this.Close();
            }
            else
                MessageBox.Show("Đăng kí không thành công!", "Thông báo");
        }
        bool IsValidEmail(string email)
        {
            try
            {
                Regex rx = new Regex(@"^[-!#$%&'*+/0-9=?A-Z^_a-z{|}~](\.?[-!#$%&'*+/0-9=?A-Z^_a-z{|}~])*@[a-zA-Z](-?[a-zA-Z0-9])*(\.[a-zA-Z](-?[a-zA-Z0-9])*)+$");
                return rx.IsMatch(email);
            }
            catch (FormatException)
            {
                return false;
            }
        }

        bool IsValidUsername(string username)
        {
            try
            {
                Regex rx = new Regex(@"^(?=[a-zA-Z])[-\w.]{0,23}([a-zA-Z\d]|(?<![-.])_)$");
                return rx.IsMatch(username);
            }
            catch (FormatException)
            {
                return false;
            }
        }
        

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
