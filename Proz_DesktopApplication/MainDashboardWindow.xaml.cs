using System;
using System.Collections.Generic;
using System.Data;
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
using ModernMessageBoxLib;
using Proz_DesktopApplication.API;
using Proz_DesktopApplication.HelperServices;
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

        public EmployeeAPIEndpointsDefinitions _EmployeeAPIEndpointsDefinitions { get; }

        public DMAPIEndpointsDefinitions _DMAPIEndpointsDefinitions { get; }
        public MainDashboardWindow(IServiceProvider services, IAuthAPI authApi, GeneralAPICalling generalAPICalling, AdminAPIEndpointsDefinitions adminAPIEndpointsDefinitions
            , EmployeeAPIEndpointsDefinitions employeeAPIEndpointsDefinitions, DMAPIEndpointsDefinitions DMAPIEndpointsDefinitions)
        {
            InitializeComponent();
            Services = services;
            AuthApi = authApi;
            GeneralAPICalling = generalAPICalling;
            _AdminAPIEndpointsDefinitions = adminAPIEndpointsDefinitions;
            Loaded += Window_Loaded;
            _EmployeeAPIEndpointsDefinitions = employeeAPIEndpointsDefinitions;
            _DMAPIEndpointsDefinitions = DMAPIEndpointsDefinitions;
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
           
            this.Opacity = 0.0;
            var fadeIn = new DoubleAnimation(0, 1, TimeSpan.FromMilliseconds(750));
            this.BeginAnimation(Window.OpacityProperty, fadeIn);
            //TabController.SelectedIndex = 0;


            this.IsEnabled = false;
            try
            {



                var win = new IndeterminateProgressWindow("Loggin Into Your Account...");
                win.Show();
                var response = await _AdminAPIEndpointsDefinitions.GetRoleName();
                win.Close();


                if (response.IsSuccessStatusCode)
                {

                    UserControl controlToLoad = null;
                    if (response.Content.RoleName == AppRoles_Desktop.User)
                        controlToLoad = new User_UserControl();
                    else if (response.Content.RoleName == AppRoles_Desktop.Employee)
                        controlToLoad = new Employee_UserControl();
                    else if (response.Content.RoleName == AppRoles_Desktop.DepartmentManager)
                        controlToLoad = new DepartmentManager_UserControl();
                    else if (response.Content.RoleName == AppRoles_Desktop.HRManager)
                        controlToLoad = new HRManager_UserControl();
                    else if (response.Content.RoleName == AppRoles_Desktop.Admin)
                        controlToLoad = new Admin_UserControl();
                    else
                    {
                        this.Opacity = 1.0;

                        var fadeOut = new DoubleAnimation(1, 0.2, TimeSpan.FromMilliseconds(250));
                        var tcs = new TaskCompletionSource<bool>();

                        fadeOut.Completed += (s, ev) => tcs.SetResult(true);

                        this.BeginAnimation(Window.OpacityProperty, fadeOut);


                        await tcs.Task;

                        this.Hide();
                        var SigninWindowOB = Services.GetRequiredService<SigninWindow>();
                        Application.Current.MainWindow = SigninWindowOB;
                        SigninWindowOB.Show();
                    }
                    MainContentArea.Children.Clear();
                    MainContentArea.Children.Add(controlToLoad);
                    this.IsEnabled = true;

                }
                else
                {
                    this.Opacity = 1.0;

                    var fadeOut = new DoubleAnimation(1, 0.2, TimeSpan.FromMilliseconds(250));
                    var tcs = new TaskCompletionSource<bool>();

                    fadeOut.Completed += (s, ev) => tcs.SetResult(true);

                    this.BeginAnimation(Window.OpacityProperty, fadeOut);


                    await tcs.Task;

                    this.Hide();
                    var SigninWindowOB = Services.GetRequiredService<SigninWindow>();
                    Application.Current.MainWindow = SigninWindowOB;
                    SigninWindowOB.Show();
                }

            }
            catch (Exception ex)
            {
                this.Opacity = 1.0;

                var fadeOut = new DoubleAnimation(1, 0.2, TimeSpan.FromMilliseconds(250));
                var tcs = new TaskCompletionSource<bool>();

                fadeOut.Completed += (s, ev) => tcs.SetResult(true);

                this.BeginAnimation(Window.OpacityProperty, fadeOut);


                await tcs.Task;

                this.Hide();
                var SigninWindowOB = Services.GetRequiredService<SigninWindow>();
                Application.Current.MainWindow = SigninWindowOB;
                SigninWindowOB.Show();
            }

        }

  
    }
}
