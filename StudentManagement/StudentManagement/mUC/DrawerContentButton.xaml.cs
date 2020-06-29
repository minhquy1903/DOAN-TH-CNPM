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
    /// Interaction logic for DrawerContentButton.xaml
    /// </summary>
    public partial class DrawerContentButton : UserControl
    {
        public DrawerContentButton()
        {
            InitializeComponent();
        }

        //Phải truyền qua trung gian do 2 properties này không nhận đc từ view
        public object edittedContent
        {
            get { return dcBtn.Content; }
            set { dcBtn.Content = value; }
        }
        public object edittedTag
        {
            get { return dcBtn.Tag; }
            set { dcBtn.Tag = value; }
        }

        private void DrawerContentButton_Click(object sender, RoutedEventArgs e)
        {
            var btn = sender as Button;
            switch (btn.Tag.ToString())
            {
                case "Search Marks":
                    SearchMarksWindow smw = new SearchMarksWindow();
                    smw.ShowDialog();
                    break;
                case "Search Students":
                    SearchStudentsWindow ssw = new SearchStudentsWindow();
                    ssw.ShowDialog();
                    break;
                case "Search Subjects":
                    SearchSubjectsWindow ssjw = new SearchSubjectsWindow();
                    ssjw.ShowDialog();
                    break;
                case "Search Classes":
                    SearchClassesWindow scw = new SearchClassesWindow();
                    scw.ShowDialog();
                    break;
                case "Add Marks":
                    AddMarksWindow amw = new AddMarksWindow();
                    amw.ShowDialog();
                    break;
                case "Add Students":
                    AddStudentsWindow asw = new AddStudentsWindow();
                    asw.ShowDialog();
                    break;
                case "Add Subjects":
                    AddSubjectsWindow asjw = new AddSubjectsWindow();
                    asjw.ShowDialog();
                    break;
                case "Add Classes":
                    AddClassesWindow acw = new AddClassesWindow();
                    acw.ShowDialog();
                    break;
                case "Delete Marks":
                    DeleteMarksWindow dmw = new DeleteMarksWindow();
                    dmw.ShowDialog();
                    break;
                case "Delete Students":
                    DeleteStudentsWindow dsw = new DeleteStudentsWindow();
                    dsw.ShowDialog();
                    break;
                case "Delete Subjects":
                    DeleteSubjectsWindow dsjw = new DeleteSubjectsWindow();
                    dsjw.ShowDialog();
                    break;
                case "Delete Classes":
                    DeleteClassesWindow dcw = new DeleteClassesWindow();
                    dcw.ShowDialog();
                    break;
                case "Edit Marks":
                    EditMarksWindow emw = new EditMarksWindow();
                    emw.ShowDialog();
                    break;
                case "Edit Students":
                    EditStudentsWindow esw = new EditStudentsWindow();
                    esw.ShowDialog();
                    break;
                case "Edit Subjects":
                    EditSubjectsWindow esjw = new EditSubjectsWindow();
                    esjw.ShowDialog();
                    break;
                case "Edit Classes":
                    EditClassesWindow ecw = new EditClassesWindow();
                    ecw.ShowDialog();
                    break;
            }
        }
    }
}
