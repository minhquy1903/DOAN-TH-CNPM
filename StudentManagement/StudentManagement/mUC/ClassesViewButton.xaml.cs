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
    /// Interaction logic for ClassesViewButton.xaml
    /// </summary>
    public partial class ClassesViewButton : UserControl
    {
        public ClassesViewButton()
        {
            InitializeComponent();
        }

        public string ClassName
        {
            get { return classNameTxbl.Text; }
            set { classNameTxbl.Text = value; }
        }

        public string ClassYear
        {
            get { return classYearTxbl.Text; }
            set { classYearTxbl.Text = value; }
        }

        public event RoutedEventHandler Click;
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (this.Click != null)
            {
                this.Click(this, e);
            }
        }
    }
}
