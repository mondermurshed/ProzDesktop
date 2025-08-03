using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
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
using ModernMessageBoxLib;
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
        private async void LogOutButton_Click(object sender, RoutedEventArgs e)
        {

            var signInWindow = _services.GetRequiredService<SigninWindow>();
            string DeviceToken = TokenStorage.GetOrCreateDeviceToken();
            var tokens = TokenStorage.LoadTokens();
            try
            {
                var request = new LogoutRequest { DeviceToken = DeviceToken, RefreshToken=tokens.Value.refreshToken };
                var win = new IndeterminateProgressWindow("Logging out, please wait...");
                win.Show();
                var response = await _authApi.Logout(request);
                win.Close();


                if (response.IsSuccessStatusCode)
                {
                    TokenStorage.DeleteTokens();
                    Application.Current.MainWindow = signInWindow;
                    signInWindow.Show();
                    var mainWindow = Window.GetWindow(this) as MainDashboardWindow;

                    mainWindow?.Close();

                }
                else
                {
                    var msg = new ModernMessageBox($"Couldn't log out, make sure the server is on.", "Something went wrong!", ModernMessageboxIcons.Error, "OK");
                    msg.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                var msg = new ModernMessageBox($"Couldn't reach the server.", "Something went wrong!", ModernMessageboxIcons.Error, "OK");
                msg.ShowDialog();

            }




      



        }
    }
}
