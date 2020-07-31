using DTO;
using StudentManagement.mUC;
using StudentManagement.Controllers;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace StudentManagement
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        iNotifierBox iNotifierBox = new iNotifierBox();
        public LoginWindow()
        {
            InitializeComponent();
        }

        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            RegisterWindow rwd = new RegisterWindow();
            rwd.ShowDialog();
        }

        private void btnShutdown_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private async void LoginBtn_Click(object sender, RoutedEventArgs e)
        {
            if (txbUser.Text != "" &&
                pwbPassword.Password.ToString() != "")
            {
                LoginResult user = await Controller.Instance.Login(txbUser.Text, pwbPassword.Password.ToString());

                if (user.Result)
                {
                    MenuWindow mwd = new MenuWindow();
                    mwd.Show();
                    this.Close();
                }
                else
                {
                    iNotifierBox.Text = "Sai tên đăng nhập hoặc mật khẩu";
                    iNotifierBox.ShowDialog();
                }
            }
            else
            {
                iNotifierBox.Text = "Vui lòng điền đầy đủ thông tin";
                iNotifierBox.ShowDialog();
            }

        }
    }
}
