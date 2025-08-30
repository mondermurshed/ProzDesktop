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
using Microsoft.AspNetCore.SignalR.Client;
using Microsoft.Extensions.DependencyInjection;
using ModernMessageBoxLib;
using Polly.Retry;
using Proz_DesktopApplication.API;
using Proz_DesktopApplication.HelperServices;
using Proz_DesktopApplication.ParentUserControls;
using ToastNotifications;
using ToastNotifications.Lifetime;
using ToastNotifications.Messages;
using ToastNotifications.Position;
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

        public HRMAPIEndpointsDefinitions _HRAPIEndpointsDefinitions { get; }

        public DMAPIEndpointsDefinitions _DMAPIEndpointsDefinitions { get; }

        public readonly MainHubService _hubConnection;
        private readonly AsyncRetryPolicy _retryPolicy;
        public MainDashboardWindow(IServiceProvider services, IAuthAPI authApi, GeneralAPICalling generalAPICalling, AdminAPIEndpointsDefinitions adminAPIEndpointsDefinitions
            , EmployeeAPIEndpointsDefinitions employeeAPIEndpointsDefinitions, DMAPIEndpointsDefinitions DMAPIEndpointsDefinitions
            , HRMAPIEndpointsDefinitions hRAPIEndpointsDefinitions
            , MainHubService hubConnection, AsyncRetryPolicy retryPolicy)
        {
            InitializeComponent();
            Services = services;
            AuthApi = authApi;
            GeneralAPICalling = generalAPICalling;
            _AdminAPIEndpointsDefinitions = adminAPIEndpointsDefinitions;
            Loaded += Window_Loaded;
            _EmployeeAPIEndpointsDefinitions = employeeAPIEndpointsDefinitions;
            _DMAPIEndpointsDefinitions = DMAPIEndpointsDefinitions;
            _HRAPIEndpointsDefinitions = hRAPIEndpointsDefinitions;
            _hubConnection = hubConnection;
            _retryPolicy = retryPolicy;
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
                //_hubConnection.Reconnecting += async ex =>
                //{
                //    var win = new IndeterminateProgressWindow("Trying To Connect To The Server...");
                //    win.Show();
                //    win.Close();
                //};
                //_hubConnection.Reconnected += async ex =>
                //{
                //    var win = new IndeterminateProgressWindow("Connected to the server!");
                //    win.Show();
                //    win.Close();
                //};


                _hubConnection.Connection.On<RoleChangedEvent>("RoleChanged", async payload =>
                {
                   await Dispatcher.Invoke(async () =>
                    {
                        try
                        {
                            var tokens = TokenStorage.LoadTokens();
                            string DeviceToken = TokenStorage.GetOrCreateDeviceToken();
                            var request = new RefreshRequest
                            {
                                DeviceToken = DeviceToken,
                                RefreshToken = tokens.Value.refreshToken
                            };

                            var response = await AuthApi.RefreshMyAccessToken(request);

                            if (response.IsSuccessStatusCode &&
                                !string.IsNullOrWhiteSpace(response.Content?.Token) &&
                                !string.IsNullOrWhiteSpace(response.Content?.RefreshToken))
                            {
                                // Save new tokens
                                TokenStorage.DeleteTokens();
                                TokenStorage.SaveTokens(response.Content.Token, response.Content.RefreshToken);




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
                        catch
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



                        UserControl controlToLoad = null;

                        if (payload.RoleName == AppRoles_Desktop.User)
                            controlToLoad = new User_UserControl();
                        else if (payload.RoleName == AppRoles_Desktop.Employee)
                            controlToLoad = new Employee_UserControl();
                        else if (payload.RoleName == AppRoles_Desktop.DepartmentManager)
                            controlToLoad = new DepartmentManager_UserControl();
                        else if (payload.RoleName == AppRoles_Desktop.HRManager)
                            controlToLoad = new HRManager_UserControl();
                        else if (payload.RoleName == AppRoles_Desktop.Admin)
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
                        return;

                    });
                });

                Notifier reconnectingnotifier = new Notifier(cfg =>
                {
                    cfg.PositionProvider = new WindowPositionProvider(
                        parentWindow: Application.Current.MainWindow,
                        corner: Corner.TopRight,
                        offsetX: 10,
                        offsetY: 10);


                    cfg.LifetimeSupervisor = new TimeAndCountBasedLifetimeSupervisor(
                        notificationLifetime: TimeSpan.FromDays(1),
                        maximumNotificationCount: MaximumNotificationCount.FromCount(1));

                    cfg.Dispatcher = Application.Current.Dispatcher;
                    cfg.DisplayOptions.Width = 300;
                    cfg.DisplayOptions.TopMost = true;


                });

                Notifier connectednotifier = new Notifier(cfg =>
                {
                    cfg.PositionProvider = new WindowPositionProvider(
                        parentWindow: Application.Current.MainWindow,
                        corner: Corner.TopRight,
                        offsetX: 10,
                        offsetY: 10);


                    cfg.LifetimeSupervisor = new TimeAndCountBasedLifetimeSupervisor(
                        notificationLifetime: TimeSpan.FromSeconds(7),
                        maximumNotificationCount: MaximumNotificationCount.FromCount(1));

                    cfg.Dispatcher = Application.Current.Dispatcher;
                    cfg.DisplayOptions.Width = 300;
                    cfg.DisplayOptions.TopMost = true;


                });

                _hubConnection.Connection.Closed += async (error) =>
                 {
                     //await _retryPolicy.ExecuteAsync(async () =>
                     //{
                     //    await _hubConnection.Connection.StartAsync();
                     //});
                 };

                _hubConnection.Connection.Reconnecting += async (error) =>
                {
                    reconnectingnotifier.ShowWarning("Attempting to reconnect to the server...");
                    await _retryPolicy.ExecuteAsync(async () =>
                    {
                        await _hubConnection.Connection.StartAsync();
                    });
                };
                
                _hubConnection.Connection.Reconnected += (connectionId) =>
                {
                    reconnectingnotifier.Dispose();
                    connectednotifier.ShowSuccess("Reconnected to the server!");

                    return Task.CompletedTask;
                };



                if (_hubConnection.Connection.State == HubConnectionState.Disconnected)
                {
                    try
                    {
                        await _retryPolicy.ExecuteAsync(async () =>
                        {
                            await _hubConnection.Connection.StartAsync();
                        });
                    }
                    catch (Exception ex)
                    {
                        //MessageBox.Show($"SignalR connect failed: {ex.Message}");
                    }
                }
                //else if (_hubConnection.Connection.State == HubConnectionState.Connected)
                //{
                //    await _hubConnection.Connection.StopAsync();
                //    try
                //    {
                //        await _hubConnection.Connection.StartAsync();
                //    }
                //    catch (Exception ex)
                //    {
                //        MessageBox.Show($"SignalR connect failed: {ex.Message}");
                //    }
                //}



                //var win = new IndeterminateProgressWindow("Loggin Into Your Account...");
                //win.Show();
                var response = await _AdminAPIEndpointsDefinitions.GetRoleName();

             
              
            
                //win.Close();


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
