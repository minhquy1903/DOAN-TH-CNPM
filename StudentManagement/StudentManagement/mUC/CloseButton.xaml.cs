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
    /// Interaction logic for CloseButton.xaml
    /// </summary>
    public partial class CloseButton : UserControl
    {
        public CloseButton()
        {
            InitializeComponent();
        }


        //Hàm dưới dùng để sử dụng eventClick do form tự định nghĩa
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
