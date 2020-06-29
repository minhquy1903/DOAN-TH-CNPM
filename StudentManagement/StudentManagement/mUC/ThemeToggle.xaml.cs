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
using MaterialDesignThemes.Wpf;

namespace StudentManagement.mUC
{
    /// <summary>
    /// Interaction logic for ThemeToggle.xaml
    /// </summary>
    public partial class ThemeToggle : UserControl
    {
        public ThemeToggle()
        {
            InitializeComponent();
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
    }
}
