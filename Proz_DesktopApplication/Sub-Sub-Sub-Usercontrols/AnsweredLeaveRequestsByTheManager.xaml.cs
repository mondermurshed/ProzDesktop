using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Proz_DesktopApplication.Sub_Sub_Sub_Usercontrols
{
    public partial class AnsweredLeaveRequestsByTheManager : UserControl
    {
        private List<string> subDepartments;
        private List<LeaveRequestForReviewCompleted> allRequests;
        private List<LeaveRequestForReviewCompleted> filteredCompletedRequests;

        public AnsweredLeaveRequestsByTheManager()
        {
            InitializeComponent();
            LoadSubDepartments();
            LoadFakeReviewedRequests();
            SubDepartmentComboBox.SelectedIndex = 0;
            FilterAndShow();
        }

        private void LoadSubDepartments()
        {
            subDepartments = new List<string> { "IT", "HR", "Finance", "Logistics" };
            SubDepartmentComboBox.ItemsSource = subDepartments;
        }

        private void LoadFakeReviewedRequests()
        {
            allRequests = new List<LeaveRequestForReviewCompleted>
            {
                new LeaveRequestForReviewCompleted
                {
                    Id = Guid.NewGuid(),
                    EmployeeName = "Ahmed Saleh",
                    Start = new DateOnly(2025, 6, 1),
                    End = new DateOnly(2025, 6, 3),
                    Reason = "Doctor Appointment",
                  
                    DepartmentManagerMessage = "Approved for medical reasons.",
                    SubDepartment = "IT"
                },
                new LeaveRequestForReviewCompleted
                {
                    Id = Guid.NewGuid(),
                    EmployeeName = "Fatima Ali",
                    Start = new DateOnly(2025, 6, 10),
                    End = new DateOnly(2025, 6, 15),
                    Reason = "Vacation",
                  
                    DepartmentManagerMessage = "Too many employees already on leave.",
                    SubDepartment = "Finance"
                },
                new LeaveRequestForReviewCompleted
                {
                    Id = Guid.NewGuid(),
                    EmployeeName = "Yasir Nabil",
                    Start = new DateOnly(2025, 6, 20),
                    End = new DateOnly(2025, 6, 22),
                    Reason = "Family Event",
                 
                    DepartmentManagerMessage = "Approved after project delivery.",
                    SubDepartment = "IT"
                }
            };
        }

        private void FilterAndShow()
        {

        }

        private void GetButton_Click(object sender, RoutedEventArgs e)
        {
            FilterAndShow();
            ReasonTextbox.Clear();
            ManagerMessageTextbox.Clear();
        }

        private void CompletedRequestsDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (CompletedRequestsDataGrid.SelectedItem is LeaveRequestForReviewCompleted selected)
            {
                ReasonTextbox.Text = selected.Reason;
                ManagerMessageTextbox.Text = selected.DepartmentManagerMessage;
            }
        }
    }

    public class LeaveRequestForReviewCompleted
    {
        public Guid Id { get; set; }
        public string EmployeeName { get; set; }
        public DateOnly Start { get; set; }
        public DateOnly End { get; set; }
        public string Reason { get; set; }
        public string DepartmentManagerMessage { get; set; }
        public string SubDepartment { get; set; }
    }
}
