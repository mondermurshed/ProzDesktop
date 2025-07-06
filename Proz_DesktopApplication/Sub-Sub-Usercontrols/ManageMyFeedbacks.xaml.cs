using System;
using System.Collections.Generic;
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
using ModernMessageBoxLib;

namespace Proz_DesktopApplication.Sub_Sub_Usercontrols
{
    /// <summary>
    /// Interaction logic for ManageMyFeedbacks.xaml
    /// </summary>
    public partial class ManageMyFeedbacks : UserControl
    {
        public ManageMyFeedbacks()
        {
            InitializeComponent();
            LoadFakeData();
        }
        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
           
        }
       
        private void LoadFakeData()
        {
            var feedbacks = new List<Feedback>();

            // Create 3 fake rows with auto-increment ID
            feedbacks.Add(new Feedback
            {
                Id = Guid.NewGuid(), // ✅ Generate a unique ID
                Type = "Improvement",
                Title = "Problem with my data insertion, i can't even resore data",
                Date = new DateTime(2023, 12, 24, 4, 24, 5),
                Completed = false
            });

            feedbacks.Add(new Feedback
            {
                Id = Guid.NewGuid(), // ✅ Generate a unique ID
                Type = "Help question",
                Title = "You can put a button to make things easy for me when navigting to the add column section",
                Date = new DateTime(2025, 5, 11, 18, 4, 15), // 6:04:15 PM
                Completed =true
            });

            feedbacks.Add(new Feedback
            {
                Id = Guid.NewGuid(), // ✅ Generate a unique ID
                Type = "Suggestion",
                Title = "You can put a button to make ",
                Date = new DateTime(2024, 9, 30, 12, 15, 30),
                Completed=false
            });
            feedbacks.Add(new Feedback
            {
                Id = Guid.NewGuid(), // ✅ Generate a unique ID
                Type = "Suggestion",
                Title = "You can put a button to make ",
                Date = new DateTime(2024, 9, 30, 12, 15, 30),
                Completed=false
            });
            feedbacks.Add(new Feedback
            {
                Id = Guid.NewGuid(), // ✅ Generate a unique ID
                Type = "Suggestion",
                Title = "You can put a button to make ",
                Date = new DateTime(2024, 9, 30, 12, 15, 30),
                Completed=false
            });
            feedbacks.Add(new Feedback
            {
                Id = Guid.NewGuid(), // ✅ Generate a unique ID
                Type = "Suggestion",
                Title = "You can put a button to make ",
                Date = new DateTime(2024, 9, 30, 12, 15, 30),
                Completed = false
            });
            feedbacks.Add(new Feedback
            {
                Id = Guid.NewGuid(), // ✅ Generate a unique ID
                Type = "Suggestion",
                Title = "You can put a button to make ",
                Date = new DateTime(2024, 9, 30, 12, 15, 30),
                Completed=true
            });
            feedbacks.Add(new Feedback
            {
                Id = Guid.NewGuid(), // ✅ Generate a unique ID
                Type = "Suggestion",
                Title = "You can put a button to make ",
                Date = new DateTime(2024, 9, 30, 12, 15, 30),
                Completed=false
            });
            feedbacks.Add(new Feedback
            {
                Id = Guid.NewGuid(), // ✅ Generate a unique ID
                Type = "Suggestion",
                Title = "You can put a button to make ",
                Date = new DateTime(2024, 9, 30, 12, 15, 30),
                Completed=false
            });
            feedbacks.Add(new Feedback
            {
                Id = Guid.NewGuid(), // ✅ Generate a unique ID
                Type = "Suggestion",
                Title = "You can put a button to make ",
                Date = new DateTime(2024, 9, 30, 12, 15, 30),
                Completed=true
            });
            feedbacks.Add(new Feedback
            {
                Id = Guid.NewGuid(), // ✅ Generate a unique ID
                Type = "Suggestion",
                Title = "You can put a button to make ",
                Date = new DateTime(2024, 9, 30, 12, 15, 30),
                Completed=false
            });
            feedbacks.Add(new Feedback
            {
                Id = Guid.NewGuid(), // ✅ Generate a unique ID
                Type = "Suggestion",
                Title = "You can put a button to make ",
                Date = new DateTime(2024, 9, 30, 12, 15, 30),
                Completed = false

            });
            // Assign to the DataGrid
            FeedbacksDatagrid.ItemsSource = feedbacks;
        }

        private void MyDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //if (FeedbacksDatagrid.SelectedItem is Feedback selected)
            //{
            //    MessageBox.Show($"You clicked row with ID {selected.id}, Type: {selected.Title}");
            //}
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
          
            QModernMessageBox.Show("The quick brown fox jumps over the lazy dog.", "hello world", QModernMessageBox.QModernMessageBoxButtons.YesNoCancel, ModernMessageboxIcons.Warning);
            QModernMessageBox.Warning("The quick brown fox jumps over the lazy dog.", "hello world");
            var msg = new ModernMessageBox("The quick brown fox jumps over the lazy dog.\n", "hello world", ModernMessageboxIcons.Info, "CSharp", "Java",
    "Python")
            {
                Button1Key = Key.D1,
                Button2Key = Key.D2,
                Button3Key = Key.D3,
                CheckboxText = "Don't show this again",
                CheckboxVisibility = Visibility.Visible,
                TextBoxText = "some staff",
                TextBoxVisibility = Visibility.Visible,
            };

            msg.ShowDialog();
            var win = new IndeterminateProgressWindow("Please wait while we are installing the virus into your computer. . .");
            win.Show();
            //Do Some Staff
            await Task.Delay(5000);
            //Change the message the 2nd time
            win.Message = "Done!!!";
            win.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
          if( QModernMessageBox.Show("Are you sure you wanna claar the data from the textboxes ?", "Warnning message",QModernMessageBox.QModernMessageBoxButtons.YesNo,ModernMessageboxIcons.Warning)==ModernMessageboxResult.Button1)
            {
                //idtextbox.Clear();
                //TEXT.Clear();
                //titletextbox.Clear();
                //feedbacktypecombobox.SelectedIndex = -1;
            }
      
        }

    
    }

    public class Feedback
    {
        public Guid Id { get; set; } // Real ID (GUID), not shown in UI
        public string Type { get; set; }
        public string Title { get; set; }
        public DateTime Date { get; set; }
        public bool Completed {  get; set; }
    }
}

