using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MahApps.Metro.Controls;

using MaterialDesignThemes.Wpf;
using MahApps.Metro.IconPacks;
using System.Windows.Media.Animation;
using ModernMessageBoxLib;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;

using Proz_DesktopApplication.API;
using System.Text.Json;
using System.Drawing;
namespace Proz_DesktopApplication
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class SigninWindow : MetroWindow
    {
        private readonly IServiceProvider _Services;
        private readonly IAuthAPI _authApi;

     

        public SigninWindow(IServiceProvider Services, IAuthAPI authApi) 
        {
            InitializeComponent();

            _Services = Services;
            _authApi = authApi;
        }

        private async void MetroWindow_Loaded(object sender, RoutedEventArgs e)
        {
          
            double screenWidth = SystemParameters.PrimaryScreenWidth;
            double screenHeight = SystemParameters.PrimaryScreenHeight;
            this.Width = screenWidth / 2;
            this.Height = screenHeight / 2;
            this.Left = (screenWidth - this.Width) / 2;
            this.Top = (screenHeight - this.Height) / 2;
            bool SystemStarted = Properties.Settings.Default.SystemStarted;
          

            if (SystemStarted==false)
            {
                loginbutton.Visibility = Visibility.Collapsed; // hide button 1
                registerbutton.Visibility = Visibility.Visible;
                Grid.SetColumn(registerbutton, 0); // start from column 0
                Grid.SetColumnSpan(registerbutton, 2); // span across both columns
                BottomPart.Visibility = Visibility.Hidden;
                ContentOfRegisterButton.Text = "Getting Started";
                ContentOfRegisterButton.FontSize = 13;
            }
            else
            {
                loginbutton.Visibility = Visibility.Visible;
                Grid.SetColumn(registerbutton, 1); // back to column 1
                Grid.SetColumnSpan(registerbutton, 1); // span only 1 column
                BottomPart.Visibility = Visibility.Visible;
                ContentOfRegisterButton.Text = "OR CREATE \n AN ACCOUNT."; //i want to rest this to what it was in xmal 
                ContentOfRegisterButton.Style = (Style)FindResource("MyTextBlockStyle");
            }
    

            this.Opacity = 0.0;
            var fadeIn = new DoubleAnimation(0, 1, TimeSpan.FromMilliseconds(750));
            this.BeginAnimation(Window.OpacityProperty, fadeIn);
            emailTextbox.ContextMenu = null;
            passwordbox.ContextMenu = null;
            QModernMessageBox.MainLang = new QMetroMessageLang()
            {
                Ok = "OK",
                Cancel = "CANCEL",
                Abort = "ABORT",
                Ignore = "IGNORE(I)",
                No = "NO(N)",
                Yes = "YES(Y)",
                Retry = "RETRY(R)"
            };
            QModernMessageBox.GlobalBackground = new SolidColorBrush(Colors.Black) { Opacity = 0.8 };
            QModernMessageBox.GlobalForeground = Brushes.White;


            //string baseTheme = Properties.Settings.Default.UserTheme;        // Light or Dark
            //string color = Properties.Settings.Default.UserThemeColor;       // Blue, Red, Lime, etc.

            //if (!string.IsNullOrWhiteSpace(baseTheme) && !string.IsNullOrWhiteSpace(color))
            //{
            //    string fullTheme = $"{baseTheme}.{color}"; // e.g. Light.Blue or Dark.Red
            //    ControlzEx.Theming.ThemeManager.Current.ChangeTheme(Application.Current, fullTheme);

            //}
            //else
            //{
            //    ControlzEx.Theming.ThemeManager.Current.ChangeTheme(Application.Current, "Dark.Blue");
            //}



        }

        public async Task ShakeControl(UIElement control)
        {
            var transform = new TranslateTransform();
            control.RenderTransform = transform;

            for (int i = 0; i < 5; i++)
            {
                transform.X = 5;
                await Task.Delay(30);
                transform.X = -5;
                await Task.Delay(30);
            }

            transform.X = 0;
        }

        private void EmailTextbox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {









            char inputChar = e.Text[0];
            if (e.Text.Any(char.IsUpper))
            {
                e.Handled = true;
            }


            var textbox = (TextBox)sender;
            int currentLength = textbox.Text.Length;


            if (currentLength == 0 && !char.IsLetter(inputChar))
            {
                e.Handled = true;
                return;
            }

            if (char.IsLetterOrDigit(inputChar) || "@._-+".Contains(inputChar))
                return;

            // Block everything else (including space)
            e.Handled = true;

        }

        private void EmailTextbox_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space)
            {
                e.Handled = true;
                return;
            }


            // Block Ctrl+V and Shift+Insert (Paste shortcuts)
            if ((Keyboard.Modifiers == ModifierKeys.Control && e.Key == Key.V) ||
                (Keyboard.Modifiers == ModifierKeys.Shift && e.Key == Key.Insert))
            {
                e.Handled = true;
                return;
            }
        }

        private void Passwordtextbox_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space)
            {
                e.Handled = true;
                return;
            }

            // Block Ctrl+V and Shift+Insert (Paste shortcuts)
            if ((Keyboard.Modifiers == ModifierKeys.Control && e.Key == Key.V) ||
                (Keyboard.Modifiers == ModifierKeys.Shift && e.Key == Key.Insert))
            {
                e.Handled = true;
                return;
            }
        }

        private void Passwordtextbox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            char inputChar = e.Text[0];
            //if (e.Text.Any(char.IsUpper))
            //{
            //    e.Handled = true;
            //}

            var passwordBox = (PasswordBox)sender;
            int currentLength = passwordBox.Password.Length;


            if (currentLength == 0 && !char.IsLetter(inputChar))
            {
                e.Handled = true;
                return;
            }

            if (!char.IsLetterOrDigit(inputChar) &&
            !char.IsPunctuation(inputChar) &&
            !char.IsSymbol(inputChar))
            // Allows backspace, enter, etc.
            {
                e.Handled = true;
            }
        }
        private void Passwordtextbox2_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            char inputChar = e.Text[0];
            //if (e.Text.Any(char.IsUpper))
            //{
            //    e.Handled = true;
            //}

            var passwordBox = (TextBox)sender;
            int currentLength = passwordBox.Text.Length;


            if (currentLength == 0 && !char.IsLetter(inputChar))
            {
                e.Handled = true;
                return;
            }

            if (!char.IsLetterOrDigit(inputChar) &&
            !char.IsPunctuation(inputChar) &&
            !char.IsSymbol(inputChar))
            // Allows backspace, enter, etc.
            {
                e.Handled = true;
            }
        }
        private async void loginbutton_Click(object sender, RoutedEventArgs e)
        {
            //var MainWindow1 = _Services.GetRequiredService<MainDashboardWindow>();
            //Application.Current.MainWindow = MainWindow1;

            //MainWindow1.Show();
            //this.Close();
            //return;



            //await ShakeControl(loginbutton);

            //this.IsEnabled = false;
            //loginbutton.IsEnabled = false; //if it was wrong then do this 
            //var win = new IndeterminateProgressWindow("Please wait while we are load your data. . .");
            //win.Show();
            //await Task.Delay(500);
            //win.Message = "Done!!!";
            //win.Close();




            //this.Hide();
            //var MainWindowOB = _Services.GetRequiredService<MainDashboardWindow>();
            //MainWindowOB.Show();
            this.IsEnabled = false;
            if (passwordbox.Visibility == Visibility.Collapsed)
            {
                passwordbox.Password = passwordbox2.Text;
                passwordbox.Visibility = Visibility.Visible;
                passwordbox2.Visibility = Visibility.Collapsed;
                ShowPasswordIcon.Kind = PackIconFontAwesomeKind.EyeSlashRegular;

            }
            if (emailTextbox.Text == "" || passwordbox.Password=="")
            {
                var msgBox1 = new ModernMessageBox($"Please fill all your fields to log in!",
                    "Operation Information",
                    ModernMessageboxIcons.Error,
                    "OK");
                msgBox1.ShowDialog();
                await ShakeControl(loginbutton);
                this.IsEnabled = true;
                return;

            }
                try
            {
                string DeviceToken = TokenStorage.GetOrCreateDeviceToken();
                string deviceName = $"{Environment.OSVersion.Platform} - {Environment.MachineName}";
                var request = new LoginRequest { Username = emailTextbox.Text.Trim(), Password=passwordbox.Password,DeviceToken= DeviceToken, DeviceName= deviceName };
                var win = new IndeterminateProgressWindow("Please wait while we are waiting for the server to response.");
                win.Show();
                var response = await _authApi.Login(request);
                win.Message = "Done!!!";
                win.Close();


                if (response.IsSuccessStatusCode && (response.Content?.Token!=null && response.Content?.RefreshToken!=null))
                {
                  
                    if(remembermecheckbox.IsChecked == true)
                    {
                        Properties.Settings.Default.RememberMe = true;
                  
                    }
                    else
                    {
                        Properties.Settings.Default.RememberMe = false;
                     
                    }
                    Properties.Settings.Default.Save();
                  
                    TokenStorage.SaveTokens(response.Content.Token, response.Content.RefreshToken);
                    var MainWindow = _Services.GetRequiredService<MainDashboardWindow>();
                    Application.Current.MainWindow = MainWindow;
                   
                    this.Opacity = 1.0;

                    var fadeOut = new DoubleAnimation(1, 0.2, TimeSpan.FromMilliseconds(250));
                    var tcs = new TaskCompletionSource<bool>();

                    fadeOut.Completed += (s, ev) => tcs.SetResult(true);

                    this.BeginAnimation(Window.OpacityProperty, fadeOut);


                    await tcs.Task;
                    MainWindow.Show();
                    this.Close();
                }
                else
                {
                    // When server returns 400, Refit puts the error JSON as a string here
                    var rawError = response.Error?.Content;
                    LoginResponse errorResponse = null;
                    ValidationErrorResponse errorResponse2 = null;
                    if (!string.IsNullOrWhiteSpace(rawError))
                    {

                        try
                        {
                            errorResponse = JsonSerializer.Deserialize<LoginResponse>(rawError, new JsonSerializerOptions
                            {
                                PropertyNameCaseInsensitive = true
                            });
                            this.IsEnabled = true;
                        }
                        catch
                        {
                            // Fallback to FluentValidation-style error
                            errorResponse2 = JsonSerializer.Deserialize<ValidationErrorResponse>(rawError, new JsonSerializerOptions
                            {
                                PropertyNameCaseInsensitive = true
                            });

                            // Flatten dictionary errors
                            var flatErrors = errorResponse2.Errors
                                .SelectMany(kvp => kvp.Value.Select(msg => $"{kvp.Key}: {msg}"));

                            var msgBox1 = new ModernMessageBox($"{errorResponse2.Message}\n\n{string.Join("\n", flatErrors)}",
                                "Validation Error",
                               ModernMessageboxIcons.Error,
                               "OK");
                            msgBox1.ShowDialog();
                            this.IsEnabled = true;
                            return;
                        }



                        if (errorResponse?.Errors?.Any() == true)
                        {
                            var msgBox1 = new ModernMessageBox($"Error :{string.Join("\n", errorResponse.Errors)}",
                                     "Operation Information",
                                     ModernMessageboxIcons.Error,
                                     "OK");
                            msgBox1.ShowDialog();
                            this.IsEnabled = true;
                        }

                        else
                        {

                            if (errorResponse?.Errors == null)
                            {
                                var msgBox1 = new ModernMessageBox($"Something went wrong!",
                                                      "Operation Information",
                                                      ModernMessageboxIcons.Error,
                                                      "OK");
                                msgBox1.ShowDialog();
                                this.IsEnabled = true;
                            }
                              
                          
                        }
                    
                    }
                    else
                    {

                        var msgBox1 = new ModernMessageBox($"Something went wrong!",
                   "Operation Information",
                    ModernMessageboxIcons.Error,
                    "OK");
                        msgBox1.ShowDialog();
                        this.IsEnabled = true;
                    }
                }
            }
            catch (Exception ex)
            {

                var msgBox1 = new ModernMessageBox($"Network error or app bug: {ex.Message}",
              "Operation Information",
              ModernMessageboxIcons.Error,
              "OK");
                this.IsEnabled = true;

            }
        }

        private async void registerbutton_Click(object sender, RoutedEventArgs e)
        {

            bool SystemStarted = Properties.Settings.Default.SystemStarted;
            if (!SystemStarted)
            {
                registerbutton.IsEnabled = false;
                this.Opacity = 1.0;

                var fadeOut = new DoubleAnimation(1, 0.2, TimeSpan.FromMilliseconds(250));
                var tcs = new TaskCompletionSource<bool>();

                fadeOut.Completed += (s, ev) => tcs.SetResult(true);

                this.BeginAnimation(Window.OpacityProperty, fadeOut);

                // Wait for animation to finish
                await tcs.Task;

                this.Hide();

                var gettingstartedwindow = _Services.GetRequiredService<GettingStartedWindow>();
                Application.Current.MainWindow = gettingstartedwindow;
                gettingstartedwindow.Show();
            }
            else
            {

          
            registerbutton.IsEnabled = false;
            this.Opacity = 1.0;

            var fadeOut = new DoubleAnimation(1, 0.2, TimeSpan.FromMilliseconds(250));
            var tcs = new TaskCompletionSource<bool>();

            fadeOut.Completed += (s, ev) => tcs.SetResult(true);

            this.BeginAnimation(Window.OpacityProperty, fadeOut);

            // Wait for animation to finish
            await tcs.Task;

            this.Hide();

            var forgotWindow = _Services.GetRequiredService<RegisterWindow>();
                Application.Current.MainWindow = forgotWindow;
                forgotWindow.Show();
            }
        }

        private void ShowPassword_Click(object sender, RoutedEventArgs e)
        {
            if (passwordbox.Visibility == Visibility.Visible)
            {
                passwordbox.Visibility = Visibility.Collapsed;
                passwordbox2.Visibility = Visibility.Visible;
                passwordbox2.Text = passwordbox.Password;
                ShowPasswordIcon.Kind = PackIconFontAwesomeKind.EyeRegular;
            }
            else
            {
                passwordbox.Visibility = Visibility.Visible;
                passwordbox2.Visibility = Visibility.Collapsed;
                passwordbox.Password = passwordbox2.Text;

                ShowPasswordIcon.Kind = PackIconFontAwesomeKind.EyeSlashRegular;
            }
        }

        private async void Hyperlink_Click(object sender, RoutedEventArgs e)
        {
            hyperlinkforgotpassword.IsEnabled = false;
            this.Opacity = 1.0;

            var fadeOut = new DoubleAnimation(1, 0.2, TimeSpan.FromMilliseconds(250));
            var tcs = new TaskCompletionSource<bool>();

            fadeOut.Completed += (s, ev) => tcs.SetResult(true);

            this.BeginAnimation(Window.OpacityProperty, fadeOut);

            // Wait for animation to finish
            await tcs.Task;

            this.Hide();

            var forgotWindow = _Services.GetRequiredService<ForgotPasswordWindow>();
            Application.Current.MainWindow = forgotWindow;
            forgotWindow.Show();
        }
    }
}