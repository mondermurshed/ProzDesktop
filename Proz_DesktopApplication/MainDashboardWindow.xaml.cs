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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using MahApps.Metro.Controls;
using Proz_DesktopApplication.ParentUserControls;
using static MaterialDesignThemes.Wpf.Theme;

namespace Proz_DesktopApplication
{
    /// <summary>
    /// Interaction logic for MainDashboardWindow.xaml
    /// </summary>
    public partial class MainDashboardWindow : MetroWindow
    {
        public MainDashboardWindow()
        {
            InitializeComponent();
          
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
           
            this.Opacity = 0.0;
            var fadeIn = new DoubleAnimation(0, 1, TimeSpan.FromMilliseconds(750));
            this.BeginAnimation(Window.OpacityProperty, fadeIn);
            BuildRoleTabs();
            TabController.SelectedIndex = 0;
        }

        private void BuildRoleTabs()
        {
            // Suppose the logged‑in user has both roles:
            AddRoleTab("As User", new Employee_UserControl());
            AddRoleTab("As User", new Employee_UserControl());
            //AddRoleTab("As Admin", new Employee_UserControl());
        }

        private void AddRoleTab(string header, UserControl view)
        {
            var tab = new TabItem
            {
                Header = header,
                Content = view
            };
            TabController.Items.Add(tab);
        }
    }
}
