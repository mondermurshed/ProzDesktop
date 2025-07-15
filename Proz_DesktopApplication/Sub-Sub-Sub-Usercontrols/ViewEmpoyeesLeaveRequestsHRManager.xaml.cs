using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace Proz_DesktopApplication.Sub_Sub_Sub_Usercontrols
{
    public partial class ViewEmpoyeesLeaveRequestsHRManager : UserControl
    {
        private List<string> subDepartments;
        private List<LeaveRequestHRView> allRequests;
        private LeaveRequestHRView selectedRequest;

        public ViewEmpoyeesLeaveRequestsHRManager()
        {
            InitializeComponent();
            LoadSubDepartments();
            LoadFakeData();
            SubDepartmentComboBox.SelectedIndex = 0;
        }

        private void LoadSubDepartments()
        {
            subDepartments = new List<string> { "Old Ones First", "IT", "HR", "Finance", "Logistics" };
            SubDepartmentComboBox.ItemsSource = subDepartments;
        }

        private void LoadFakeData()
        {
            allRequests = new List<LeaveRequestHRView>
            {
                new LeaveRequestHRView
                {
                    Id = Guid.NewGuid(),
                    EmployeeName = "Yasir Nabil",
                    Start = new DateOnly(2025, 7, 10),
                    End = new DateOnly(2025, 7, 12),
                    Reason = "Family illness",
                    DepartmentManagerMessage = "Approved - critical case",
                    SubDepartment = "IT"
                },
                new LeaveRequestHRView
                {
                    Id = Guid.NewGuid(),
                    EmployeeName = "Ahlam Salem",
                    Start = new DateOnly(2025, 7, 5),
                    End = new DateOnly(2025, 7, 8),
                    Reason = "Travel abroad",
                    DepartmentManagerMessage = "Approved - travel documentation provided",
                    SubDepartment = "HR"
                }
            };

            HRLeaveRequestsDataGrid.ItemsSource = allRequests;
        }

        private void GetButton_Click(object sender, RoutedEventArgs e)
        {
            // If you want filtering by subdepartment later, do it here
        }

        private void HRLeaveRequestsDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (HRLeaveRequestsDataGrid.SelectedItem is LeaveRequestHRView selected)
            {
                selectedRequest = selected;
                EmployeeReasonTextbox.Text = selected.Reason;
                DepartmentManagerMessageTextbox.Text = selected.DepartmentManagerMessage;
                HRMessageTextbox.Text = selected.HRMessage;
                NeedesApprovalCheckbox.IsChecked = selected.HasSanctions;
            }
        }

        private void ApproveButton_Click(object sender, RoutedEventArgs e)
        {
            if (selectedRequest != null)
            {
                MessageBox.Show($"Approved request for: {selectedRequest.EmployeeName}\nMessage: {HRMessageTextbox.Text}");
            }
        }

        private void RejectButton_Click(object sender, RoutedEventArgs e)
        {
            if (selectedRequest != null)
            {
                MessageBox.Show($"Rejected request for: {selectedRequest.EmployeeName}\nMessage: {HRMessageTextbox.Text}");
            }
        }
    }

    public class LeaveRequestHRView
    {
        public Guid Id { get; set; }
        public string EmployeeName { get; set; }
        public DateOnly Start { get; set; }
        public DateOnly End { get; set; }
        public string Reason { get; set; }
        public string DepartmentManagerMessage { get; set; }
        public string HRMessage {  get; set; }
        public bool HasSanctions {  get; set; }
        public string SubDepartment { get; set; }
    }
}
