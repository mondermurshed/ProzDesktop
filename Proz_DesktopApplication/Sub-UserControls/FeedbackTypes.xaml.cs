using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace Proz_DesktopApplication.Sub_UserControls
{
    public partial class FeedbackTypes : UserControl
    {
        public FeedbackTypes()
        {
            InitializeComponent();
            LoadFeedbackTypes(); // Load existing types
        }

   

        private List<FeedbackTypeModel> feedbackTypes = new List<FeedbackTypeModel>();

        private void LoadFeedbackTypes()
        {
            // TODO: Later, load from API or database
            feedbackTypes = new List<FeedbackTypeModel>
            {
                new FeedbackTypeModel { FeedbackType = "Bug" },
                new FeedbackTypeModel { FeedbackType = "Question" },
                new FeedbackTypeModel { FeedbackType = "Advice" }
            };

            FeedbackTypesDataGrid.ItemsSource = null;
            FeedbackTypesDataGrid.ItemsSource = feedbackTypes;
        }

        private void AddFeedbackTypeButton_Click(object sender, RoutedEventArgs e)
        {
            string newType = FeedbackTypeTextBox.Text.Trim();

            if (string.IsNullOrEmpty(newType))
            {
                MessageBox.Show("Please enter a feedback type name.");
                return;
            }

      
            FeedbackTypeTextBox.Clear();
        }

        private void RemoveFeedbackTypeButton_Click(object sender, RoutedEventArgs e)
        {
            if (FeedbackTypesDataGrid.SelectedItem is FeedbackTypeModel selected)
            {
                // TODO: Call API to remove by ID

                // Remove from list (fake)
                feedbackTypes.Remove(selected);
                LoadFeedbackTypes();
            }
        }
    }
    public class FeedbackTypeModel
    {
        public Guid Id { get; set; }
        public string FeedbackType { get; set; }
    }
}



//Question

//Bug

//Complaint And Advice

//Feature Request

