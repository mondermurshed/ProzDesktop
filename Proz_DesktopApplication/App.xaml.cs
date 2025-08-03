using System.Configuration;
using System.Data;
using System.Linq;
using System.Text.Json;
using System.Windows;
using System.Windows.Media;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ModernMessageBoxLib;
using Proz_DesktopApplication.API;
using Proz_DesktopApplication.Properties;
using Refit;


namespace Proz_DesktopApplication
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static IHost AppHost { get; private set; }
        public static IServiceProvider Services => AppHost.Services;

        protected async override void OnStartup(StartupEventArgs e)
        {
            AppHost = Host.CreateDefaultBuilder()
                .ConfigureServices((context, services) =>
                {

                    services.AddRefitClient<IAuthAPI>()
                    .ConfigureHttpClient(c =>
                    {
                        c.BaseAddress = new Uri("https://api.prozsupport.xyz");

                    });

                    services.AddRefitClient<GeneralAPICalling>()
                   .ConfigureHttpClient(c =>
                    {
                        c.BaseAddress = new Uri("https://api.prozsupport.xyz");

                    }).AddHttpMessageHandler<TokenAuthHandler>().AddHttpMessageHandler<RefreshTokenHandler>(); //everytthing works as pipstream like first when sending a request the process will go from RefreshTokenHandler to TokenAuthHandler and then to the internet, and when receiving a response it will go from the internet to TokenAuthHandler and finally to RefreshTokenHandler and after that your app will receive it.

                   services.AddRefitClient<AdminAPIEndpointsDefinitions>()
                  .ConfigureHttpClient(c =>
                  {
                      c.BaseAddress = new Uri("https://api.prozsupport.xyz");
              
                  }).AddHttpMessageHandler<TokenAuthHandler>().AddHttpMessageHandler<RefreshTokenHandler>(); //everytthing works as pipstream like first when sending a request the process will go from RefreshTokenHandler to TokenAuthHandler and then to the internet, and when receiving a response it will go from the internet to TokenAuthHandler and finally to RefreshTokenHandler and after that your app will receive it.

                    services.AddTransient<SigninWindow>();
                    services.AddTransient<ForgotPasswordWindow>();
                    services.AddTransient<RegisterWindow>();
                    services.AddTransient<GettingStartedWindow>();
                    services.AddTransient<MainDashboardWindow>();
                    services.AddTransient<TokenAuthHandler>();
                    services.AddTransient<RefreshTokenHandler>();

                }).Build();



            Application.Current.ShutdownMode = ShutdownMode.OnMainWindowClose;


            var authApi = AppHost.Services.GetRequiredService<IAuthAPI>();

            // 1. Check RememberMe
            if (Proz_DesktopApplication.Properties.Settings.Default.RememberMe)
            {
                var tokens = TokenStorage.LoadTokens();
                string DeviceToken= TokenStorage.GetOrCreateDeviceToken(); 
                if (tokens is not null && !string.IsNullOrWhiteSpace(tokens.Value.refreshToken))
                {
                    try
                    {
                        var request = new RefreshRequest
                        {
                            DeviceToken = DeviceToken,
                            RefreshToken = tokens.Value.refreshToken

                        };

                        var response = await authApi.RefreshMyAccessToken(request);

                        if (response.IsSuccessStatusCode &&
                            !string.IsNullOrWhiteSpace(response.Content?.Token) &&
                            !string.IsNullOrWhiteSpace(response.Content?.RefreshToken))
                        {
                            // Save new tokens
                            TokenStorage.DeleteTokens();
                            TokenStorage.SaveTokens(response.Content.Token, response.Content.RefreshToken);

                            // Launch dashboard directly
                            var dashboard = AppHost.Services.GetRequiredService<MainDashboardWindow>();
                            Application.Current.MainWindow = dashboard;
                            string baseTheme = Proz_DesktopApplication.Properties.Settings.Default.UserTheme;        // Light or Dark
                            string color = Proz_DesktopApplication.Properties.Settings.Default.UserThemeColor;       // Blue, Red, Lime, etc.

                            if (!string.IsNullOrWhiteSpace(baseTheme) && !string.IsNullOrWhiteSpace(color))
                            {
                                string fullTheme = $"{baseTheme}.{color}"; // e.g. Light.Blue or Dark.Red
                                ControlzEx.Theming.ThemeManager.Current.ChangeTheme(Application.Current, fullTheme);

                            }
                            else
                            {
                                ControlzEx.Theming.ThemeManager.Current.ChangeTheme(Application.Current, "Dark.Blue");
                            }
                            dashboard.Show(); // Now display it
                            return; // important to stop OnStartup here!
                        }

                    }
                    catch
                    {

                    }
                }
            }

            bool SystemStarted = Proz_DesktopApplication.Properties.Settings.Default.SystemStarted;


                try
                {

                    //var win = new IndeterminateProgressWindow("Please wait while we are waiting for the server to response.");
                    //win.Show();
                    var response = await authApi.CheckSystemGettingStartedStatus();
                    //win.Message = "Done!!!";
                    //win.Close();


                    if (response.IsSuccessStatusCode)
                    {
                    MessageBox.Show("ok");
                        Proz_DesktopApplication.Properties.Settings.Default.SystemStarted = true;
                        Proz_DesktopApplication.Properties.Settings.Default.Save();

                    }
                    else if (response.StatusCode==System.Net.HttpStatusCode.BadRequest)
                    {
                    MessageBox.Show("Not ok");
                        Proz_DesktopApplication.Properties.Settings.Default.SystemStarted = false;
                        Proz_DesktopApplication.Properties.Settings.Default.Save();
                    }
             //if status code was 530 then it's means that cloudflare wasn't able to reach the server that has the endpoint.
                }
                catch (Exception ex)
                {
                    //MessageBox.Show("Network error or app bug: " + ex.Message);
                }
            

            // If auto-login failed or not enabled, show login
            var signin = App.Services.GetRequiredService<SigninWindow>();
            Application.Current.MainWindow = signin;

            string baseThemesignin = Proz_DesktopApplication.Properties.Settings.Default.UserTheme;        // Light or Dark
            string colorsignin = Proz_DesktopApplication.Properties.Settings.Default.UserThemeColor;       // Blue, Red, Lime, etc.
          
            if (!string.IsNullOrWhiteSpace(baseThemesignin) && !string.IsNullOrWhiteSpace(colorsignin))
            {
                string fullTheme = $"{baseThemesignin}.{colorsignin}"; // e.g. Light.Blue or Dark.Red
                ControlzEx.Theming.ThemeManager.Current.ChangeTheme(Application.Current, fullTheme);

            }
            else
            {
                ControlzEx.Theming.ThemeManager.Current.ChangeTheme(Application.Current, "Dark.Blue");
            }

            signin.Show();
        }
    }

}
