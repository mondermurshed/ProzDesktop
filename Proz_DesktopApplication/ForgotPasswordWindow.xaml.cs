
using System.Drawing;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Windows;
using System.Windows.Controls;

using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;


using MahApps.Metro.Controls;
using Microsoft.Extensions.DependencyInjection;
using ModernMessageBoxLib;
using Proz_DesktopApplication.API;
using Refit;

namespace Proz_DesktopApplication
{
    /// <summary>
    /// Interaction logic for ForgotPasswordWindow.xaml
    /// </summary>
    public partial class ForgotPasswordWindow : MetroWindow
    {
        private readonly IAuthAPI _authApi;
        private readonly IServiceProvider _Services;
        public ForgotPasswordWindow(IAuthAPI authApi, IServiceProvider services)
        {
            InitializeComponent();
            _authApi = authApi;
            _Services = services;
        }

        private void MetroWindow_Loaded(object sender, RoutedEventArgs e)
        {
            double screenWidth = SystemParameters.PrimaryScreenWidth;
            double screenHeight = SystemParameters.PrimaryScreenHeight;
            this.Width = screenWidth / 2;
            this.Height = screenHeight / 2;
            this.Left = (screenWidth - this.Width) / 2;
            this.Top = (screenHeight - this.Height) / 2;
            this.Opacity = 0.0;
            var fadeIn = new DoubleAnimation(0, 1, TimeSpan.FromMilliseconds(750));
            this.BeginAnimation(Window.OpacityProperty, fadeIn);
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

        bool IsValidEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email)) return false;

            int atIndex = email.IndexOf('@');
            if (atIndex < 1 || atIndex == email.Length - 1)
                return false;

            string domainPart = email.Substring(atIndex + 1);
            return domainPart.Contains('.');
        }
        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            errortextblock.Text = "";
            errortextblock.Foreground = Brushes.IndianRed;
            if(emailTextbox.Text=="")
            {
                errortextblock.Text = "Please enter your email address";
                await ShakeControl(ForgotMyPasswordButton);
                return;
            }


            bool checker = IsValidEmail(emailTextbox.Text);
           if(checker==false)
             {
                 errortextblock.Text = "Email is not valid! make sure you enter your real email address.";
                await ShakeControl(ForgotMyPasswordButton);
                return;
            }

           

            try
            {
                var request = new ForgotPasswordRequest { Email = emailTextbox.Text.Trim() };
                var win = new IndeterminateProgressWindow("Please wait while we are waiting for the server to response.");
                win.Show();
                var response = await _authApi.ForgotPassword(request);
                win.Message = "Done!!!";
                win.Close();


                if (response.IsSuccessStatusCode && response.Content?.Message?.Any() == true)
                {
                    errortextblock.Foreground =Brushes.ForestGreen;
                    errortextblock.Text = "Message:\n" + string.Join("\n", response.Content.Message);
                   
                }
                else
                {
                    // When server returns 400, Refit puts the error JSON as a string here
                    var rawError = response.Error?.Content;
                 
                    if (!string.IsNullOrWhiteSpace(rawError))
                    {
                       
                        var errorResponse = JsonSerializer.Deserialize<ForgotPasswordResponse>(rawError, new JsonSerializerOptions
                        {
                            PropertyNameCaseInsensitive = true
                        });
                      
                        errortextblock.Text = "";
                       
                        if (errorResponse?.Message?.Any() == true)
                        {
                            errortextblock.Text += "Message:\n" + string.Join("\n", errorResponse.Message);
                            errortextblock.Text += "\nError:\n" + string.Join("\n", errorResponse.Error);
                        }

                        if (errorResponse?.Error?.Any() == true)
                        {
                            errortextblock.Text += "Error:\n" + string.Join("\n", errorResponse.Error);
                        }
                    }
                    else
                    {
                        errortextblock.Text = "Unknown error occurred.";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Network error or app bug: " + ex.Message);
            }



        }

        private async void GoBackToSignInWindowButton_Click(object sender, RoutedEventArgs e)
        {

            this.Opacity = 1.0;

            var fadeOut = new DoubleAnimation(1, 0.2, TimeSpan.FromMilliseconds(250));
            var tcs = new TaskCompletionSource<bool>();

            fadeOut.Completed += (s, ev) => tcs.SetResult(true);

            this.BeginAnimation(Window.OpacityProperty, fadeOut);


            await tcs.Task;

            this.Hide();
            var SigninWindowOB = _Services.GetRequiredService<SigninWindow>();
            SigninWindowOB.Show();
        }
    }
  

}
