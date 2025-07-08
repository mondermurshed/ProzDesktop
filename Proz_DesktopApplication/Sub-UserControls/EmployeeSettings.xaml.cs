using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
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

using MaterialDesignThemes.Wpf;     



namespace Proz_DesktopApplication.Sub_UserControls
{
    /// <summary>
    /// Interaction logic for UserSettings.xaml
    /// </summary>
    public partial class UserSettings : UserControl
    {
        public UserSettings()
        {
            InitializeComponent();

          
        }
        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            Dispatcher.InvokeAsync(() =>
            {
                NewUsernameUsernameSection.ContextMenu = null;
                CurrentPasswordUsernameSection.ContextMenu = null;
                CurrentPasswordPasswordSection.ContextMenu = null;
                NewPasswordPasswordSection.ContextMenu = null;
                NewPasswordTextboxPasswordSection.ContextMenu = null;
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

        private void NewPasswordShowerButton_Click(object sender, RoutedEventArgs e)
        {
            if(NewPasswordTextboxPasswordSection.Visibility==Visibility.Visible)
            {
                NewPasswordPasswordSection.Password = NewPasswordTextboxPasswordSection.Text;
                NewPasswordTextboxPasswordSection.Visibility = Visibility.Collapsed;
                NewPasswordPasswordSection.Visibility = Visibility.Visible;
            }
            else
            {
                NewPasswordTextboxPasswordSection.Text = NewPasswordPasswordSection.Password;
                NewPasswordTextboxPasswordSection.Visibility = Visibility.Visible;
                NewPasswordPasswordSection.Visibility = Visibility.Collapsed;
            }
        }

        private void SetNewPasswordButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void SetNewUserNameButton_Click(object sender, RoutedEventArgs e)
        {

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

      
    }
}
