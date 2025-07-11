using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Proz_DesktopApplication.Sub_Sub_Sub_Usercontrols
{
    public partial class AnsweredFeedbacksRequestsByTheManager : UserControl
    {
        private List<string> subDepartments;
        private List<AnsweredFeedback> allFeedbacks;
        private List<AnsweredFeedback> filteredFeedbacks;

        public AnsweredFeedbacksRequestsByTheManager()
        {
            InitializeComponent();
            LoadSubDepartments();
            LoadFakeAnsweredFeedbacks();
            SubDepartmentComboBox.SelectedIndex = 0;
            FilterAndShow();
        }

        private void LoadSubDepartments()
        {
            subDepartments = new List<string> { "IT", "HR", "Finance", "Logistics" };
            SubDepartmentComboBox.ItemsSource = subDepartments;
        }

        private void LoadFakeAnsweredFeedbacks()
        {
            allFeedbacks = new List<AnsweredFeedback>
            {
                new AnsweredFeedback
                {
                    Id = Guid.NewGuid(),
                    EmployeeName = "Ahmed Saleh",
                    Title = "Bug in Login Page",
                    Type = "Issue",
                    Description = "I cannot login when using special characters.",
                    Answer = "Fixed in latest patch.",
                    AnsweredAt = new DateTime(2025, 7, 4, 15, 0, 0),
                    Respondent = "Manager Khalid",
                    Date = new DateTime(2025, 7, 2),
                    SubDepartment = "IT"
                },
                new AnsweredFeedback
                {
                    Id = Guid.NewGuid(),
                    EmployeeName = "Fatima Ali",
                    Title = "Feature Suggestion",
                    Type = "Suggestion",
                    Description = "Add search filter for feedbacks.",
                    Answer = "This will be included in version 2.0.",
                    AnsweredAt = new DateTime(2025, 7, 5, 10, 30, 0),
                    Respondent = "Manager Huda",
                    Date = new DateTime(2025, 7, 1),
                    SubDepartment = "Finance"
                }
            };
        }

        private void FilterAndShow()
        {
            string selectedDept = SubDepartmentComboBox.SelectedItem as string;
            if (string.IsNullOrWhiteSpace(selectedDept)) return;

            filteredFeedbacks = allFeedbacks
                .Where(f => f.SubDepartment == selectedDept)
                .ToList();

            AnsweredFeedbacksDataGrid.ItemsSource = filteredFeedbacks;
            AnsweredFeedbacksDataGrid.Items.Refresh();
            ClearFields();
        }

        private void GetButton_Click(object sender, RoutedEventArgs e)
        {
            FilterAndShow();
        }

        private void AnsweredFeedbacksDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (AnsweredFeedbacksDataGrid.SelectedItem is AnsweredFeedback selected)
            {
                DescriptionTextbox.Text = selected.Description;
                AnswerTextbox.Text = selected.Answer;
                AnswerDateTextbox.Text = selected.AnsweredAt.ToString("yyyy-MM-dd HH:mm");
                RespondentTextbox.Text = selected.Respondent;
            }
        }

        private void ClearFields()
        {
            DescriptionTextbox.Clear();
            AnswerTextbox.Clear();
            AnswerDateTextbox.Clear();
            RespondentTextbox.Clear();
        }
    }

    public class AnsweredFeedback
    {
        public Guid Id { get; set; }
        public string EmployeeName { get; set; }
        public string Title { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public string SubDepartment { get; set; }

        public string Answer { get; set; }
        public DateTime AnsweredAt { get; set; }
        public string Respondent { get; set; }
    }
}
