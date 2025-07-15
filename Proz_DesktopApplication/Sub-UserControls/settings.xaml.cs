using System;
using System.Windows;
using System.Windows.Controls;
using Microsoft.Extensions.DependencyInjection;
using Proz_DesktopApplication.API;

namespace Proz_DesktopApplication.Sub_UserControls
{
    public partial class settings : BaseUserControlMain
    {
        public  IServiceProvider _services;
        public  IAuthAPI _authApi;

        public settings()
        {
            InitializeComponent();

            _services = Services1;
            _authApi = AuthApi1;

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
