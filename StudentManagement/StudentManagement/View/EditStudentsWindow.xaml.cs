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
    /// Interaction logic for EditStudentsWindow.xaml
    /// </summary>
    public partial class EditStudentsWindow : Window
    {
        public EditStudentsWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        public void FillInfo(string name = null, string sex = null, string dob = null, string country = null, string parentname = null, int phonenumber = 0, string currentclass = null)
        {
            tb1.Text = name;
            tb2.Text = sex;
            tb3.Text = dob;
            tb4.Text = country;
            tb5.Text = parentname;
            tb6.Text = phonenumber.ToString();
            tb7.Text = currentclass;
        }

    }
}
