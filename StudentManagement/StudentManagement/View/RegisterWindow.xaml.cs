using DTO;
using StudentManagement.Controllers;
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
            string username = tb3.Text;
            string password = passwordBox.Password.ToString();
            string email = tb2.Text;
            string name = tb1.Text;

            ResultYN result = await Controller.Instance.SignUp(username, password, email, name);

            
            if (result.Result)
            {
                this.Close();
            }
            else
                MessageBox.Show("Đăng kí không thành công!", "Thông báo");
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
