using Microsoft.Extensions.DependencyInjection;
using ModernMessageBoxLib;
using Proz_DesktopApplication.API;
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

namespace Proz_DesktopApplication.Sub_UserControls
{
  
  
    public partial class settingsAdmin : BaseUserControlMain
    {
        public IServiceProvider _services;
        public IAuthAPI _authApi;
        public GeneralAPICalling _generalAPICalling;
        public AdminAPIEndpointsDefinitions adminAPIEndpointsDefinitions;
        private bool _hasLoadedOnce = false;
        string? CompanyName;
        public settingsAdmin()
        {
            InitializeComponent();
            this.Loaded += settings_Loaded;
            this.Loaded += LoadingData;
        }
           private void settings_Loaded(object sender, RoutedEventArgs e)
           {
            Dispatcher.InvokeAsync(() =>
            {
                NewUsernameUsernameSection.ContextMenu = null;
                CurrentPasswordUsernameSection.ContextMenu = null;
                CurrentPasswordUsernameSection2.ContextMenu = null;

                CurrentPasswordPasswordSection.ContextMenu = null;
                CurrentPasswordPasswordSection2.ContextMenu = null;
                NewPasswordPasswordSection.ContextMenu = null;
                NewPasswordPasswordSection2.ContextMenu = null;
                ConfirmNewPasswordPasswordSection.ContextMenu = null;


                string baseTheme = Properties.Settings.Default.UserTheme;        // Light or Dark
                                                                                 // Blue, Red, Lime, etc.

                if (!string.IsNullOrEmpty(baseTheme))
                {

                    if (baseTheme == "Light")
                        LightMode.IsOn = true;
                    else
                        LightMode.IsOn = false;


                }
                else
                {
                    LightMode.IsOn = false;

                }

            }, System.Windows.Threading.DispatcherPriority.ContextIdle); // ← KEY POINT
            _generalAPICalling = GeneralAPICalling1 ?? throw new InvalidOperationException("Services1 is null");
            _services = Services1 ?? throw new InvalidOperationException("Services1 is null");
            _authApi = AuthApi1 ?? throw new InvalidOperationException("AuthApi1 is null");
            adminAPIEndpointsDefinitions = _AdminAPIEndpointsDefinitions1 ?? throw new InvalidOperationException("Services1 is null");
        }
        private async void LoadingData(object sender, RoutedEventArgs e)
        {
            if (_hasLoadedOnce)
                return;

            _hasLoadedOnce = true;

            this.IsEnabled = false;
            try
            {



                var win = new IndeterminateProgressWindow("Loading Your Data, please wait...");
                win.Show();
                var response = await adminAPIEndpointsDefinitions.GetPersonalData();
                var response2 = await adminAPIEndpointsDefinitions.GetCompanyName();
                win.Message = "Done!";
                win.Close();


                if (response.IsSuccessStatusCode)
                {
                    AccountRole.Text = response.Content.RoleName ?? "**No Role Applied**";
                    if(response.Content.RoleColor==null)
                    {
                        AccountRoleColor.Background = Brushes.Transparent;
                    }
                    else
                    {
                        var brushConverter = new BrushConverter();
                        Brush colorBrush = (Brush)brushConverter.ConvertFromString(response.Content.RoleColor);

                        // Apply it to the border background
                        AccountRoleColor.Background = colorBrush;
                    }
                    AccountStatus.Text = response.Content.AccountStatus;
                    AccountDate.Text = response.Content.AccountCreatedDate.ToString("dd/MM/yyyy");
                    Accountage.Text = response.Content.AccountAgeInDays + " Days";
                    fullnametextbox.Text = response.Content.FullName;
                    agetextbox.Text = response.Content.Age.ToString();
                    dateofbirthtextbox.Text = response.Content.Date_Of_Birth.ToString();
                    primaryplacecheckbox.Text = response.Content.Living_On_Primary_Place;
                    gendertextbox.Text = response.Content.Gender;
                    Nationalitytextbox.Text = response.Content.Nationality;
                 

                }
                if(response2.IsSuccessStatusCode)
                {
                    CompanyName = response2.Content.CompanyName != null ? response2.Content.CompanyName : "**No Company Name Assigned**";
                    CompanyNameTextbox.Text = CompanyName;
                    CompanyTitleTextbox.Text = CompanyName;
                    IsEnabled = true;
                    return;
                }
                else
                {
                    IsEnabled = true;
                    return;
                }

            }
            catch (Exception ex)
            {
                //var msgBox2 = new ModernMessageBox($"Didn't successfully connect to the server.",
                //                                               "Operation Information",
                //                                               ModernMessageboxIcons.Error,
                //                                               "OK");
                //msgBox2.ShowDialog();
                this.IsEnabled = true;
                return;
            }


        }
        private void ApplySettingsButton_Click(object sender, RoutedEventArgs e)
        {
            string theme = LightMode.IsOn ? "Light" : "Dark";
            string color = Properties.Settings.Default.UserThemeColor;
            if (RedRadioButton.IsChecked == true)
                color = "Red";
            else if (GreenRadioButton.IsChecked == true)
                color = "Green";
            else if (BlueRadioButton.IsChecked == true)
                color = "Blue";
            string fullTheme = $"{theme}.{color}";
            ControlzEx.Theming.ThemeManager.Current.ChangeTheme(Application.Current, fullTheme);

            Properties.Settings.Default.UserTheme = theme;
            Properties.Settings.Default.UserThemeColor = color;
            Properties.Settings.Default.Save();
            applychangesicon.Visibility = Visibility.Visible;
        }
        private void LightMode_Toggled(object sender, RoutedEventArgs e)
        {
            applychangesicon.Visibility = Visibility.Collapsed;
        }
        private void RadioButton_Click(object sender, RoutedEventArgs e)
        {
            applychangesicon.Visibility = Visibility.Collapsed;
        }

        private void RedRadioButton_Loaded(object sender, RoutedEventArgs e)
        {
            string color = Properties.Settings.Default.UserThemeColor;



            if (color == "Red")
            {
                RedRadioButton.IsChecked = true;

            }
            else if (color == "Green")
                GreenRadioButton.IsChecked = true;
            else if (color == "Blue")
                BlueRadioButton.IsChecked = true;
            else
                BlueRadioButton.IsChecked = true;


        }

        private void NewPasswordShowerButtonUsernamesection_Click(object sender, RoutedEventArgs e)
        {
            if (CurrentPasswordUsernameSection2.Visibility == Visibility.Visible)
            {
                CurrentPasswordUsernameSection.Password = CurrentPasswordUsernameSection2.Text;
                CurrentPasswordUsernameSection2.Visibility = Visibility.Collapsed;
                CurrentPasswordUsernameSection.Visibility = Visibility.Visible;
            }
            else
            {
                CurrentPasswordUsernameSection2.Text = CurrentPasswordUsernameSection.Password;
                CurrentPasswordUsernameSection2.Visibility = Visibility.Visible;
                CurrentPasswordUsernameSection.Visibility = Visibility.Collapsed;
            }
        }

        private void NewPasswordShowerButton_Click(object sender, RoutedEventArgs e)
        {
            if (NewPasswordPasswordSection2.Visibility == Visibility.Visible)
            {
                NewPasswordPasswordSection.Password = NewPasswordPasswordSection2.Text;
                NewPasswordPasswordSection2.Visibility = Visibility.Collapsed;
                NewPasswordPasswordSection.Visibility = Visibility.Visible;
            }
            else
            {
                NewPasswordPasswordSection2.Text = NewPasswordPasswordSection.Password;
                NewPasswordPasswordSection2.Visibility = Visibility.Visible;
                NewPasswordPasswordSection.Visibility = Visibility.Collapsed;
            }
        }



        private void NewPasswordcurrentShowerButton_Click(object sender, RoutedEventArgs e)
        {
            if (CurrentPasswordPasswordSection2.Visibility == Visibility.Visible)
            {
                CurrentPasswordPasswordSection.Password = CurrentPasswordPasswordSection2.Text;
                CurrentPasswordPasswordSection2.Visibility = Visibility.Collapsed;
                CurrentPasswordPasswordSection.Visibility = Visibility.Visible;
            }
            else
            {
                CurrentPasswordPasswordSection2.Text = CurrentPasswordPasswordSection.Password;
                CurrentPasswordPasswordSection2.Visibility = Visibility.Visible;
                CurrentPasswordPasswordSection.Visibility = Visibility.Collapsed;
            }
        }

        private async void SetNewPasswordButton_Click(object sender, RoutedEventArgs e)
        {
            if (CurrentPasswordPasswordSection2.Visibility == Visibility.Visible)
            {
                CurrentPasswordPasswordSection.Password = CurrentPasswordPasswordSection2.Text;
                CurrentPasswordPasswordSection2.Visibility = Visibility.Collapsed;
                CurrentPasswordPasswordSection.Visibility = Visibility.Visible;
            }

            if (NewPasswordPasswordSection2.Visibility == Visibility.Visible)
            {
                NewPasswordPasswordSection.Password = NewPasswordPasswordSection2.Text;
                NewPasswordPasswordSection2.Visibility = Visibility.Collapsed;
                NewPasswordPasswordSection.Visibility = Visibility.Visible;
            }

            if (CurrentPasswordPasswordSection.Password == "" || NewPasswordPasswordSection.Password == "" || ConfirmNewPasswordPasswordSection.Password == "")
            {

                var msg = new ModernMessageBox($"Please fill all your fields",
                                                         "Operation Information",
                                                         ModernMessageboxIcons.Error,
                                                         "OK");
                msg.ShowDialog();
                return;
            }
            if (NewPasswordPasswordSection.Password != ConfirmNewPasswordPasswordSection.Password)
            {
                var msg = new ModernMessageBox($"Please make sure that your confirm password field is the same as your new entered password",
                                               "Operation Information",
                                               ModernMessageboxIcons.Error,
                                               "OK");
                msg.ShowDialog();
                return;
            }



            try
            {
                this.IsEnabled = false;
                var request = new ChangePasswordRequest { NewPassword = NewPasswordPasswordSection.Password, CurrentPassword = CurrentPasswordPasswordSection.Password };
                var win = new IndeterminateProgressWindow("Please wait while we are waiting for the server to response.");
                win.Show();
                var response = await _generalAPICalling.ChangeMyPassword(request);
                win.Message = "Done!!!";
                win.Close();


                if (response.IsSuccessStatusCode && response.Content?.Message?.Any() == true)
                {
                    this.IsEnabled = true;
                    var msg = new ModernMessageBox($"Message : {string.Join("\n", response.Content.Message)}",
                                                             "Operation Information",
                                                             ModernMessageboxIcons.Done,
                                                             "OK!");
                    msg.ShowDialog();

                    return;
                }
                else
                {
                    // When server returns 400, Refit puts the error JSON as a string here
                    var rawError = response.Error?.Content;

                    if (!string.IsNullOrWhiteSpace(rawError))
                    {

                        ChangePasswordResponse errorResponse = new ChangePasswordResponse();
                        ValidationErrorResponse errorResponse2 = new ValidationErrorResponse();

                        try
                        {
                            errorResponse = JsonSerializer.Deserialize<ChangePasswordResponse>(rawError, new JsonSerializerOptions
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

                            var msg = new ModernMessageBox($"{errorResponse2.Message}\n\n{string.Join("\n", flatErrors)}",
                                "Validation Error",
                                ModernMessageboxIcons.Error,
                                "Ok");
                            msg.ShowDialog();
                            this.IsEnabled = true;
                            return;
                        }




                        if (errorResponse?.Errors?.Any() == true)
                        {
                            this.IsEnabled = true;
                            var msg = new ModernMessageBox($"Error : {string.Join("\n", errorResponse.Errors)} \n Nothing was done here after this operation.",
                                                          "Operation Information",
                                                          ModernMessageboxIcons.Error,
                                                          "OK");
                            msg.ShowDialog();
                        }
                    }
                    else
                    {

                        this.IsEnabled = true;
                        var msg = new ModernMessageBox($"Something went wrong.",
                                                        "Operation Information",
                                                        ModernMessageboxIcons.Error,
                                                         "OK");
                        msg.ShowDialog();
                    }
                }
            }
            catch (Exception ex)
            {

                this.IsEnabled = true;
                var msg = new ModernMessageBox($"Something went wrong. \n {ex.Message}",
                                          "Operation Information",
                                          ModernMessageboxIcons.Error,
                                          "OK");
                msg.ShowDialog();
            }
        }
        //end
        private async void SetNewUserNameButton_Click(object sender, RoutedEventArgs e)
        {


            if (CurrentPasswordUsernameSection2.Visibility == Visibility.Visible)
            {
                CurrentPasswordUsernameSection.Password = CurrentPasswordUsernameSection2.Text;
                CurrentPasswordUsernameSection2.Visibility = Visibility.Collapsed;
                CurrentPasswordUsernameSection.Visibility = Visibility.Visible;
            }

            if (CurrentPasswordUsernameSection.Password == "" || NewUsernameUsernameSection.Text == "")
            {
                //QModernMessageBox.Show($"Message : {string.Join("\n", responseFinalRegister.Content.Message)}",
                //                                         "Operation Information",
                //                                         QModernMessageBox.QModernMessageBoxButtons.Ok,
                //                                         ModernMessageboxIcons.Done);
                var msg = new ModernMessageBox($"Please fill all your fields",
                                                         "Operation Information",
                                                         ModernMessageboxIcons.Error,
                                                         "OK");
                msg.ShowDialog();
                return;
            }



            try
            {
                this.IsEnabled = false;
                var request = new ChangeUsernameRequest { NewUsername = NewUsernameUsernameSection.Text, CurrentPassword = CurrentPasswordUsernameSection.Password };
                var win = new IndeterminateProgressWindow("Please wait while we are waiting for the server to response.");
                win.Show();
                var response = await _generalAPICalling.ChangeMyUsername(request);
                win.Message = "Done!!!";
                win.Close();


                if (response.IsSuccessStatusCode && response.Content?.Message?.Any() == true)
                {
                    this.IsEnabled = true;
                    var msg = new ModernMessageBox($"Message : {string.Join("\n", response.Content.Message)}",
                                                             "Operation Information",
                                                             ModernMessageboxIcons.Done,
                                                             "OK!");
                    msg.ShowDialog();

                    return;
                }
                else
                {
                    // When server returns 400, Refit puts the error JSON as a string here
                    var rawError = response.Error?.Content;

                    if (!string.IsNullOrWhiteSpace(rawError))
                    {

                        ChangeUsernameResponse errorResponse = new ChangeUsernameResponse();
                        ValidationErrorResponse errorResponse2 = new ValidationErrorResponse();

                        try
                        {
                            errorResponse = JsonSerializer.Deserialize<ChangeUsernameResponse>(rawError, new JsonSerializerOptions
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

                            var msg = new ModernMessageBox($"{errorResponse2.Message}\n\n{string.Join("\n", flatErrors)}",
                                "Validation Error",
                                ModernMessageboxIcons.Error,
                                "Ok");
                            msg.ShowDialog();
                            this.IsEnabled = true;
                            return;
                        }




                        if (errorResponse?.Errors?.Any() == true)
                        {
                            this.IsEnabled = true;
                            var msg = new ModernMessageBox($"Error : {string.Join("\n", errorResponse.Errors)} \n Nothing was done here after this operation.",
                                                          "Operation Information",
                                                          ModernMessageboxIcons.Error,
                                                          "OK");
                            msg.ShowDialog();
                        }
                    }
                    else
                    {

                        this.IsEnabled = true;
                        var msg = new ModernMessageBox($"Something went wrong.",
                                                        "Operation Information",
                                                        ModernMessageboxIcons.Error,
                                                         "OK");
                        msg.ShowDialog();
                    }
                }
            }
            catch (Exception ex)
            {

                this.IsEnabled = true;
                var msg = new ModernMessageBox($"Something went wrong. \n {ex.Message}",
                                          "Operation Information",
                                          ModernMessageboxIcons.Error,
                                          "OK");
                msg.ShowDialog();
            }

        }

        private void Usernametextbox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            char inputChar = e.Text[0];
            //if (e.Text.Any(char.IsUpper))
            //{
            //    e.Handled = true;
            //}

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

        private void LogOutButton_Click(object sender, RoutedEventArgs e)
        {

            var signInWindow = _services.GetRequiredService<SigninWindow>();

            TokenStorage.DeleteTokens();
            Application.Current.MainWindow = signInWindow;
            signInWindow.Show();
            var mainWindow = Window.GetWindow(this) as MainDashboardWindow;

            mainWindow?.Close();



        }

        private void EnableSalaryChange(object sender, RoutedEventArgs e)
        {
          if(  CompanyNameTextbox.IsReadOnly==true && changeCompanyNamebutton.IsEnabled==false)
            {
                CompanyNameTextbox.IsReadOnly = false;
                changeCompanyNamebutton.IsEnabled = true;

            }
          else
            {
                CompanyNameTextbox.IsReadOnly = true;
                changeCompanyNamebutton.IsEnabled = false;
                CompanyNameTextbox.Text = CompanyName ?? "**No Company Name Set**";
            }
        }

        private async void changeCompanyNamebutton_Click(object sender, RoutedEventArgs e)
        {
            this.IsEnabled = false;
            if(CompanyNameTextbox.Text== CompanyName)
            {
                var msgBox2 = new ModernMessageBox($"Please change the field to update the company name.",
                                                               "Operation Information",
                                                               ModernMessageboxIcons.Error,
                                                               "OK");
                msgBox2.ShowDialog();
                this.IsEnabled = true;
                return;
            }
            try
            {



                var win = new IndeterminateProgressWindow("Appling The Update, Please wait...");
                win.Show();
                var request = new UpdateCompanyNameRequest
                {
                    CompanyName = CompanyNameTextbox.Text
                };
                var response = await adminAPIEndpointsDefinitions.CompanyNameChange(request);

                win.Message = "Done!";
                win.Close();


                if (response.IsSuccessStatusCode)
                {
                    var msgBox2 = new ModernMessageBox($"Company name was successfully changed!.",
                                                               "Operation Information",
                                                               ModernMessageboxIcons.Done,
                                                               "OK");
                    msgBox2.ShowDialog();

                    CompanyName = response.Content.NewCompanyName != null ? response.Content.NewCompanyName : "**No Company Name Assigned**";
                    CompanyNameTextbox.Text = CompanyName;
                    CompanyTitleTextbox.Text = CompanyName;
                    this.IsEnabled = true;
                    CompanyNameTextbox.IsReadOnly = true;
                    changeCompanyNamebutton.IsEnabled = false;
                    return;

                }
                else if (response.Error.Content!=null)
                {
                    // When server returns 400, Refit puts the error JSON as a string here
                    var rawError = response.Error?.Content;

                    ValidationErrorResponse errorResponse2 = null;
                    if (!string.IsNullOrWhiteSpace(rawError))
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
                  



                }
                else
                {
                    var msgBox2 = new ModernMessageBox($"Couldn't update the company name.",
                                                             "Operation Information",
                                                             ModernMessageboxIcons.Error,
                                                             "OK");
                }
            }
            catch (Exception ex)
            {
                var msgBox2 = new ModernMessageBox($"Didn't successfully connect to the server.",
                                                               "Operation Information",
                                                               ModernMessageboxIcons.Error,
                                                               "OK");
                msgBox2.ShowDialog();
                this.IsEnabled = true;
                return;
            }
        }
    }
}
