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
using Microsoft.Extensions.DependencyInjection;
using Proz_DesktopApplication.API;
using Proz_DesktopApplication.ParentUserControls;
using static MaterialDesignThemes.Wpf.Theme;

namespace Proz_DesktopApplication
{
    /// <summary>
    /// Interaction logic for MainDashboardWindow.xaml
    /// </summary>
    public partial class MainDashboardWindow : MetroWindow
    {
        public IServiceProvider Services { get; }
        public  IAuthAPI AuthApi { get; }
        public GeneralAPICalling GeneralAPICalling { get; }
        public AdminAPIEndpointsDefinitions _AdminAPIEndpointsDefinitions { get;}
        public MainDashboardWindow(IServiceProvider services, IAuthAPI authApi, GeneralAPICalling generalAPICalling, AdminAPIEndpointsDefinitions adminAPIEndpointsDefinitions)
        {
            InitializeComponent();
            Services = services;
            AuthApi = authApi;
            GeneralAPICalling = generalAPICalling;
            _AdminAPIEndpointsDefinitions = adminAPIEndpointsDefinitions;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
           
            this.Opacity = 0.0;
            var fadeIn = new DoubleAnimation(0, 1, TimeSpan.FromMilliseconds(750));
            this.BeginAnimation(Window.OpacityProperty, fadeIn);
         
            TabController.SelectedIndex = 0;

        }

  
    }
}
