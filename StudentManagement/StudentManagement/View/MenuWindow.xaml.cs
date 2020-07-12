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
        //2 cai list nay xoa di
        List<Student> studentInfos;
        List<ClassInfo> classInfos;
        List<DemoMarkInfo> markItems;

        public bool isStudentsListViewSorted;
        public CollectionView collectionView;

        public bool isMarksListViewSorted;
        public CollectionView markCollectionView;

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

        public MenuWindow()
        {
            InitializeComponent();
            PanelClassview_Loaded();

            isStudentsListViewSorted = false;
            //List Students
            studentInfos = new List<Student>();
            studentsLv.ItemsSource = studentInfos;
            studentsLv.SelectedValuePath = "MaHS";
            studentsLv.SelectionChanged += StudentsLv_SelectionChanged;

            collectionView = (CollectionView)CollectionViewSource.GetDefaultView(studentsLv.ItemsSource);
            collectionView.Filter = StudentListviewFilter;

            //List Classes 
            classInfos = new List<ClassInfo>();

            //demo mark view
            isMarksListViewSorted = false;
            markItems = new List<DemoMarkInfo>();
            markItems.Add(new DemoMarkInfo() 
            {
                idMark = "0",
                demoSubjectName = Subject.Anh,
                demoClassName = "10A1",
                demoSemester = Semester.HọcKỳ1,
                demoType = MarkType.Kt15Phút,
                demoValue = 9.5f
            });
            markItems.Add(new DemoMarkInfo()
            {
                idMark = "1",
                demoSubjectName = Subject.Toán,
                demoClassName = "10A1",
                demoSemester = Semester.HọcKỳ1,
                demoType = MarkType.Kt45Phút,
                demoValue = 8f
            });
            markItems.Add(new DemoMarkInfo()
            {
                idMark = "2",
                demoSubjectName = Subject.Văn,
                demoClassName = "10A1",
                demoSemester = Semester.HọcKỳ1,
                demoType = MarkType.GiữaKỳ,
                demoValue = 9f
            });
            marksLv.ItemsSource = markItems;
            marksLv.SelectedValuePath = "idMark";

            markCollectionView = (CollectionView)CollectionViewSource.GetDefaultView(marksLv.ItemsSource);
            markCollectionView.Filter = MarkListviewFilter;
        }

        #region demo binding 
        private void StudentsLv_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //Neu da select thi gan cho textbox ten cua hoc sinh
            if (studentsLv.SelectedValue != null)
            {
                for (int i = 0; i < studentInfos.Count; i++)
                    if (studentInfos.ElementAt(i).MaHS.ToString() == studentsLv.SelectedValue.ToString())
                        selectedStudentTbName.Text = studentInfos.ElementAt(i).Hoten;
            }
            else
                selectedStudentTbName.Text = "";
        }

        private bool StudentListviewFilter(object item)
        {
            //thanh search
            if (String.IsNullOrEmpty(studentsLvSearchNameTb.Text))
                return true;
            else
                return ((item as Student).Hoten.IndexOf(studentsLvSearchNameTb.Text, StringComparison.OrdinalIgnoreCase) >= 0);
        }

        private bool MarkListviewFilter(object item)
        {
            //thanh search
            if (String.IsNullOrEmpty(marksLvSearchNameTb.Text))
                return true;
            else
                return ((item as DemoMarkInfo).demoSubjectName.ToString().IndexOf(marksLvSearchNameTb.Text, StringComparison.OrdinalIgnoreCase) >= 0);
        }

        private void StudentsGridViewColumnHeader_Click(object sender, RoutedEventArgs e)
        {
            //sorting
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

        private void MarksGridViewColumnHeader_Click(object sender, RoutedEventArgs e)
        {
            //sorting
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

        private void studentsLvSearchNameTb_TextChanged(object sender, TextChangedEventArgs e)
        {
            //Refresh Listview
            CollectionViewSource.GetDefaultView(studentsLv.ItemsSource).Refresh();
        }

        private void marksLvSearchNameTb_TextChanged(object sender, TextChangedEventArgs e)
        {
            CollectionViewSource.GetDefaultView(marksLv.ItemsSource).Refresh();
        }

        public enum Subject { Toán, Văn, Anh, Lí, Hoá, Sinh, Sử, Địa, GiáoDụcCôngDân, ThểDục, GiáoDụcGiớiTính}
        public enum Semester { HọcKỳ1, HọcKỳ2, HọcKỳHè}
        public enum MarkType { BàiTập, Kt15Phút, Kt45Phút, GiữaKỳ, CuốiKỳ }

        public class DemoMarkInfo
        {
            public string idMark { get; set; }
            public string demoStudentName { get; set; }
            public Subject demoSubjectName { get; set; }
            public string demoClassName { get; set; }
            public Semester demoSemester { get; set; }
            public MarkType demoType { get; set; }
            public double demoValue { get; set; }
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

        private void StudentsListviewAddStudentButton_Click(object sender, RoutedEventArgs e)
        {
            //Open ASW
            asw.ShowDialog();

            if (asw.isCorrected)
            {
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
                            ResultYN resultYN = await Controllers.Controller.Instance.DeleteStudent(Convert.ToInt32(studentsLv.SelectedValue.ToString()));

                            CollectionViewSource.GetDefaultView(studentsLv.ItemsSource).Refresh();
                            break;
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
                            studentInfos.ElementAt(i).NgaySinh,
                            studentInfos.ElementAt(i).NoiSinh,
                            studentInfos.ElementAt(i).TenNgGianHo,
                            Convert.ToInt32(studentInfos.ElementAt(i).SDT),
                            selectedClassName.Tag.ToString()); 
                        break;
                    }
                esw.ShowDialog();

                if (esw.isCorrected)
                {
                    CollectionViewSource.GetDefaultView(studentsLv.ItemsSource).Refresh();
                    esw.isCorrected = false;
                }
            }
        }

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
        }

        private void ClassesViewCheckClassButton_Click(object sender, RoutedEventArgs e)
        {
            //Open StudentListview
            if (selectedClassName.Tag != null)
            {
                HidenClassListViewToggleButton.IsChecked = true;
                studentsLvSearchNameTb.Focus();
            }
        }

        private void ClassesViewAddClassButton_Click(object sender, RoutedEventArgs e)
        {
            //Open ACW
            //AddClassesWindow acw = new AddClassesWindow();
            acw.ShowDialog();

            if(acw.isCorrected)
            {
                PanelClassview_Loaded();
                acw.isCorrected = false;
            }
        }

        private async void ClassesViewDeleteClassButton_Click(object sender, RoutedEventArgs e)
        {
            if (selectedClassName.Tag != null)
            {
                //Delete selected Class
                //MessageBoxResult result = MessageBox.Show("Do you want to delete " + selectedClassName.Text + " ?", "Delete", MessageBoxButton.OKCancel);
                //if (result == MessageBoxResult.OK)
                //{
                //    ResultYN resultYN = await Controllers.Controller.Instance.DeleteClass(Convert.ToInt32(selectedClassName.Tag.ToString()));

                //    PanelClassview_Loaded();
                //    selectedClassName.Tag = null;
                //    selectedClassName.Text = "";
                //}
                mUC.iNotifierBoxOKCancel iNotifierBoxOKCancel = new mUC.iNotifierBoxOKCancel();
                iNotifierBoxOKCancel.Text = "Do you want to delete " + selectedClassName.Text + " ?";
                iNotifierBoxOKCancel.ShowDialog();
                if(iNotifierBoxOKCancel.result == mUC.iNotifierBoxOKCancel.Result.OK)
                {
                    ResultYN resultYN = await Controllers.Controller.Instance.DeleteClass(Convert.ToInt32(selectedClassName.Tag.ToString()));

                    PanelClassview_Loaded();
                    selectedClassName.Tag = null;
                    selectedClassName.Text = "";
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

        private void StudentsListviewSearchMarksButton_Click(object sender, RoutedEventArgs e)
        {
            if (studentsLv.SelectedValue != null)
            {
                HidenClassListViewToggleButton.IsChecked = false;
                MarksViewToggleButton.IsChecked = true;
            }
        }

        private void MarksListviewAddStudentButton_Click(object sender, RoutedEventArgs e)
        {
            amw.ShowDialog();
            //Fill student name

            if (amw.isCorrected)
            {
                Subject sub = Subject.Toán;
                if (amw.subjectNameTb.Text == "Toán") sub = Subject.Toán;
                if (amw.subjectNameTb.Text == "Văn") sub = Subject.Văn;
                if (amw.subjectNameTb.Text == "Anh") sub = Subject.Anh;
                if (amw.subjectNameTb.Text == "Lí") sub = Subject.Lí;
                if (amw.subjectNameTb.Text == "Hoá") sub = Subject.Hoá;
                if (amw.subjectNameTb.Text == "Sinh") sub = Subject.Sinh;
                if (amw.subjectNameTb.Text == "Sử") sub = Subject.Sử;
                if (amw.subjectNameTb.Text == "Địa") sub = Subject.Địa;
                if (amw.subjectNameTb.Text == "GiáoDụcCôngDân") sub = Subject.GiáoDụcCôngDân;
                if (amw.subjectNameTb.Text == "ThểDục") sub = Subject.ThểDục;
                if (amw.subjectNameTb.Text == "GiáoDụcGiớiTính") sub = Subject.GiáoDụcGiớiTính;

                Semester sem = Semester.HọcKỳ1;
                if (amw.semesterTb.Text == "HọcKỳ1") sem = Semester.HọcKỳ1;
                if (amw.semesterTb.Text == "HọcKỳ2") sem = Semester.HọcKỳ2;
                if (amw.semesterTb.Text == "HọcKỳHè") sem = Semester.HọcKỳHè;

                MarkType typ = MarkType.BàiTập;
                if (amw.typeTb.Text == "BàiTập") typ = MarkType.BàiTập;
                if (amw.typeTb.Text == "Kt15Phút") typ = MarkType.Kt15Phút;
                if (amw.typeTb.Text == "Kt45Phút") typ = MarkType.Kt45Phút;
                if (amw.typeTb.Text == "GiữaKỳ") typ = MarkType.GiữaKỳ;
                if (amw.typeTb.Text == "CuốiKỳ") typ = MarkType.CuốiKỳ;
                markItems.Add(new DemoMarkInfo()
                {
                    idMark = markItems.Count.ToString(),
                    demoStudentName = amw.studentNameTb.Text,
                    demoSubjectName = sub,
                    demoClassName = amw.classNameTb.Text,
                    demoSemester = sem,
                    demoType = typ,
                    demoValue = Convert.ToDouble(amw.valueTb.Text),
                });
            }

            CollectionViewSource.GetDefaultView(marksLv.ItemsSource).Refresh();
        }

        private void MarksListviewDeleteStudentButton_Click(object sender, RoutedEventArgs e)
        {
            if (studentsLv.SelectedValue != null)
            {
                MessageBoxResult result = MessageBox.Show("Do you want to delete this mark ?", "Delete", MessageBoxButton.OKCancel);
                //Viet cau query delete o day neu select Ok
                if (result == MessageBoxResult.OK)
                {
                    for (int i = 0; i < markItems.Count; i++)
                        if (markItems.ElementAt(i).idMark == marksLv.SelectedValue.ToString())
                        {
                            markItems.RemoveAt(i);
                            CollectionViewSource.GetDefaultView(marksLv.ItemsSource).Refresh();
                            break;
                        }
                }
            }
        }

        private void MarksListviewEditStudentButton_Click(object sender, RoutedEventArgs e)
        {
            if (marksLv.SelectedValue != null)
            {
                int flag = 0;
                //Mo form va dien thong tin
                for (int i = 0; i < markItems.Count; i++)
                    if (markItems.ElementAt(i).idMark == marksLv.SelectedValue.ToString())
                    {
                        flag = i;
                        emw.FillInfo(markItems.ElementAt(i).demoStudentName,
                            markItems.ElementAt(i).demoSubjectName.ToString(),
                            markItems.ElementAt(i).demoClassName,
                            markItems.ElementAt(i).demoSemester.ToString(),
                            markItems.ElementAt(i).demoType.ToString(),
                            markItems.ElementAt(i).demoValue); //currentClass thi phai ket noi dtb class o doan chon lop
                        break;
                    }
                emw.ShowDialog();

                Subject sub = Subject.Toán;
                if (emw.subjectNameTb.Text == "Toán") sub = Subject.Toán;
                if (emw.subjectNameTb.Text == "Văn") sub = Subject.Văn;
                if (emw.subjectNameTb.Text == "Anh") sub = Subject.Anh;
                if (emw.subjectNameTb.Text == "Lí") sub = Subject.Lí;
                if (emw.subjectNameTb.Text == "Hoá") sub = Subject.Hoá;
                if (emw.subjectNameTb.Text == "Sinh") sub = Subject.Sinh;
                if (emw.subjectNameTb.Text == "Sử") sub = Subject.Sử;
                if (emw.subjectNameTb.Text == "Địa") sub = Subject.Địa;
                if (emw.subjectNameTb.Text == "GiáoDụcCôngDân") sub = Subject.GiáoDụcCôngDân;
                if (emw.subjectNameTb.Text == "ThểDục") sub = Subject.ThểDục;
                if (emw.subjectNameTb.Text == "GiáoDụcGiớiTính") sub = Subject.GiáoDụcGiớiTính;

                Semester sem = Semester.HọcKỳ1;
                if (emw.semesterTb.Text == "HọcKỳ1") sem = Semester.HọcKỳ1;
                if (emw.semesterTb.Text == "HọcKỳ2") sem = Semester.HọcKỳ2;
                if (emw.semesterTb.Text == "HọcKỳHè") sem = Semester.HọcKỳHè;

                MarkType typ = MarkType.BàiTập;
                if (emw.typeTb.Text == "BàiTập") typ = MarkType.BàiTập;
                if (emw.typeTb.Text == "Kt15Phút") typ = MarkType.Kt15Phút;
                if (emw.typeTb.Text == "Kt45Phút") typ = MarkType.Kt45Phút;
                if (emw.typeTb.Text == "GiữaKỳ") typ = MarkType.GiữaKỳ;
                if (emw.typeTb.Text == "CuốiKỳ") typ = MarkType.CuốiKỳ;

                markItems.ElementAt(flag).demoStudentName = emw.studentNameTb.Text;
                markItems.ElementAt(flag).demoSubjectName = sub;
                markItems.ElementAt(flag).demoClassName = emw.classNameTb.Text;
                markItems.ElementAt(flag).demoSemester = sem;
                markItems.ElementAt(flag).demoType = typ;
                markItems.ElementAt(flag).demoValue = Convert.ToDouble(emw.valueTb.Text);

                CollectionViewSource.GetDefaultView(marksLv.ItemsSource).Refresh();
            }
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
                Regex rx = new Regex(@"^[0 - 9.]{ 1, 3 }$");
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
