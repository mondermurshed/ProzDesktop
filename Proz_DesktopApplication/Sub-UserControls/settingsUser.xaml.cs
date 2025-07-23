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
using Microsoft.Extensions.DependencyInjection;
using Proz_DesktopApplication.API;

namespace Proz_DesktopApplication.Sub_UserControls
{
    /// <summary>
    /// Interaction logic for settingsUser.xaml
    /// </summary>
    ///  public  IServiceProvider _services;

    public partial class settingsUser : BaseUserControlMain
    {
        public IServiceProvider _services;
        public IAuthAPI _authApi;
        public settingsUser()
        {
            InitializeComponent();
            this.Loaded += settings_Loaded;
        }
        private void settings_Loaded(object sender, RoutedEventArgs e)
        {
            _services = Services1 ?? throw new InvalidOperationException("Services1 is null");
            _authApi = AuthApi1 ?? throw new InvalidOperationException("AuthApi1 is null");
        }
        private void LogOutButton_Click(object sender, RoutedEventArgs e)
        {

            var signInWindow = _services.GetRequiredService<SigninWindow>();

            TokenStorage.DeleteTokens();
            Application.Current.MainWindow = signInWindow;
            signInWindow.Show();
            var mainWindow = Window.GetWindow(this) as MainDashboardWindow;

            mainWindow?.Close();



        }
    }
}
