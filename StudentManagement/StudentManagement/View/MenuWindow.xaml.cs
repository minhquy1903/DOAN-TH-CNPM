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

namespace StudentManagement
{
    /// <summary>
    /// Interaction logic for MenuWindow.xaml
    /// </summary>
    public partial class MenuWindow : Window
    {
        public MenuWindow()
        {
            InitializeComponent();
        }

        private void MenuToggleButton_OnClick(object sender, RoutedEventArgs e)
        {
            SearchBox.Focus();
        }

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

        private void InfoToggleButton_MouseEnter(object sender, MouseEventArgs e)
        {
            var tbtn = sender as ToggleButton;
            tbtn.IsChecked = !tbtn.IsChecked;
        }

        private void InfoPanel_MouseLeave(object sender, MouseEventArgs e)
        {
            var tbtn = InfoToggleButton;
            tbtn.IsChecked = !tbtn.IsChecked;
        }

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
    }

    public static class CustomCommands
    {
        public static readonly RoutedUICommand Exit = new RoutedUICommand
            (
                "Exit",
                "Exit",
                typeof(CustomCommands)
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
