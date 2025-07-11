using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace Proz_DesktopApplication.Sub_Sub_Sub_Usercontrols
{
    public partial class ViewEmpoyeesFeedbackRequests : UserControl
    {
        private List<string> subDepartments;
        private List<EmployeeFeedbackRequest> allFeedbacks;
        private List<EmployeeFeedbackRequest> filteredFeedbacks;
        private EmployeeFeedbackRequest selectedFeedback;

        public ViewEmpoyeesFeedbackRequests()
        {
            InitializeComponent();
            LoadSubDepartments();
            LoadFakeFeedbacks();
            SubDepartmentComboBox.SelectedIndex = 0;
            FilterFeedbacks();
        }

        private void LoadSubDepartments()
        {
            subDepartments = new List<string> { "IT", "HR", "Finance", "Logistics" };
            SubDepartmentComboBox.ItemsSource = subDepartments;
        }

        private void LoadFakeFeedbacks()
        {
            allFeedbacks = new List<EmployeeFeedbackRequest>
            {
                new EmployeeFeedbackRequest
                {
                    Id = Guid.NewGuid(),
                    EmployeeName = "Ahmed Saleh",
                    Type = "Suggestion",
                    Title = "Add Dark Mode",
                    Description = "It would be great to have a dark theme for night work.",
                    Date = new DateTime(2025, 7, 5),
                   
                },
                new EmployeeFeedbackRequest
                {
                    Id = Guid.NewGuid(),
                    EmployeeName = "Fatima Ali",
                    Type = "Issue",
                    Title = "App Crashes",
                    Description = "The app crashes when I click the Submit button.",
                    Date = new DateTime(2025, 7, 2),
                  
                }
            };
        }

        private void FilterFeedbacks()
        {

        }

        private void GetButton_Click(object sender, RoutedEventArgs e)
        {
            FilterFeedbacks();
        }

        private void FeedbackRequestsDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (FeedbackRequestsDataGrid.SelectedItem is EmployeeFeedbackRequest selected)
            {
                selectedFeedback = selected;
                DescriptionTextbox.Text = selected.Description;
                AnswerTextbox.Text = selected.Answer ?? "";
            }
        }

        private void SubmitAnswerButton_Click(object sender, RoutedEventArgs e)
        {
            if (selectedFeedback == null)
            {
                MessageBox.Show("Please select a feedback first.", "No Feedback Selected", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            selectedFeedback.Answer = AnswerTextbox.Text;
            MessageBox.Show($"Answer submitted to {selectedFeedback.EmployeeName}'s feedback.", "Submitted", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void ClearFields()
        {
            DescriptionTextbox.Clear();
            AnswerTextbox.Clear();
            selectedFeedback = null;
        }
    }

    public class EmployeeFeedbackRequest
    {
        public Guid Id { get; set; }
        public string EmployeeName { get; set; }
        public string Type { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public string Answer { get; set; }
    }
}
