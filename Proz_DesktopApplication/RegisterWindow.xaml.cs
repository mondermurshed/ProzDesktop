using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
using ModernMessageBoxLib;

namespace Proz_DesktopApplication
{

    public partial class RegisterWindow : MetroWindow
    {
      
    public RegisterWindow()
        {
            InitializeComponent();
           
           
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
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

            var ob = new SigninWindow();
            ob.Show();
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
                MessageBox.Show("g");
                ConfirmPasswordTextbox.Password = ConfirmPasswordTextbox2.Text;
                ConfirmPasswordTextbox2.Visibility = Visibility.Collapsed;
                ConfirmPasswordTextbox.Visibility = Visibility.Visible;
                ShowConfirmPasswordIcon.Kind = PackIconFontAwesomeKind.EyeSlashRegular;
            }
          
            if (string.IsNullOrEmpty(Usernametextbox.Text) || string.IsNullOrEmpty(EmailTextbox.Text)
                || string.IsNullOrEmpty(Passwordtextbox.Password) || string.IsNullOrEmpty(ConfirmPasswordTextbox.Password))
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
                //call endpoint here...
                this.IsEnabled = false;
                //var win = new IndeterminateProgressWindow("Please wait while we are creating your account. . .");
                //win.Show();
                //await Task.Delay(5000);
                //win.Close();
                this.IsEnabled=true;
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
