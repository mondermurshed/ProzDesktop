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
namespace Proz_DesktopApplication
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class SigninWindow : MetroWindow
    {
        public SigninWindow()
        {
            InitializeComponent();



   
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
          
            
            string baseTheme = Properties.Settings.Default.UserTheme;        // Light or Dark
            string color = Properties.Settings.Default.UserThemeColor;       // Blue, Red, Lime, etc.

            if (!string.IsNullOrWhiteSpace(baseTheme) && !string.IsNullOrWhiteSpace(color))
            {
                string fullTheme = $"{baseTheme}.{color}"; // e.g. Light.Blue or Dark.Red
                ControlzEx.Theming.ThemeManager.Current.ChangeTheme(Application.Current, fullTheme);

            }
            else
            {
                ControlzEx.Theming.ThemeManager.Current.ChangeTheme(Application.Current, "Dark.Blue");
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

            // Allow letters, digits, and underscore
            if (char.IsLetterOrDigit(inputChar) || inputChar == '_')
                return;

            // Block everything else
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
            if (e.Text.Any(char.IsUpper))
            {
                e.Handled = true;
            }

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
        private async void loginbutton_Click(object sender, RoutedEventArgs e)
        {
            //await ShakeControl(loginbutton);
            this.IsEnabled = false;
            loginbutton.IsEnabled = false; //if it was wrong then do this 
            var win = new IndeterminateProgressWindow("Please wait while we are load your data. . .");
            win.Show();
            await Task.Delay(500);
            win.Message = "Done!!!";
            win.Close();



            this.Opacity = 1.0;

            var fadeOut = new DoubleAnimation(1, 0.2, TimeSpan.FromMilliseconds(250));
            var tcs = new TaskCompletionSource<bool>();

            fadeOut.Completed += (s, ev) => tcs.SetResult(true);

            this.BeginAnimation(Window.OpacityProperty, fadeOut);

            
            await tcs.Task;
          
            this.Hide();
            MainDashboardWindow ob = new MainDashboardWindow();
            ob.Show();
        }

        private async void registerbutton_Click(object sender, RoutedEventArgs e)
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

            var ob = new RegisterWindow();
            ob.Show();
        }
    }
}