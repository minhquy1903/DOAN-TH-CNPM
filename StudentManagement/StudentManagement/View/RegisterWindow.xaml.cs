using DTO;
using StudentManagement.mUC;
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
        iNotifierBox iNotifierBox = new iNotifierBox();
        public RegisterWindow()
        {
            InitializeComponent();
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            if (usernameTb.Text != "" &&
                passwordBox.Password.ToString() != "" &&
                emailTb.Text != "" &&
                nameTb.Text != "")
            {
                if (!IsValidEmail(emailTb.Text))
                {
                    MessageBox.Show("Email không hợp lệ");
                    return;
                }

                if (!IsValidUsername(usernameTb.Text))
                {
                    MessageBox.Show("Username không hợp lệ");
                    return;
                }

                ResultYN result = await Controller.Instance.SignUp(usernameTb.Text, passwordBox.Password.ToString(), emailTb.Text, nameTb.Text);

                if (result.Result)
                {
                    this.Close();
                }
                else
                {
                    iNotifierBox.Text = "Đăng kí không thành công";
                    iNotifierBox.ShowDialog();
                }
            }
            else
            {
                iNotifierBox.Text = "Vui lòng điền đầy đủ thông tin";
                iNotifierBox.ShowDialog();
            }
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
