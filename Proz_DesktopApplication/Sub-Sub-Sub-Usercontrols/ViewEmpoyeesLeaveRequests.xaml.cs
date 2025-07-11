using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace Proz_DesktopApplication.Sub_Sub_Sub_Usercontrols
{
    public partial class ViewEmpoyeesLeaveRequests : UserControl
    {
        private List<string> subDepartments;
        private List<LeaveRequestForReview> allRequests;
        private List<LeaveRequestForReview> filteredRequests;
        private LeaveRequestForReview selectedRequest;

        public ViewEmpoyeesLeaveRequests()
        {
            InitializeComponent();
            LoadSubDepartments();
            LoadFakeLeaveRequests();
            SubDepartmentComboBox.SelectedIndex = 0;
        }

        private void LoadSubDepartments()
        {
            subDepartments = new List<string> { "IT", "HR", "Finance", "Logistics" };
            SubDepartmentComboBox.ItemsSource = subDepartments;
        }

        private void LoadFakeLeaveRequests()
        {
            allRequests = new List<LeaveRequestForReview>
            {
                new LeaveRequestForReview
                {
                    Id = Guid.NewGuid(),
                    EmployeeName = "Ahmed Saleh",
                    Start = new DateOnly(2025, 7, 1),
                    End = new DateOnly(2025, 7, 5),
                    Reason = "Family Emergency",
                   
                    SubDepartment = "IT"
                },
                new LeaveRequestForReview
                {
                    Id = Guid.NewGuid(),
                    EmployeeName = "Fatima Ali",
                    Start = new DateOnly(2025, 7, 10),
                    End = new DateOnly(2025, 7, 12),
                    Reason = "Medical Leave", 
                    SubDepartment = "Finance"
                },
                new LeaveRequestForReview
                {
                    Id = Guid.NewGuid(),
                    EmployeeName = "Yasir Nabil",
                    Start = new DateOnly(2025, 7, 15),
                    End = new DateOnly(2025, 7, 17),
                    Reason = "Personal Trip",
                   
                    SubDepartment = "IT"
                }
               
            };
            EmployeeLeaveRequestsDataGrid.ItemsSource = allRequests; 
        }

        private void GetButton_Click(object sender, RoutedEventArgs e)
        {
           
        }

        private void EmployeeLeaveRequestsDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (EmployeeLeaveRequestsDataGrid.SelectedItem is LeaveRequestForReview selected)
            {
                EmployeeReasonTextbox.Text = selected.Reason;
                ManagerMessageTextbox.Text = selected.DepartmentManagerMessage ?? "";
            }
        }

        private void ApproveButton_Click(object sender, RoutedEventArgs e)
        {
           
        }

        private void RejectButton_Click(object sender, RoutedEventArgs e)
        {
          
        }
    }

    public class LeaveRequestForReview
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
