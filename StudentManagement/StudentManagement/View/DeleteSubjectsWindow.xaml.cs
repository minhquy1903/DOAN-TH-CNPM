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
    /// Interaction logic for DeleteSubjectsWindow.xaml
    /// </summary>
    public partial class DeleteSubjectsWindow : Window
    {
        public bool isCorrected = false;

        public DeleteSubjectsWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (subjectNameTb.Text != "" &&
               countTb.Text != "")
            {
                if (!InputTester.IsAName(subjectNameTb.Text))
                {
                    MessageBox.Show("Tên môn học không hợp lệ");
                    return;
                }

                if (!InputTester.IsANumber(countTb.Text, 2))
                {
                    MessageBox.Show("Số tiết không hợp lệ");
                    return;
                }

                isCorrected = true;
                string subjectName = subjectNameTb.Text;
                int count = Convert.ToInt32(countTb.Text);

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
