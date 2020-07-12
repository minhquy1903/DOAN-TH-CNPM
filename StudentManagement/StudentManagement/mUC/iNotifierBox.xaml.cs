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

namespace StudentManagement.mUC
{
    /// <summary>
    /// Interaction logic for iNotifierBox.xaml
    /// </summary>
    public partial class iNotifierBox : Window
    {
        public iNotifierBox()
        {
            InitializeComponent();
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
        }

        private void OKBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
        }

        public string Text
        {
            get { return textTbl.Text; }
            set { textTbl.Text = value; }
        }

        private void OKBtn_MouseEnter(object sender, MouseEventArgs e)
        {
            OKBdr.Background = Brushes.LightGreen;
        }

        private void OKBtn_MouseLeave(object sender, MouseEventArgs e)
        {
            OKBdr.Background = Brushes.LightBlue;
        }
    }
}
