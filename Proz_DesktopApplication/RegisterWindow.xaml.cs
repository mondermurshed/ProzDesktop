using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;
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
using ControlzEx.Theming;
using MahApps.Metro.Controls;
using MahApps.Metro.IconPacks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Primitives;
using ModernMessageBoxLib;
using Proz_DesktopApplication.API;

namespace Proz_DesktopApplication
{

    public partial class RegisterWindow : MetroWindow
    {
        private readonly IAuthAPI _authApi;
        private readonly IServiceProvider _Services;
        public RegisterWindow(IAuthAPI authApi,IServiceProvider services)
        {
            InitializeComponent();
            _authApi = authApi;
            _Services = services;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            double screenWidth = SystemParameters.PrimaryScreenWidth+100;
            double screenHeight = SystemParameters.PrimaryScreenHeight+100;
            this.Width = screenWidth / 2;
            this.Height = screenHeight / 2;
            this.Left = (screenWidth - this.Width) / 2;
            this.Top = (screenHeight - this.Height) / 2;
            this.Opacity = 0.0;
            var fadeIn = new DoubleAnimation(0, 1, TimeSpan.FromMilliseconds(750));
            this.BeginAnimation(Window.OpacityProperty, fadeIn);
            ConfirmPasswordTextbox.ContextMenu = null;
            Passwordtextbox.ContextMenu = null;
            Usernametextbox.ContextMenu = null;
            EmailTextbox.ContextMenu = null;
   

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

        private void HelperButton_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button clickedButton)
            {
                TextBlock targetTextBlock = null;
                string helpMessage = "";

                if (clickedButton == Usernamebutton)
                {
                    targetTextBlock = UsernameTextBlock;
                    helpMessage = "Rather then inserting your whole email address, you can just put your username beside your password.";
                }
                else if (clickedButton == Emailbutton)
                {
                    targetTextBlock = EmailTextBlock;
                    helpMessage = "Make sure your email address is valid and can receive emails.";
                }
                else if (clickedButton == PasswordButton)
                {
                    targetTextBlock = PasswordTextBlock;
                    helpMessage = "It must contain at least an uppercase letter, a symbol and a bunch of letters and digits.";
                }
                else if (clickedButton == ConfirmPasswordButton)
                {
                    targetTextBlock = ConfirmPasswordTextblock;
                    helpMessage = "Enter your password manaully again here.";
                }

                if (targetTextBlock.Text == helpMessage)
                {
                    targetTextBlock.Text = "";
                }
                else
                {
                    targetTextBlock.Text = helpMessage;
                    targetTextBlock.Foreground = Brushes.SteelBlue;
                }
                //if (targetTextBlock == null)
                //    return;

                //// Store original error only once
                //if (targetTextBlock.Tag == null)
                //    targetTextBlock.Tag = targetTextBlock.Text;

                //string originalError = targetTextBlock.Tag.ToString();

                //if (targetTextBlock.Text == originalError)
                //{
                //    targetTextBlock.Text = helpMessage;
                //    targetTextBlock.Foreground = Brushes.SteelBlue;
                //}
                //else
                //{
                //    targetTextBlock.Text = originalError;
                //    targetTextBlock.Foreground = Brushes.Red;
                //}
            
            
        }
        }

        private void Usernametextbox_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            // Allow arrow keys for navigation


            // Block Backspace and Delete (optional — only if you want)
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

        private void ConfirmPasswordTextbox_PreviewKeyDown(object sender, KeyEventArgs e)
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

        private void Usernametextbox_PreviewTextInput(object sender, TextCompositionEventArgs e)
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

            // Allow letters, digits, and underscore
            if (char.IsLetterOrDigit(inputChar) || inputChar == '_')
                return;

            // Block everything else
            e.Handled = true;
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

        private void ConfirmPasswordTextbox_PreviewTextInput(object sender, TextCompositionEventArgs e)
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

        private async void GoToSigninWindowButton_Click(object sender, RoutedEventArgs e)
        {
            GoToSigninWindowButton.IsEnabled = false;
            this.Opacity = 1.0;

            var fadeOut = new DoubleAnimation(1, 0.2, TimeSpan.FromMilliseconds(250));
            var tcs = new TaskCompletionSource<bool>();

            fadeOut.Completed += (s, ev) => tcs.SetResult(true);

            this.BeginAnimation(Window.OpacityProperty, fadeOut);

            // Wait for animation to finish
            await tcs.Task;

            this.Hide();

            var SignInWindowOB = _Services.GetRequiredService<SigninWindow>();
            Application.Current.MainWindow = SignInWindowOB;
            SignInWindowOB.Show();
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
        private async void RegisterButton_Click(object sender, RoutedEventArgs e)
        {



            bool pass = true;
            RegisterErrorTextBlock.Inlines.Clear(); // Clear previous messages
            if(Passwordtextbox.Visibility==Visibility.Collapsed)
            {
                Passwordtextbox.Password = Passwordtextbox2.Text;
                Passwordtextbox2.Visibility = Visibility.Collapsed;
                Passwordtextbox.Visibility = Visibility.Visible;
                ShowPasswordIcon.Kind = PackIconFontAwesomeKind.EyeSlashRegular;
                
            }
             if (ConfirmPasswordTextbox.Visibility==Visibility.Collapsed)
            {
              
                ConfirmPasswordTextbox.Password = ConfirmPasswordTextbox2.Text;
                ConfirmPasswordTextbox2.Visibility = Visibility.Collapsed;
                ConfirmPasswordTextbox.Visibility = Visibility.Visible;
                ShowConfirmPasswordIcon.Kind = PackIconFontAwesomeKind.EyeSlashRegular;
            }
          
            if (string.IsNullOrEmpty(Usernametextbox.Text) || string.IsNullOrEmpty(EmailTextbox.Text)
                || string.IsNullOrEmpty(Passwordtextbox.Password) || string.IsNullOrEmpty(ConfirmPasswordTextbox.Password) || string.IsNullOrEmpty(FullNameTextbox.Text))
            {
                pass = false;
                RegisterErrorTextBlock.Inlines.Add(new Run("-Please fill all your fields.\n")
                {
                    Foreground = Brushes.IndianRed
                });
                return;
            }
            bool hasUpperCase = Regex.IsMatch(Passwordtextbox.Password, "[A-Z]");

            // Check if password has at least one symbol
            bool hasSymbol = Regex.IsMatch(ConfirmPasswordTextbox.Password, "[^a-zA-Z0-9]");
            if(!hasUpperCase)
            {
                pass = false;
                RegisterErrorTextBlock.Inlines.Add(new Run("-Your Password should atleast contain one uppercase letter.\n")
                {
                    Foreground = Brushes.IndianRed
                });
            }
            if (!hasSymbol)
            {
                pass = false;
                RegisterErrorTextBlock.Inlines.Add(new Run("-Your Password should atleast contain one symbol in it.\n")
                {
                    Foreground = Brushes.IndianRed
                });
            }
            if (!string.IsNullOrEmpty(EmailTextbox.Text))
            {
            bool simpleEmailChecker = IsValidEmail(EmailTextbox.Text);
                if (simpleEmailChecker==false)
                {
                    pass = false;
                    RegisterErrorTextBlock.Inlines.Add(new Run("-Make sure you inserted a proper email format.\n")
                    {
                        Foreground = Brushes.IndianRed
                    });
                }
                
            }
          
            if (Passwordtextbox.Password!=ConfirmPasswordTextbox.Password)
            {
                pass=false;
                RegisterErrorTextBlock.Inlines.Add(new Run("-Your password field does NOT match your Confirm password field.\n")
                {
                    Foreground = Brushes.IndianRed
                });
            }
            if (!string.IsNullOrEmpty(Passwordtextbox.Password))
            {
                string password = Passwordtextbox.Password;
                string email = EmailTextbox.Text;
                string username = Usernametextbox.Text;

                var result = await Task.Run(() =>
                    PasswordChecker.ValidatePassword(password, email, username));

                string suggestions = string.Join(", ", result.Suggestions ?? new List<string>());
                if (!result.IsValid)
                {
                    pass = false;
                    RegisterErrorTextBlock.Inlines.Add(new Run($"-{result.Message}. Your password strength is {result.Strength} (score: {result.Score}/4). Suggestions: {suggestions}.\n")
                    {
                        Foreground = Brushes.IndianRed
                        
                    });
                    
                }
                if (result.IsValid)
                {
                  
                    RegisterErrorTextBlock.Inlines.Add(new Run($"-{result.Message}. Your password strength is {result.Strength} (score: {result.Score}/4). Suggestions: {suggestions}.\n")
                    {
                        Foreground = Brushes.ForestGreen

                    });
                    
                }
            }
            if (pass==false)
            {
               await ShakeControl(RegisterButton);
            }
            else
            {

                var request = new UserRegisterationRequest { Username = Usernametextbox.Text, Email = EmailTextbox.Text, Password = Passwordtextbox.Password };

                try
                {

                    var win = new IndeterminateProgressWindow("Please wait while we are waiting for the server to response.");
                    win.Show();
                    var response = await _authApi.RegisterStageOne(request);
                    win.Message = "Done!!!";
                    win.Close();
                    if (response.IsSuccessStatusCode && response.Content?.Message?.Any() == true)
                    {
                        bool success = false;
                        var msg = new ModernMessageBox($"Your data was successfully accepted! The password's strength is {response.Content.Strength} and with score of {response.Content.Score} out of 0. \n {string.Join("\n", response.Content.Message)} ",
                              "Operation Information",
                       ModernMessageboxIcons.Done,"OK!", "Cancel")
                        {
                            Button1Key = Key.Enter,
                            Button2Key = Key.Escape
                        };
                        msg.ShowDialog();
                        if (msg.Result == ModernMessageboxResult.Button1)
                        {
                            do
                            {
                                var msgBox = new ModernMessageBox(
                                    "Enter the code we sent to your email into the textbox:",
                                    "Email Verification",
                                    ModernMessageboxIcons.Info,
                                    "Confirm",
                                    "Reload Code")
                                {
                                    TextBoxText = "",
                                    TextBoxVisibility = Visibility.Visible,
                                    Button1Key = Key.Enter,
                                    Button2Key = Key.R
                                };

                                msgBox.ShowDialog();

                                if (msgBox.Result == ModernMessageboxResult.Button1)
                                {
                                    string Usercode = msgBox.TextBoxText.Trim();

                                    if (Usercode.Length != 6 || !Usercode.All(char.IsDigit))
                                    {
                                        var msgBox1 = new ModernMessageBox("Please enter a valid 6-digit code.", "Operation Failed",ModernMessageboxIcons.Error,"OK");
                                        msgBox1.ShowDialog();

                                    }
                                    else  //here when registration stage two begins!!
                                    {


                                        var requestFinalRegister = new UserRegisterationStageTwoRequest { Email = EmailTextbox.Text, Code = Usercode, FullName=FullNameTextbox.Text };

                                        try
                                        {
                                            var win2 = new IndeterminateProgressWindow("Please wait while we are waiting for the server to response.");
                                            win2.Show();
                                            var responseFinalRegister = await _authApi.RegisterStageTwo(requestFinalRegister);
                                            win2.Message = "Done!!!";
                                            win2.Close();
                                            if (responseFinalRegister.IsSuccessStatusCode && responseFinalRegister.Content?.Message?.Any() == true)
                                            {
                                                success = true;

                                                var msgBox1 = new ModernMessageBox($"Message : {string.Join("\n", responseFinalRegister.Content.Message)}",
                                                  "Operation Information",
                                                  ModernMessageboxIcons.Done,
                                                  "OK!");
                                                msgBox1.ShowDialog();
                                            }
                                            else
                                            {

                                                // When server returns 400, Refit puts the error JSON as a string here
                                                var rawError = responseFinalRegister.Error?.Content;

                                                if (!string.IsNullOrWhiteSpace(rawError))
                                                {
                                                    var errorResponse = JsonSerializer.Deserialize<UserRegisterationStageTwoResponse>(rawError, new JsonSerializerOptions
                                                    {
                                                        PropertyNameCaseInsensitive = true
                                                    });



                                                    if (errorResponse?.Message?.Any() == true)
                                                    {
                                                        var msgBox1 = new ModernMessageBox($"Message : {string.Join("\n", errorResponse.Message)} \n Error : {string.Join("\n", errorResponse.Error)}",
                                                        "Operation Information",
                                                        ModernMessageboxIcons.Error,
                                                        "OK");
                                                        msgBox1.ShowDialog();
                                                    }

                                                    else if (errorResponse?.Error?.Any() == true)
                                                    {
                                                        var msgBox1 = new ModernMessageBox($"Error : {string.Join("\n", errorResponse.Error)}",
                                                       "Operation Information",
                                                       ModernMessageboxIcons.Error,
                                                       "OK");
                                                        msgBox1.ShowDialog();
                                                    }
                                                    else
                                                    {
                                                        var msgBox1 = new ModernMessageBox($"Something went wrong!",
                                                       "Operation Information",
                                                       ModernMessageboxIcons.Error,
                                                       "OK");
                                                        msgBox1.ShowDialog();
                                                    }
                                                }
                                                else
                                                {
                                                    var msgBox1 = new ModernMessageBox($"Something went wrong!",
                                                     "Operation Information",
                                                     ModernMessageboxIcons.Error,
                                                     "OK");
                                                    msgBox1.ShowDialog();
                                                }
                                            }
                                        }
                                        catch (Exception ex)
                                        {
                                            var msgBox1 = new ModernMessageBox("Network error or app bug: " + ex.Message, "Operation Information" ,ModernMessageboxIcons.Error,"OK");
                                            msgBox1.ShowDialog();
                                 
                                        }



                                    } //here where registration stage two ends!!
                                }
                                else if (msgBox.Result == ModernMessageboxResult.Button2)
                                {

                                    // Add resend logic here

                                    var requestResend = new ReSendRegistrationCode { Email = EmailTextbox.Text.Trim() };

                                    try
                                    {
                                        var win3 = new IndeterminateProgressWindow("Please wait while we are waiting for the server to response.");
                                        win3.Show();
                                        var responseResend = await _authApi.ResendRegistrationCodeAgain(requestResend);
                                        win3.Message = "Done!!!";
                                        win3.Close();
                                        if (responseResend.IsSuccessStatusCode && responseResend.Content?.Message?.Any() == true)
                                        {
                                            var msgBox1 = new ModernMessageBox($"{string.Join("\n", responseResend.Content.Message)}",
                                             "Operation Information",
                                             ModernMessageboxIcons.Done,
                                             "OK!");
                                            msgBox1.ShowDialog();
                                        }
                                        else
                                        {
                                            // When server returns 400, Refit puts the error JSON as a string here
                                            var rawError = responseResend.Error?.Content;

                                            if (!string.IsNullOrWhiteSpace(rawError))
                                            {
                                                var errorResponse = JsonSerializer.Deserialize<ReSendRegistrationCodeResponse>(rawError, new JsonSerializerOptions
                                                {
                                                    PropertyNameCaseInsensitive = true
                                                });



                                                if (errorResponse?.Message?.Any() == true)
                                                {
                                                    var msgBox1 = new ModernMessageBox($"Message : {string.Join("\n", errorResponse.Message)}\n Error : {string.Join("\n", errorResponse.Error)}",
                                                   "Operation Information",
                                                  ModernMessageboxIcons.Error,
                                                   "OK");
                                                    msgBox1.ShowDialog();
                                                }

                                                else if (errorResponse?.Error?.Any() == true)
                                                {
                                                    var msgBox1 = new ModernMessageBox($"Error : {string.Join("\n", errorResponse.Error)}",
                                              "Operation Information",
                                             ModernMessageboxIcons.Error,
                                              "OK");
                                                    msgBox1.ShowDialog();
                                                }
                                                else
                                                {
                                                    var msgBox1 = new ModernMessageBox($"Something went wrong!",
                                                        "Operation Information",
                                                        ModernMessageboxIcons.Error,
                                                        "OK");
                                                    msgBox1.ShowDialog();
                                                }
                                            }
                                            else
                                            {
                                                var msgBox1 = new ModernMessageBox($"Something went wrong!",
                                                    "Operation Information",
                                                    ModernMessageboxIcons.Error,
                                                    "OK");
                                                msgBox1.ShowDialog();
                                            }
                                        }
                                    }
                                    catch (Exception ex)
                                    {
                                        var msgBox1 = new ModernMessageBox("Network error or app bug: " + ex.Message ,"Operation Information",ModernMessageboxIcons.Error,"OK");
                                        msgBox1.ShowDialog();
                                    }

                                }
                                else
                                {
                                    // User closed the messagebox
                                    break;
                                }
                            }
                            while (!success);
                        }

                    }
                    else
                    {
                        // When server returns 400, Refit puts the error JSON as a string here
                        var rawError = response.Error?.Content;
                        UserRegisterationResponse errorResponse = null;
                        ValidationErrorResponse errorResponse2 = null;

                        if (!string.IsNullOrWhiteSpace(rawError))
                        {
                            try
                            {
                                errorResponse = JsonSerializer.Deserialize<UserRegisterationResponse>(rawError, new JsonSerializerOptions
                                {
                                    PropertyNameCaseInsensitive = true
                                });
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
                                return;
                            }






                            if (errorResponse?.Message?.Any() == true && errorResponse?.PasswordCause == true && errorResponse?.Message?[0] == "Password contains banned words")
                            {
                                var msgBox1 = new ModernMessageBox($"{string.Join("\n", errorResponse.Message)}\n Suggestions are {string.Join("\n", errorResponse.Suggestions)} ", "Password is not acceptable!", ModernMessageboxIcons.Error, "OK");
                                msgBox1.ShowDialog();
                            }
                            else if (errorResponse?.Message?.Any() == true && errorResponse?.PasswordCause == true)
                            {
                                var msgBox1 = new ModernMessageBox($"{string.Join("\n", errorResponse.Message)} \n Your password strength is {errorResponse.Strength} and the score of the password is {errorResponse.Score} out of 0 \n it will need {errorResponse.CrackTime} \n Suggestions are {string.Join("\n", errorResponse.Suggestions)} ", "Password is not acceptable!", ModernMessageboxIcons.Error, "OK");
                                msgBox1.ShowDialog();
                            }

                            else if (errorResponse?.Error?.Any() == true)
                            {
                                if (errorResponse?.Message?.Any() == true)
                                {
                                    var msgBox1 = new ModernMessageBox($"Message : {string.Join("\n", errorResponse.Message)} \n  Error : {string.Join("\n", errorResponse.Error)}", "Operation failed!", ModernMessageboxIcons.Error, "OK");
                                    msgBox1.ShowDialog();
                                }
                                else
                                {
                                    var msgBox1 = new ModernMessageBox($"Error : {string.Join("\n", errorResponse.Error)}", "Operation failed!",ModernMessageboxIcons.Error, "OK");
                                    msgBox1.ShowDialog();
                                }
                            }

                            else
                            {
                                var msgBox1 = new ModernMessageBox($"Something went wrong!", "Operation failed!", ModernMessageboxIcons.Error, "OK");
                                msgBox1.ShowDialog();
                            }
                        }
                    }
                }

                catch (Exception ex)
                {

                    var msgBox1 = new ModernMessageBox($"Something went wrong!", "Operation failed!", ModernMessageboxIcons.Error, "OK");
                    msgBox1.ShowDialog();
                }
            }
       
        }

        private void ShowPassword_Click(object sender, RoutedEventArgs e)
        {
           if(Passwordtextbox.Visibility == Visibility.Visible)
            {
            Passwordtextbox.Visibility=Visibility.Collapsed;
            Passwordtextbox2.Visibility=Visibility.Visible;
            Passwordtextbox2.Text = Passwordtextbox.Password;
                ShowPasswordIcon.Kind = PackIconFontAwesomeKind.EyeRegular;
            }
            else
            {
                Passwordtextbox.Visibility = Visibility.Visible;
                Passwordtextbox2.Visibility = Visibility.Collapsed;
                Passwordtextbox.Password = Passwordtextbox2.Text;
                
                ShowPasswordIcon.Kind = PackIconFontAwesomeKind.EyeSlashRegular;
            }
        }

        private void ShowConfirmPassword_Click(object sender, RoutedEventArgs e)
        {
            if (ConfirmPasswordTextbox.Visibility == Visibility.Visible)
            {
                ConfirmPasswordTextbox.Visibility = Visibility.Collapsed;
                ConfirmPasswordTextbox2.Visibility = Visibility.Visible;
                ConfirmPasswordTextbox2.Text = ConfirmPasswordTextbox.Password;
                ShowConfirmPasswordIcon.Kind = PackIconFontAwesomeKind.EyeRegular;
            }
            else
            {
                ConfirmPasswordTextbox.Visibility = Visibility.Visible;
                ConfirmPasswordTextbox2.Visibility = Visibility.Collapsed;
                ConfirmPasswordTextbox.Password = ConfirmPasswordTextbox2.Text;

                ShowConfirmPasswordIcon.Kind = PackIconFontAwesomeKind.EyeSlashRegular;
            }
        }
    }
}
