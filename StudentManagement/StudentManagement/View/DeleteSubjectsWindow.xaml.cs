using DTO;
using StudentManagement.mUC;
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
        iNotifierBox iNotifierBox = new iNotifierBox();

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
                    iNotifierBox.Text = "Tên môn học không hợp lệ";
                    iNotifierBox.ShowDialog();
                    return;
                }

                if (!InputTester.IsANumber(countTb.Text, 2))
                {
                    iNotifierBox.Text = "Số tiết không hợp lệ";
                    iNotifierBox.ShowDialog();
                    return;
                }

                isCorrected = true;
                string subjectName = subjectNameTb.Text;
                int count = Convert.ToInt32(countTb.Text);

                this.Hide();
                subjectNameTb.Text = "";
                countTb.Text = "";
                iNotifierBox.Text = "Xoá thành công !";
                iNotifierBox.ShowDialog();
            }
            else
            {
                iNotifierBox.Text = "Vui lòng điền đầy đủ thông tin";
                iNotifierBox.ShowDialog();
            }

        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
        }
    }
}
