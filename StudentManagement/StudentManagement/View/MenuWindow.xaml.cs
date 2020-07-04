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
        //2 cai list nay xoa di
        List<DemoStudentInfo> items;
        List<DemoClassInfo> classItems;

        public bool isStudentsListViewSorted;
        public CollectionView collectionView;

        public MenuWindow()
        {
            InitializeComponent();

            //demo binding for Listview of Student (understand ? -> delete)
            isStudentsListViewSorted = false;
            items = new List<DemoStudentInfo>();
            items.Add(new DemoStudentInfo() 
            { 
                idStudent = "0",
                demoStudentName = "Nguyen Minh Thang", 
                demoSex = Sex.Male, 
                demoDoB = "1/1/2000", 
                demoCountry = "Los Angles", 
                demoParentName = "God", 
                demoPhoneNb = 0123456789 });
            items.Add(new DemoStudentInfo()
            {
                idStudent = "1",
                demoStudentName = "Vo Minh Quy",
                demoSex = Sex.Male,
                demoDoB = "2/2/2222",
                demoCountry = "California",
                demoParentName = "Lucifer",
                demoPhoneNb = 0951623847
            });
            items.Add(new DemoStudentInfo()
            {
                idStudent = "2",
                demoStudentName = "Nguyen Pham Minh Nhat",
                demoSex = Sex.Male,
                demoDoB = "3/3/2222",
                demoCountry = "China",
                demoParentName = "Zeus",
                demoPhoneNb = 0321654987
            });
            items.Add(new DemoStudentInfo()
            {
                idStudent = "3",
                demoStudentName = "Ngoc Trinh",
                demoSex = Sex.Female,
                demoDoB = "4/4/1999",
                demoCountry = "Thang's House",
                demoParentName = "Thang's Neighborhood",
                demoPhoneNb = 0999999999
            });
            items.Add(new DemoStudentInfo()
            {
                idStudent = "4",
                demoStudentName = "Ngoc Trinh",
                demoSex = Sex.Female,
                demoDoB = "5/5/1999",
                demoCountry = "Thang's House",
                demoParentName = "Thang's Neighborhood",
                demoPhoneNb = 0111111111
            });
            studentsLv.ItemsSource = items;
            studentsLv.SelectedValuePath = "idStudent";
            studentsLv.SelectionChanged += StudentsLv_SelectionChanged;

            collectionView = (CollectionView)CollectionViewSource.GetDefaultView(studentsLv.ItemsSource);
            collectionView.Filter = StudentListviewFilter;

            //demo class view
            classItems = new List<DemoClassInfo>();
            classItems.Add(new DemoClassInfo() 
            { 
                idClass = "0", 
                demoClassName = "10A1", 
                demoGrade = 10, 
                demoTeacher = "AAA", 
                demoCount = 30, 
                demoYear = 2020 
            });
            classItems.Add(new DemoClassInfo()
            {
                idClass = "1",
                demoClassName = "10A2",
                demoGrade = 10,
                demoTeacher = "BBB",
                demoCount = 30,
                demoYear = 2019
            });
            classItems.Add(new DemoClassInfo()
            {
                idClass = "2",
                demoClassName = "11A1",
                demoGrade = 11,
                demoTeacher = "CCC",
                demoCount = 30,
                demoYear = 2020
            });
            classItems.Add(new DemoClassInfo()
            {
                idClass = "3",
                demoClassName = "12A1",
                demoGrade = 11,
                demoTeacher = "CCC",
                demoCount = 30,
                demoYear = 2020
            });
        }

        #region demo binding 
        private void StudentsLv_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //Neu da select thi gan cho textbox ten cua hoc sinh
            if (studentsLv.SelectedValue != null)
            {
                for (int i = 0; i < items.Count; i++)
                    if (items.ElementAt(i).idStudent == studentsLv.SelectedValue.ToString())
                        selectedStudentTbName.Text = items.ElementAt(i).demoStudentName;
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
                return ((item as DemoStudentInfo).demoStudentName.IndexOf(studentsLvSearchNameTb.Text, StringComparison.OrdinalIgnoreCase) >= 0);
        }

        private void GridViewColumnHeader_Click(object sender, RoutedEventArgs e)
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

        private void studentsLvSearchNameTb_TextChanged(object sender, TextChangedEventArgs e)
        {
            //refresh (ho tro thanh search)
            CollectionViewSource.GetDefaultView(studentsLv.ItemsSource).Refresh();
        }

        //Xoa 2 cai nay
        public enum Sex { Male, Female };

        public class DemoStudentInfo
        {
            public string idStudent { get; set; }
            public string demoStudentName { get; set; }
            public Sex demoSex { get; set; }
            public string demoDoB { get; set; }
            public string demoCountry { get; set; }
            public string demoParentName { get; set; }
            public int demoPhoneNb { get; set; }
        }
        #endregion
        public class DemoClassInfo
        {
            public string idClass { get; set; }
            public string demoClassName { get; set; }
            public int demoGrade { get; set; }
            public string demoTeacher { get; set; }
            public int demoCount { get; set; }
            public int demoYear { get; set; }
        }

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

            if (asw.studentNameTb.Text != "" &&
                  asw.sexTb.Text != "" &&
                  asw.dobTb.Text != "" &&
                  asw.countryTb.Text != "" &&
                  asw.parentNameTb.Text != "" &&
                  asw.phoneNumberTb.Text != "" &&
                  asw.currentClassTb.Text != "")
            {
                Sex temp = Sex.Male;
                if (asw.sexTb.Text == "Male") temp = Sex.Male;
                if (asw.sexTb.Text == "Female") temp = Sex.Female;
                items.Add(new DemoStudentInfo()
                {
                    idStudent = items.Count.ToString(),
                    demoStudentName = asw.studentNameTb.Text,
                    demoSex = temp,
                    demoDoB = asw.dobTb.Text,
                    demoCountry = asw.countryTb.Text,
                    demoParentName = asw.parentNameTb.Text,
                    demoPhoneNb = Convert.ToInt32(asw.phoneNumberTb.Text),
                });
            }

            CollectionViewSource.GetDefaultView(studentsLv.ItemsSource).Refresh();
        }

        private void StudentsListviewDeleteStudentButton_Click(object sender, RoutedEventArgs e)
        {
            if (studentsLv.SelectedValue != null)
            {
                MessageBoxResult result = MessageBox.Show("Do you want to delete " + selectedStudentTbName.Text + " ?", "Delete", MessageBoxButton.OKCancel);
                //Viet cau query delete o day neu select Ok
                if (result == MessageBoxResult.OK)
                {
                    for (int i = 0; i < items.Count; i++)
                        if (items.ElementAt(i).idStudent == studentsLv.SelectedValue.ToString())
                        {
                            items.RemoveAt(i);
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
                EditStudentsWindow esw = new EditStudentsWindow();
                int flag = 0;
                //Mo form va dien thong tin
                for (int i = 0; i < items.Count; i++)
                    if (items.ElementAt(i).idStudent == studentsLv.SelectedValue.ToString())
                    {
                        flag = i;
                        esw.FillInfo(items.ElementAt(i).demoStudentName,
                            items.ElementAt(i).demoSex.ToString(),
                            items.ElementAt(i).demoDoB,
                            items.ElementAt(i).demoCountry,
                            items.ElementAt(i).demoParentName,
                            items.ElementAt(i).demoPhoneNb); //currentClass thi phai ket noi dtb class o doan chon lop
                        break;
                    }
                esw.ShowDialog();

                Sex temp = Sex.Male;
                if (esw.sexTb.Text == "Male") temp = Sex.Male;
                if (esw.sexTb.Text == "Female") temp = Sex.Female;

                items.ElementAt(flag).demoStudentName = esw.studentNameTb.Text;
                items.ElementAt(flag).demoSex = temp;
                items.ElementAt(flag).demoDoB = esw.dobTb.Text;
                items.ElementAt(flag).demoCountry = esw.countryTb.Text;
                items.ElementAt(flag).demoParentName = esw.parentNameTb.Text;
                items.ElementAt(flag).demoPhoneNb = Convert.ToInt32(esw.phoneNumberTb.Text);

                CollectionViewSource.GetDefaultView(studentsLv.ItemsSource).Refresh();
            }
        }

        private void panelClassview_Loaded(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < classItems.Count; i++)
            {
                mUC.ClassesViewButton cvBtn = new mUC.ClassesViewButton();
                cvBtn.IdClass = classItems.ElementAt(i).idClass;
                cvBtn.ClassName = classItems.ElementAt(i).demoClassName;
                cvBtn.ClassYear = classItems.ElementAt(i).demoYear.ToString();
                cvBtn.Click += ClassesViewButton_Click;
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
            if (selectedClassName.Tag != null)
            {
                ClassesViewToggleButton.IsChecked = false;
                HidenClassListViewToggleButton.IsChecked = true;
                studentsLvSearchNameTb.Focus();
            }
        }

        private void ClassesViewAddClassButton_Click(object sender, RoutedEventArgs e)
        {
            //Mo window them lop
            AddClassesWindow acw = new AddClassesWindow();
            acw.ShowDialog();

            if (acw.classNameTb.Text != "" &&
                  acw.gradeTb.Text != "" &&
                  acw.teacherNameTb.Text != "" &&
                  acw.countTb.Text != "" &&
                  acw.yearTb.Text != "")
            {
                classItems.Add(new DemoClassInfo()
                {
                    idClass = (Convert.ToInt32(classItems.Last().idClass) + 1).ToString(),  //Brainfuck ((:
                    demoClassName = acw.classNameTb.Text,
                    demoGrade = Convert.ToInt32(acw.gradeTb.Text),
                    demoTeacher = acw.teacherNameTb.Text,
                    demoCount = Convert.ToInt32(acw.countTb.Text),
                    demoYear = Convert.ToInt32(acw.yearTb.Text)
                });

                //classes view button se nhan cac thong tin can thiet
                mUC.ClassesViewButton classesViewButton = new mUC.ClassesViewButton();
                classesViewButton.IdClass = classItems.Last().idClass;
                classesViewButton.ClassName = classItems.Last().demoClassName;
                classesViewButton.ClassYear = classItems.Last().demoYear.ToString();
                classesViewButton.Click += ClassesViewButton_Click;

                panelClassview.Children.Add(classesViewButton);
            }
        }

        private void ClassesViewDeleteClassButton_Click(object sender, RoutedEventArgs e)
        {
            if (selectedClassName.Tag != null)
            {
                MessageBoxResult result = MessageBox.Show("Do you want to delete " + selectedClassName.Text + " ?", "Delete", MessageBoxButton.OKCancel);
                //Viet cau query delete o day neu select Ok
                if (result == MessageBoxResult.OK)
                {
                    for (int i = 0; i < classItems.Count; i++)
                        if (classItems.ElementAt(i).idClass == selectedClassName.Tag.ToString())
                        {
                            //Dont know how the fuck it work :D
                            panelClassview.Children.RemoveAt(i);
                            classItems.RemoveAt(i);
                        }

                    selectedClassName.Tag = null;
                    selectedClassName.Text = "";
                }
            }
        }

        private void ClassesViewEditClassButton_Click(object sender, RoutedEventArgs e)
        {
            if (selectedClassName.Tag != null)
            {
                EditClassesWindow ecw = new EditClassesWindow();
                int flag = 0;
                for (int i = 0; i < classItems.Count; i++)
                    if (classItems.ElementAt(i).idClass == selectedClassName.Tag.ToString())
                    {
                        flag = i;
                        ecw.FillInfo(classItems.ElementAt(i).demoClassName,
                            classItems.ElementAt(i).demoGrade,
                            classItems.ElementAt(i).demoTeacher,
                            classItems.ElementAt(i).demoCount,
                            classItems.ElementAt(i).demoYear);
                        panelClassview.Children.RemoveAt(i);
                        break;
                    }
                ecw.ShowDialog();

                //Thay doi thong tin cua item tai vi tri flag
                classItems.ElementAt(flag).demoClassName = ecw.classNameTb.Text;
                classItems.ElementAt(flag).demoGrade = Convert.ToInt32(ecw.gradeTb.Text);
                classItems.ElementAt(flag).demoTeacher = ecw.teacherNameTb.Text;
                classItems.ElementAt(flag).demoCount = Convert.ToInt32(ecw.countTb.Text);
                classItems.ElementAt(flag).demoYear = Convert.ToInt32(ecw.yearTb.Text);

                //classes view button se nhan cac thong tin can thiet
                mUC.ClassesViewButton classesViewButton = new mUC.ClassesViewButton();
                classesViewButton.IdClass = classItems.ElementAt(flag).idClass;
                classesViewButton.ClassName = classItems.ElementAt(flag).demoClassName;
                classesViewButton.ClassYear = classItems.ElementAt(flag).demoYear.ToString();
                classesViewButton.Click += ClassesViewButton_Click;

                panelClassview.Children.Add(classesViewButton);
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
}
