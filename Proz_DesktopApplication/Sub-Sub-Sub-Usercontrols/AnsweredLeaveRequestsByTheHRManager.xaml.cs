using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Proz_DesktopApplication.Sub_Sub_Sub_Usercontrols
{
    public partial class AnsweredLeaveRequestsByTheHRManager : UserControl
    {
        private List<string> subDepartments;
        private List<LeaveRequestHRCompleted> allRequests;
        private List<LeaveRequestHRCompleted> filteredRequests;

        public AnsweredLeaveRequestsByTheHRManager()
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
            allRequests = new List<LeaveRequestHRCompleted>
            {
                new LeaveRequestHRCompleted
                {
                    Id = Guid.NewGuid(),
                    EmployeeName = "Ahmed Saleh",
                    Start = new DateOnly(2025, 6, 1),
                    End = new DateOnly(2025, 6, 3),
                    Reason = "Doctor Appointment",
                   
                    FinalMessage = "HR Approved - Medical leave granted.",
                    DepartmentManagerMessage = "Manager confirmed documentation.",
                    SubDepartment = "IT",
                    HasSanctions = true,
                },
                new LeaveRequestHRCompleted
                {
                    Id = Guid.NewGuid(),
                    EmployeeName = "Fatima Ali",
                    Start = new DateOnly(2025, 6, 10),
                    End = new DateOnly(2025, 6, 15),
                    Reason = "Vacation",
                   
                    FinalMessage = "Rejected - Too close to peak season.",
                    DepartmentManagerMessage = "Manager supported leave request.",
                    SubDepartment = "Finance",
                    HasSanctions = false,
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
            DepartmentManagerMessageTextbox.Clear();
            HRFinalMessageTextbox.Clear();
        }

        private void CompletedRequestsDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (CompletedRequestsDataGrid.SelectedItem is LeaveRequestHRCompleted selected)
            {
                ReasonTextbox.Text = selected.Reason;
                DepartmentManagerMessageTextbox.Text = selected.DepartmentManagerMessage;
                HRFinalMessageTextbox.Text = selected.FinalMessage;
                NeededApprovalCheckbox.IsChecked = selected.HasSanctions;
            }
        }
    }

    public class LeaveRequestHRCompleted
    {
        public Guid Id { get; set; }
        public string EmployeeName { get; set; }
        public DateOnly Start { get; set; }
        public DateOnly End { get; set; }
        public string Reason { get; set; }
        public string DepartmentManagerMessage { get; set; }
       
        public string FinalMessage { get; set; }
        public bool HasSanctions {  get; set; }
        public string SubDepartment { get; set; }
    }
}
