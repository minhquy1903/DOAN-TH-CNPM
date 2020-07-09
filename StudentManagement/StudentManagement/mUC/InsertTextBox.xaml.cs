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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace StudentManagement.mUC
{
    /// <summary>
    /// Interaction logic for InsertTextBox.xaml
    /// </summary>
    public partial class InsertTextBox : UserControl
    {
        public InsertTextBox()
        {
            InitializeComponent();
        }

        public string Text
        {
            get { return ucInsertTb.Text; }
            set { ucInsertTb.Text = value; }
        }

        private void ucInsertTb_LostFocus(object sender, RoutedEventArgs e)
        {
            ucInsertTb.Text = System.Threading.Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(ucInsertTb.Text.ToLower());
        }

        public event RoutedEventHandler TextChanged;
        private void ucInsertTb_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (this.TextChanged != null)
            {
                this.TextChanged(this, e);
            }
        }
    }
}
