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
using MaterialDesignThemes.Wpf;
using System.Windows.Controls.Primitives;
using System.ComponentModel;

namespace StudentManagement
{
    /// <summary>
    /// Interaction logic for MenuWindow.xaml
    /// </summary>
    public partial class MenuWindow : Window
    {
        public bool isStudentsListViewSorted;
        public CollectionView collectionView;
        public MenuWindow()
        {
            InitializeComponent();

            //demo binding for Listview of Student (understand ? -> delete)
            isStudentsListViewSorted = false;
            List<DemoStudentInfo> items = new List<DemoStudentInfo>();
            items.Add(new DemoStudentInfo() { 
                demoStudentName = "Nguyen Minh Thang", 
                demoSex = Sex.Male, 
                demoDoB = 11223344, 
                demoCountry = "Los Angles", 
                demoParentName = "God", 
                demoPhoneNb = 0123456789 });
            items.Add(new DemoStudentInfo()
            {
                demoStudentName = "Vo Minh Quy",
                demoSex = Sex.Male,
                demoDoB = 44332211,
                demoCountry = "California",
                demoParentName = "Lucifer",
                demoPhoneNb = 0951623847
            });
            items.Add(new DemoStudentInfo()
            {
                demoStudentName = "Nguyen Pham Minh Nhat",
                demoSex = Sex.Male,
                demoDoB = 11223344,
                demoCountry = "China",
                demoParentName = "Zeus",
                demoPhoneNb = 0321654987
            });
            items.Add(new DemoStudentInfo()
            {
                demoStudentName = "Ngoc Trinh",
                demoSex = Sex.Female,
                demoDoB = 16161616,
                demoCountry = "Thang's House",
                demoParentName = "Thang's Neighborhood",
                demoPhoneNb = 0999999999
            });
            studentsLv.ItemsSource = items;
            studentsLv.SelectedValuePath = "demoStudentName";

            collectionView = (CollectionView)CollectionViewSource.GetDefaultView(studentsLv.ItemsSource);
            collectionView.Filter = StudentListviewFilter;
        }

        private bool StudentListviewFilter(object item)
        {
            if (String.IsNullOrEmpty(studentsLvSearchNameTb.Text))
                return true;
            else
                return ((item as DemoStudentInfo).demoStudentName.IndexOf(studentsLvSearchNameTb.Text, StringComparison.OrdinalIgnoreCase) >= 0);
        }

        #region demo binding 
        private void GridViewColumnHeader_Click(object sender, RoutedEventArgs e)
        {
            //Giu cai nay lai vi van dung
            GridViewColumnHeader header = sender as GridViewColumnHeader;
            if(isStudentsListViewSorted)
            {
                collectionView.SortDescriptions.Clear();
                collectionView.SortDescriptions.Add(new SortDescription(header.Content.ToString(), ListSortDirection.Ascending));
            }
            else
            {
                collectionView.SortDescriptions.Clear();
                collectionView.SortDescriptions.Add(new SortDescription(header.Content.ToString(), ListSortDirection.Descending));
            }
            isStudentsListViewSorted = !isStudentsListViewSorted;
        }

        private void studentsLvSearchNameTb_TextChanged(object sender, TextChangedEventArgs e)
        {
            CollectionViewSource.GetDefaultView(studentsLv.ItemsSource).Refresh();
        }

        //Cai nay se la DTO c lay tu dtb
        public enum Sex { Male, Female };

        public class DemoStudentInfo
        {
            public string demoStudentName { get; set; }
            public Sex demoSex { get; set; }
            public int demoDoB { get; set; }
            public string demoCountry { get; set; }
            public string demoParentName { get; set; }
            public int demoPhoneNb { get; set; }
        }
        #endregion

        //Mo Left Drawer Content se focus vao thanh Search
        private void MenuToggleButton_OnClick(object sender, RoutedEventArgs e)
        {
            SearchBox.Focus();
        }

        #region ThemeButton
        private void MenuDarkModeButton_Click(object sender, RoutedEventArgs e)
        {
            ModifyTheme(theme => theme.SetBaseTheme(DarkModeToggleButton.IsChecked == true ? Theme.Dark : Theme.Light));
        }

        private static void ModifyTheme(Action<ITheme> modificationAction)
        {
            PaletteHelper paletteHelper = new PaletteHelper();
            ITheme theme = paletteHelper.GetTheme();

            modificationAction?.Invoke(theme);

            paletteHelper.SetTheme(theme);
        }
        #endregion

        //TreeView 
        private void TreeView_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            if (((TreeViewItem)e.NewValue).Tag != null)
            {
                switch(((TreeViewItem)e.NewValue).Tag.ToString())
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

        #region Open Panels 
        private void ChangeCheckedToggleButton_MouseEnter(object sender, MouseEventArgs e)
        {
            var tbtn = sender as ToggleButton;
            tbtn.IsChecked = !tbtn.IsChecked;
        }

        private void ChangeCheckedPanel_MouseLeave(object sender, MouseEventArgs e)
        {
            InfoToggleButton.IsChecked = false;
        }

        private void ClassesViewButton_Click(object sender, RoutedEventArgs e)
        {
            ClassesViewToggleButton.IsChecked = false;
            HidenClassListViewToggleButton.IsChecked = true;
            studentsLvSearchNameTb.Focus();
        }
        #endregion

        #region Commands Execute
        private void ExitCmd_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void LogOutCmd_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            LoginWindow lwd = new LoginWindow();
            lwd.Show();
            this.Close();
        }
        #endregion

        private void StudentsListviewAddStudentButton_Click(object sender, RoutedEventArgs e)
        {
            AddStudentsWindow asw = new AddStudentsWindow();
            asw.ShowDialog();
        }

        private void StudentsListviewDeleteStudentButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Do you want to delete " + studentsLv.SelectedValue.ToString() +" ?", "Delete", MessageBoxButton.OKCancel);
            //Viet cau query delete o day neu select Ok
            if(result == MessageBoxResult.OK)
            {
                MessageBox.Show("Viet cau query xoa trong nay");
            }
        }

        private void StudentsListviewEditStudentButton_Click(object sender, RoutedEventArgs e)
        {
            EditStudentsWindow esw = new EditStudentsWindow();
            esw.SetStudentName(studentsLv.SelectedValue.ToString());
            esw.ShowDialog();
        }
    }

    //Custom Commands for the whole app (in this namespace)
    public static class CustomCommands
    {
        public static readonly RoutedUICommand Exit = new RoutedUICommand
            (
                "Exit",
                "Exit",
                typeof(CustomCommands),
                new InputGestureCollection()
                {
                    new KeyGesture(Key.Escape)
                }
            );
        public static readonly RoutedUICommand LogOut = new RoutedUICommand
            (
                "Logout",
                "Logout",
                typeof(CustomCommands)
            );
        public static readonly RoutedUICommand CloseWindow = new RoutedUICommand
            (
                "CloseWindow",
                "CloseWindow",
                typeof(CustomCommands)
            );
    }
}
