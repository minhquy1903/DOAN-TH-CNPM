﻿using DTO;
using StudentManagement.mUC;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
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
        public bool isCorrected = false;
        iNotifierBox iNotifierBox = new iNotifierBox();

        public int savedMaLop;

        public AddStudentsWindow()
        {
            InitializeComponent();

            Thread.CurrentThread.CurrentCulture = (CultureInfo)Thread.CurrentThread.CurrentCulture.Clone();
            Thread.CurrentThread.CurrentCulture.DateTimeFormat.ShortDatePattern = "dd-MM-yyyy";
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
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
                    iNotifierBox.Text = "Tên học sinh không hợp lệ";
                    iNotifierBox.ShowDialog();
                    return;
                }

                if (!InputTester.IsADate(dobTb.Text))
                {
                    iNotifierBox.Text = "Ngày không hợp lệ";
                    iNotifierBox.ShowDialog();
                    return;
                }

                if (!InputTester.IsAName(countryTb.Text))
                {
                    iNotifierBox.Text = "Tên quê không hợp lệ";
                    iNotifierBox.ShowDialog();
                    return;
                }

                if (!InputTester.IsAName(parentNameTb.Text))
                {
                    iNotifierBox.Text = "Tên phụ huynh không hợp lệ";
                    iNotifierBox.ShowDialog();
                    return;
                }

                if (!InputTester.IsANumber(phoneNumberTb.Text, 10))
                {
                    iNotifierBox.Text = "Số điện thoại không hợp lệ";
                    iNotifierBox.ShowDialog();
                    return;
                }

                if (!InputTester.IsAClassName(currentClassTb.Text))
                {
                    iNotifierBox.Text = "Tên lớp không hợp lệ";
                    iNotifierBox.ShowDialog();
                    return;
                }

                Student student = new Student()
                {
                    Hoten = studentNameTb.Text,
                    GioiTinh = sexTb.Text,
                    NgaySinh = Convert.ToDateTime(dobTb.Text),
                    NoiSinh = countryTb.Text,
                    TenNgGianHo = parentNameTb.Text,
                    SDT = phoneNumberTb.Text,
                    MaLop = savedMaLop.ToString()
                };

                bool resultYN = await Controllers.Controller.Instance.InsertNewStudent(student);
                if (resultYN)
                {
                    this.Hide();
                    isCorrected = true;
                    studentNameTb.Text = "";
                    sexTb.Text = "";
                    dobTb.Text = "";
                    countryTb.Text = "";
                    parentNameTb.Text = "";
                    phoneNumberTb.Text = "";
                    currentClassTb.Text = "";
                    iNotifierBox.Text = "Thêm thành công !";
                    iNotifierBox.ShowDialog();
                }
                else
                {
                    iNotifierBox.Text = "Lỗi";
                    iNotifierBox.ShowDialog();
                }
            }
            else
            {
                iNotifierBox.Text = "Vui lòng điền đầy đủ thông tin";
                iNotifierBox.ShowDialog();
            }

        }

        public void FillCurrentClass(string TenLop)
        {
            currentClassTb.Text = TenLop;
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
        }
    }
}
