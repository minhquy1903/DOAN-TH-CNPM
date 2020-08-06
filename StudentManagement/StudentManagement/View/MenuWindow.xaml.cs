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
using System.Text.RegularExpressions;
using DTO;
using StudentManagement.Controllers;

namespace StudentManagement
{
    /// <summary>
    /// Interaction logic for MenuWindow.xaml
    /// </summary>
    public partial class MenuWindow : Window
    {
        //List will get from dtb
        List<Student> studentInfos;
        List<ClassInfo> classInfos;
        List<StudentMark> markInfos;

        //CollectionView and Sorting Props 
        public bool isStudentsListViewSorted;
        public CollectionView collectionView;

        public bool isMarksListViewSorted;
        public CollectionView markCollectionView;

        //Create window 1 time
        AddMarksWindow amw = new AddMarksWindow();
        AddStudentsWindow asw = new AddStudentsWindow();
        AddSubjectsWindow asjw = new AddSubjectsWindow();
        AddClassesWindow acw = new AddClassesWindow();
        DeleteMarksWindow dmw = new DeleteMarksWindow();
        DeleteStudentsWindow dsw = new DeleteStudentsWindow();
        DeleteSubjectsWindow dsjw = new DeleteSubjectsWindow();
        DeleteClassesWindow dcw = new DeleteClassesWindow();
        EditMarksWindow emw = new EditMarksWindow();
        EditStudentsWindow esw = new EditStudentsWindow();
        EditSubjectsWindow esjw = new EditSubjectsWindow();
        EditClassesWindow ecw = new EditClassesWindow();
        mUC.iNotifierBox iNotifierBox = new mUC.iNotifierBox();

        public MenuWindow()
        {
            InitializeComponent();

            //Load Classview
            PanelClassview_Loaded();


            //List Students things
            isStudentsListViewSorted = false;
            studentInfos = new List<Student>();
            //studentsLv.ItemsSource = studentInfos;
            studentsLv.SelectedValuePath = "MaHS";
            studentsLv.SelectionChanged += StudentsLv_SelectionChanged;

            //collectionView = (CollectionView)CollectionViewSource.GetDefaultView(studentsLv.ItemsSource);
            //collectionView.Filter = StudentListviewFilter;


            //List Classes 
            classInfos = new List<ClassInfo>();


            //demo mark view
            isMarksListViewSorted = false;
            markInfos = new List<StudentMark>();
            //marksLv.ItemsSource = markInfos;
            marksLv.SelectedValuePath = "maDiem";

            //markCollectionView = (CollectionView)CollectionViewSource.GetDefaultView(marksLv.ItemsSource);
            //markCollectionView.Filter = MarkListviewFilter;
        }

        #region demo binding 
        //Textbox get the Collected student
        private void StudentsLv_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (studentsLv.SelectedValue != null)
            {
                for (int i = 0; i < studentInfos.Count; i++)
                    if (studentInfos.ElementAt(i).MaHS.ToString() == studentsLv.SelectedValue.ToString())
                        selectedStudentTbName.Text = studentInfos.ElementAt(i).Hoten;
            }
            else
                selectedStudentTbName.Text = "";
        }

        //Listviews' Filter
        private bool StudentListviewFilter(object item)
        {
            if (String.IsNullOrEmpty(studentsLvSearchNameTb.Text))
                return true;
            else
                return ((item as Student).Hoten.IndexOf(studentsLvSearchNameTb.Text, StringComparison.OrdinalIgnoreCase) >= 0);
        }

        private bool MarkListviewFilter(object item)
        {
            if (String.IsNullOrEmpty(marksLvSearchNameTb.Text))
                return true;
            else
                return ((item as StudentMark).maMonHoc.IndexOf(marksLvSearchNameTb.Text, StringComparison.OrdinalIgnoreCase) >= 0);
        }

        //Listviews' Sorter
        private void StudentsGridViewColumnHeader_Click(object sender, RoutedEventArgs e)
        {
            GridViewColumnHeader header = sender as GridViewColumnHeader;
            if (isStudentsListViewSorted)
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

        private void MarksGridViewColumnHeader_Click(object sender, RoutedEventArgs e)
        {
            GridViewColumnHeader header = sender as GridViewColumnHeader;
            if (isMarksListViewSorted)
            {
                markCollectionView.SortDescriptions.Clear();
                markCollectionView.SortDescriptions.Add(new SortDescription(header.Content.ToString(), ListSortDirection.Ascending));
            }
            else
            {
                markCollectionView.SortDescriptions.Clear();
                markCollectionView.SortDescriptions.Add(new SortDescription(header.Content.ToString(), ListSortDirection.Descending));
            }
            isMarksListViewSorted = !isMarksListViewSorted;
        }

        //Refresh listviews while searching
        private void studentsLvSearchNameTb_TextChanged(object sender, TextChangedEventArgs e)
        {
            CollectionViewSource.GetDefaultView(studentsLv.ItemsSource).Refresh();
        }

        private void marksLvSearchNameTb_TextChanged(object sender, TextChangedEventArgs e)
        {
            CollectionViewSource.GetDefaultView(marksLv.ItemsSource).Refresh();
        }
        #endregion

        public void CheckTypeAccount(string type) 
        {
            if (type != "Giáo Viên")
            {
                ClassesViewAddClassButton.IsEnabled = false;
                StudentsListviewAddStudentButton.IsEnabled = false;
                MarksListviewAddStudentButton.IsEnabled = false;
            }
            else
            {
                ClassesViewAddClassButton.IsEnabled = true;
                StudentsListviewAddStudentButton.IsEnabled = true;
                MarksListviewAddStudentButton.IsEnabled = true;
            }

        }

        #region ThemeButton
        private void MenuDarkModeButton_Click(object sender, RoutedEventArgs e)
        {
            ModifyTheme(theme => theme.SetBaseTheme(DarkModeToggleButton.IsChecked == true ? Theme.Dark : Theme.Light));

            //This with hard-setting Background from Owner make Binding of SearchBar's background works smoother
            if (DarkModeToggleButton.IsChecked == true)
            {
                Brush darkBG = (Brush)Application.Current.Resources["darkBackgroundThemeColor"];
                StudentViewPanel.Background = darkBG;
                ToolPanel.Background = darkBG;
                MarksViewPanel.Background = darkBG;
            }
            else
            {
                Brush lightBG = (Brush)Application.Current.Resources["backgroundThemeColor"];
                StudentViewPanel.Background = lightBG;
                ToolPanel.Background = lightBG;
                MarksViewPanel.Background = lightBG;
            }

        }

        private static void ModifyTheme(Action<ITheme> modificationAction)
        {
            PaletteHelper paletteHelper = new PaletteHelper();
            ITheme theme = paletteHelper.GetTheme();

            modificationAction?.Invoke(theme);

            paletteHelper.SetTheme(theme);
        }
        #endregion

        #region Left Treeview

        private void MenuToggleButton_OnClick(object sender, RoutedEventArgs e)
        {
            SearchBox.Focus();
        }

        //TreeView 
        private void TreeView_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            if (((TreeViewItem)e.NewValue).Tag != null)
            {
                switch (((TreeViewItem)e.NewValue).Tag.ToString())
                {
                    case "Add Marks":
                        amw.ShowDialog();
                        break;
                    case "Add Students":
                        asw.ShowDialog();
                        break;
                    case "Add Subjects":
                        asjw.ShowDialog();
                        break;
                    case "Add Classes":
                        acw.ShowDialog();
                        break;
                    case "Delete Marks":
                        dmw.ShowDialog();
                        break;
                    case "Delete Students":
                        dsw.ShowDialog();
                        break;
                    case "Delete Subjects":
                        dsjw.ShowDialog();
                        break;
                    case "Delete Classes":
                        dcw.ShowDialog();
                        break;
                    case "Edit Marks":
                        emw.ShowDialog();
                        break;
                    case "Edit Students":
                        esw.ShowDialog();
                        break;
                    case "Edit Subjects":
                        esjw.ShowDialog();
                        break;
                    case "Edit Classes":
                        ecw.ShowDialog();
                        break;
                }
            }
        }
        #endregion

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

        #region Student Listview Control
        private async void studentsLv_Loaded()
        {
            //Get Students from dtb
            if (selectedClassName.Tag != null)
                studentInfos = await Controller.Instance.GetAllStudent(Convert.ToInt32(selectedClassName.Tag));
            studentsLv.ItemsSource = studentInfos;
            //Refresh 1 time
            CollectionViewSource.GetDefaultView(studentsLv.ItemsSource).Refresh();
            //Setting CollectionView for Sorting and Filtering
            collectionView = (CollectionView)CollectionViewSource.GetDefaultView(studentsLv.ItemsSource);
            //Filtering
            collectionView.Filter = StudentListviewFilter;
        }

        private void StudentsListviewAddStudentButton_Click(object sender, RoutedEventArgs e)
        {
            //Open ASW
            asw.FillCurrentClass(selectedClassName.Text);
            asw.savedMaLop = Convert.ToInt32(selectedClassName.Tag);
            asw.ShowDialog();

            if (asw.isCorrected)
            {
                studentsLv_Loaded();
                CollectionViewSource.GetDefaultView(studentsLv.ItemsSource).Refresh();
                asw.isCorrected = false;
            }
        }

        private async void StudentsListviewDeleteStudentButton_Click(object sender, RoutedEventArgs e)
        {
            if (studentsLv.SelectedValue != null)
            {
                //Delete selected Student
                mUC.iNotifierBoxOKCancel iNotifierBoxOKCancel = new mUC.iNotifierBoxOKCancel();
                iNotifierBoxOKCancel.Text = "Do you want to delete " + selectedStudentTbName.Text + " ?";
                iNotifierBoxOKCancel.ShowDialog();
                if (iNotifierBoxOKCancel.result == mUC.iNotifierBoxOKCancel.Result.OK)
                {
                    for (int i = 0; i < studentInfos.Count; i++)
                        if (studentInfos.ElementAt(i).MaHS.ToString() == studentsLv.SelectedValue.ToString())
                        {
                            bool resultYN = await Controllers.Controller.Instance.DeleteStudent(Convert.ToInt32(studentsLv.SelectedValue.ToString()));
                            if (resultYN)
                            {
                                studentsLv_Loaded();
                                CollectionViewSource.GetDefaultView(studentsLv.ItemsSource).Refresh();
                                iNotifierBox.Text = "Xoá thành công !";
                                iNotifierBox.ShowDialog();
                                break;
                            }
                            else
                            {
                                iNotifierBox.Text = "Lỗi";
                                iNotifierBox.ShowDialog();
                            }
                        }
                }
            }
        }

        private void StudentsListviewEditStudentButton_Click(object sender, RoutedEventArgs e)
        {
            if (studentsLv.SelectedValue != null)
            {
                //Fill info into ESW
                for (int i = 0; i < studentInfos.Count; i++)
                    if (studentInfos.ElementAt(i).MaHS.ToString() == studentsLv.SelectedValue.ToString())
                    {
                        esw.FillInfo(studentInfos.ElementAt(i).Hoten,
                            studentInfos.ElementAt(i).GioiTinh,
                            studentInfos.ElementAt(i).NgaySinh.ToString(),
                            studentInfos.ElementAt(i).NoiSinh,
                            studentInfos.ElementAt(i).TenNgGianHo,
                            Convert.ToInt32(studentInfos.ElementAt(i).SDT),
                            selectedClassName.Text);
                        break;
                    }
                esw.ShowDialog();

                if (esw.isCorrected)
                {
                    studentsLv_Loaded();
                    CollectionViewSource.GetDefaultView(studentsLv.ItemsSource).Refresh();
                    esw.isCorrected = false;
                }
            }
        }
        #endregion

        #region ClassesView Control
        private async void PanelClassview_Loaded()
        {
            panelClassview.Children.RemoveRange(0, panelClassview.Children.Count);
            classInfos = await Controller.Instance.GetAllClass();
            List<mUC.ClassesViewButton> classesViewButtons = new List<mUC.ClassesViewButton>();
            int ListSize = classInfos.Count;
            for (int i = 0; i < ListSize; i++)
            {
                mUC.ClassesViewButton cvBtn = new mUC.ClassesViewButton();
                cvBtn.IdClass = classInfos.ElementAt(i).maLop;
                cvBtn.ClassName = classInfos.ElementAt(i).tenLop;
                cvBtn.ClassYear = classInfos.ElementAt(i).nienKhoa;
                cvBtn.Click += ClassesViewButton_Click;
                classesViewButtons.Add(cvBtn);
                panelClassview.Children.Add(cvBtn);
            }
        }

        private void ClassesViewButton_Click(object sender, RoutedEventArgs e)
        {
            //Save Id of Class selected
            var btn = sender as mUC.ClassesViewButton;
            selectedClassName.Tag = btn.IdClass.ToString(); //prop Tag t se dung de luu Id luon cho tien., khoi phai tao bien ngoai`
            selectedClassName.Text = btn.ClassName;
            //studentsLv_Loaded();
        }

        private void ClassesViewCheckClassButton_Click(object sender, RoutedEventArgs e)
        {
            //Open StudentListview
            if (selectedClassName.Tag != null)
            {
                HidenClassListViewToggleButton.IsChecked = true;
                studentsLvSearchNameTb.Focus();
                studentsLv_Loaded();
            }
        }

        private void ClassesViewAddClassButton_Click(object sender, RoutedEventArgs e)
        {
            //Open ACW
            //AddClassesWindow acw = new AddClassesWindow();
            acw.ShowDialog();

            if (acw.isCorrected)
            {
                PanelClassview_Loaded();
                acw.isCorrected = false;
            }
        }

        private async void ClassesViewDeleteClassButton_Click(object sender, RoutedEventArgs e)
        {
            if (selectedClassName.Tag != null)
            {
                mUC.iNotifierBoxOKCancel iNotifierBoxOKCancel = new mUC.iNotifierBoxOKCancel();
                iNotifierBoxOKCancel.Text = "Do you want to delete " + selectedClassName.Text + " ?";
                iNotifierBoxOKCancel.ShowDialog();
                if (iNotifierBoxOKCancel.result == mUC.iNotifierBoxOKCancel.Result.OK)
                {
                    bool resultYN = await Controllers.Controller.Instance.DeleteClass(Convert.ToInt32(selectedClassName.Tag.ToString()));
                    if (resultYN)
                    {
                        PanelClassview_Loaded();
                        selectedClassName.Tag = null;
                        selectedClassName.Text = "";
                        iNotifierBox.Text = "Xoá thành công !";
                        iNotifierBox.ShowDialog();
                    }
                    else
                    {
                        iNotifierBox.Text = "Lỗi";
                        iNotifierBox.ShowDialog();
                    }
                }
            }
        }

        private void ClassesViewEditClassButton_Click(object sender, RoutedEventArgs e)
        {
            if (selectedClassName.Tag != null)
            {
                //Fill info selected class into ECW
                for (int i = 0; i < classInfos.Count; i++)
                    if (classInfos.ElementAt(i).maLop == Convert.ToInt32(selectedClassName.Tag))
                    {
                        ecw.FillInfo(classInfos.ElementAt(i).tenLop,
                            Convert.ToInt32(classInfos.ElementAt(i).khoi),
                            classInfos.ElementAt(i).tenGVCN,
                            classInfos.ElementAt(i).siSo,
                            Convert.ToInt32(classInfos.ElementAt(i).nienKhoa));
                        break;
                    }
                ecw.ShowDialog();

                if (ecw.isCorrected)
                {
                    PanelClassview_Loaded();
                    ecw.isCorrected = false;
                }
            }
        }
        #endregion

        #region Mark Listview Control
        //Button SearchMark at Student Listview
        private void StudentsListviewSearchMarksButton_Click(object sender, RoutedEventArgs e)
        {
            if (studentsLv.SelectedValue != null)
            {
                HidenClassListViewToggleButton.IsChecked = false;
                MarksViewToggleButton.IsChecked = true;
            }
        }

        private async void marksLv_Loaded()
        {
            //Get marks from dtb
            if(studentsLv.SelectedValue != null)
                markInfos = await Controller.Instance.GetAllMark(Convert.ToInt32(studentsLv.SelectedValue));
            marksLv.ItemsSource = markInfos;
            //Refresh 1 time
            CollectionViewSource.GetDefaultView(marksLv.ItemsSource).Refresh();
            //Setting CollectionView for Sorting and Filtering
            markCollectionView = (CollectionView)CollectionViewSource.GetDefaultView(marksLv.ItemsSource);
            //Filtering
            markCollectionView.Filter = MarkListviewFilter;
        }

        private void MarksListviewAddStudentButton_Click(object sender, RoutedEventArgs e)
        {
            amw.FillSelectedItem(selectedStudentTbName.Text, selectedClassName.Text);
            amw.savedMaHS = Convert.ToInt32(studentsLv.SelectedValue);
            amw.savedMaLop = Convert.ToInt32(selectedClassName.Tag);
            amw.ShowDialog();

            if (amw.isCorrected)
            {
                marksLv_Loaded();
                CollectionViewSource.GetDefaultView(marksLv.ItemsSource).Refresh();
                amw.isCorrected = false;
            }
        }

        private void MarksListviewDeleteStudentButton_Click(object sender, RoutedEventArgs e)
        {
            if (studentsLv.SelectedValue != null)
            {
                MessageBoxResult result = MessageBox.Show("Do you want to delete this mark ?", "Delete", MessageBoxButton.OKCancel);
                //Viet cau query delete o day neu select Ok
                if (result == MessageBoxResult.OK)
                {
                }
            }
        }

        private void MarksListviewEditStudentButton_Click(object sender, RoutedEventArgs e)
        {
            if (marksLv.SelectedValue != null)
            {
                //Mo form va dien thong tin

                emw.ShowDialog();

                CollectionViewSource.GetDefaultView(marksLv.ItemsSource).Refresh();
            }
        }
        #endregion
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

    public static class InputTester
    {
        public static bool IsAName(string str)
        {
            //is a name without number and less than 40 characters
            try
            {
                Regex rx = new Regex(@"^[aAàÀảẢãÃáÁạẠăĂằẰẳẲẵẴắẮặẶâÂầẦẩẨẫẪấẤậẬbBcCdDđĐeEèÈẻẺẽẼéÉẹẸêÊềỀểỂễỄếẾệỆ
fFgGhHiIìÌỉỈĩĨíÍịỊjJkKlLmMnNoOòÒỏỎõÕóÓọỌôÔồỒổỔỗỖốỐộỘơƠờỜởỞỡỠớỚợỢpPqQrRsStTu
UùÙủỦũŨúÚụỤưƯừỪửỬữỮứỨựỰvVwWxXyYỳỲỷỶỹỸýÝỵỴzZ\s]{1,40}$");
                return rx.IsMatch(str);
            }
            catch (FormatException)
            {
                return false;
            }
        }

        public static bool IsANumber(string str, int maxDigit = 0)
        {
            //is number and less than maxDigit digits
            string pattern = "^[0-9]{1," + maxDigit + "}$";
            try
            {
                Regex rx = new Regex(@pattern);
                return rx.IsMatch(str);
            }
            catch (FormatException)
            {
                return false;
            }
        }

        public static bool IsAFloatNumber(string str)
        {
            try
            {
                Regex rx = new Regex(@"^[0-9.]{1,3}$");
                return rx.IsMatch(str);
            }
            catch (FormatException)
            {
                return false;
            }
        }

        public static bool IsAClassName(string str)
        {
            //A class name include a-z A-Z 0-9 and less than 4 digits
            try
            {
                Regex rx = new Regex(@"^[a-zA-Z0-9]{1,4}$");
                return rx.IsMatch(str);
            }
            catch (FormatException)
            {
                return false;
            }
        }

        public static bool IsADate(string str)
        {
            //A date with DD/MM/YYYY
            try
            {
                Regex rx = new Regex(@"^(?:(?:31(\/|-|\.)(?:0?[13578]|1[02]))\1|(?:(?:29|30)(\/|-|\.)(?:0?[1,3-9]|1[0-2])\2))(?:(?:1[6-9]|[2-9]\d)?\d{2})$|^(?:29(\/|-|\.)0?2\3(?:(?:(?:1[6-9]|[2-9]\d)?(?:0[48]|[2468][048]|[13579][26])|(?:(?:16|[2468][048]|[3579][26])00))))$|^(?:0?[1-9]|1\d|2[0-8])(\/|-|\.)(?:(?:0?[1-9])|(?:1[0-2]))\4(?:(?:1[6-9]|[2-9]\d)?\d{2})$");
                return rx.IsMatch(str);
            }
            catch (FormatException)
            {
                return false;
            }
        }
    }
}