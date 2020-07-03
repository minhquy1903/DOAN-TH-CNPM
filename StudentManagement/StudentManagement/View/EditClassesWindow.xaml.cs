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

        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        public void FillInfo(string name = null, int grade = 0, string teacher = null, int count = 0, int year = 0)
        {
            tb1.Text = name;
            tb2.Text = grade.ToString();
            tb3.Text = teacher;
            tb4.Text = count.ToString();
            tb5.Text = year.ToString();
        }

    }
}
