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
    }
}
