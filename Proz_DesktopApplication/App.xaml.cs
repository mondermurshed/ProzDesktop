using System.Configuration;
using System.Data;
using System.Windows;
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


                    services.AddTransient<SigninWindow>();
                    services.AddTransient<ForgotPasswordWindow>();
                    services.AddTransient<RegisterWindow>();
                    services.AddTransient<MainDashboardWindow>();
                })
                .Build();

            Application.Current.ShutdownMode = ShutdownMode.OnMainWindowClose;


            var authApi = AppHost.Services.GetRequiredService<IAuthAPI>();

            // 1. Check RememberMe
            if (Proz_DesktopApplication.Properties.Settings.Default.RememberMe)
            {
                var tokens = TokenStorage.LoadTokens();

                if (tokens is not null && !string.IsNullOrWhiteSpace(tokens.Value.refreshToken))
                {
                    try
                    {
                        var request = new RefreshRequest
                        {
                            AccessToken = tokens.Value.accessToken,
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
                        var signin1 = AppHost.Services.GetRequiredService<SigninWindow>();
                        Application.Current.MainWindow = signin1;
                        signin1.Show();
                    }
                }
            }

            // If auto-login failed or not enabled, show login
            var signin = AppHost.Services.GetRequiredService<SigninWindow>();
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
