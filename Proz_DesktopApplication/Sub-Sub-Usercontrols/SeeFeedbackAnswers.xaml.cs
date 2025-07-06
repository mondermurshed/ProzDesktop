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

namespace Proz_DesktopApplication.Sub_Sub_Usercontrols
{
    /// <summary>
    /// Interaction logic for SeeFeedbackAnswers.xaml
    /// </summary>
    public partial class SeeFeedbackAnswers : UserControl
    {
        public SeeFeedbackAnswers()
        {
            InitializeComponent();
            LoadFakeData();
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
             
            });

            feedbacks.Add(new Feedback
            {
                Id = Guid.NewGuid(), // ✅ Generate a unique ID
                Type = "Help question",
                Title = "You can put a button to make things easy for me when navigting to the add column section",
                Date = new DateTime(2025, 5, 11, 18, 4, 15), // 6:04:15 PM
               
            });

            feedbacks.Add(new Feedback
            {
                Id = Guid.NewGuid(), // ✅ Generate a unique ID
                Type = "Suggestion",
                Title = "You can put a button to make ",
                Date = new DateTime(2024, 9, 30, 12, 15, 30),
               
            });
            feedbacks.Add(new Feedback
            {
                Id = Guid.NewGuid(), // ✅ Generate a unique ID
                Type = "Suggestion",
                Title = "You can put a button to make ",
                Date = new DateTime(2024, 9, 30, 12, 15, 30),
               
            });
            feedbacks.Add(new Feedback
            {
                Id = Guid.NewGuid(), // ✅ Generate a unique ID
                Type = "Suggestion",
                Title = "You can put a button to make ",
                Date = new DateTime(2024, 9, 30, 12, 15, 30),
              
            });
            feedbacks.Add(new Feedback
            {
                Id = Guid.NewGuid(), // ✅ Generate a unique ID
                Type = "Suggestion",
                Title = "You can put a button to make ",
                Date = new DateTime(2024, 9, 30, 12, 15, 30),
                
            });
            feedbacks.Add(new Feedback
            {
                Id = Guid.NewGuid(), // ✅ Generate a unique ID
                Type = "Suggestion",
                Title = "You can put a button to make ",
                Date = new DateTime(2024, 9, 30, 12, 15, 30),
               
            });
            feedbacks.Add(new Feedback
            {
                Id = Guid.NewGuid(), // ✅ Generate a unique ID
                Type = "Suggestion",
                Title = "You can put a button to make ",
                Date = new DateTime(2024, 9, 30, 12, 15, 30),
            
            });
            feedbacks.Add(new Feedback
            {
                Id = Guid.NewGuid(), // ✅ Generate a unique ID
                Type = "Suggestion",
                Title = "You can put a button to make ",
                Date = new DateTime(2024, 9, 30, 12, 15, 30),
              
            });
            feedbacks.Add(new Feedback
            {
                Id = Guid.NewGuid(), // ✅ Generate a unique ID
                Type = "Suggestion",
                Title = "You can put a button to make ",
                Date = new DateTime(2024, 9, 30, 12, 15, 30),
               
            });
            feedbacks.Add(new Feedback
            {
                Id = Guid.NewGuid(), // ✅ Generate a unique ID
                Type = "Suggestion",
                Title = "You can put a button to make ",
                Date = new DateTime(2024, 9, 30, 12, 15, 30),
               
            });
            feedbacks.Add(new Feedback
            {
                Id = Guid.NewGuid(), // ✅ Generate a unique ID
                Type = "Suggestion",
                Title = "You can put a button to make ",
                Date = new DateTime(2024, 9, 30, 12, 15, 30),
               
            });
            // Assign to the DataGrid
            FeedbacksDatagrid.ItemsSource = feedbacks;
        }
    }
    public class FeedbackAnswers
    {
        public Guid Id { get; set; } // Real ID (GUID), not shown in UI
        public string Type { get; set; }
        public string Title { get; set; }
        public DateTime Date { get; set; }
        
    }
}
