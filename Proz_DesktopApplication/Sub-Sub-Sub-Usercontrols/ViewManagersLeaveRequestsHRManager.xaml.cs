using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace Proz_DesktopApplication.Sub_Sub_Sub_Usercontrols
{
    public partial class ViewManagersLeaveRequestsHRManager : UserControl
    {
        private List<ManagerLeaveRequestReview> pendingRequests;
        private ManagerLeaveRequestReview selectedRequest;

        public ViewManagersLeaveRequestsHRManager()
        {
            InitializeComponent();
            LoadFakeManagerLeaveRequests();
        }

        private void LoadFakeManagerLeaveRequests()
        {
            pendingRequests = new List<ManagerLeaveRequestReview>
            {
                new ManagerLeaveRequestReview
                {
                    Id = Guid.NewGuid(),
                    ManagerName = "Kareem Al-Najjar",
                    Start = new DateOnly(2025, 7, 5),
                    End = new DateOnly(2025, 7, 8),
                    Reason = "Personal travel"
                },
                new ManagerLeaveRequestReview
                {
                    Id = Guid.NewGuid(),
                    ManagerName = "Laila Mohammed",
                    Start = new DateOnly(2025, 7, 15),
                    End = new DateOnly(2025, 7, 17),
                    Reason = "Medical emergency"
                }
            };

            ManagersRequestsDataGrid.ItemsSource = pendingRequests;
        }

        private void ManagersRequestsDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ManagersRequestsDataGrid.SelectedItem is ManagerLeaveRequestReview selected)
            {
                selectedRequest = selected;
                ReasonTextbox.Text = selected.Reason;
                HRMessageTextbox.Text = selected.HRMessage;
                HRMessageTextbox.Text = string.Empty;
                NeedsApprovalCheckbox.IsChecked = selected.HasSanctions;
            }
        }

        private void ApproveButton_Click(object sender, RoutedEventArgs e)
        {
            if (selectedRequest != null)
            {
                MessageBox.Show($"Approved request from: {selectedRequest.ManagerName}\nHR Message: {HRMessageTextbox.Text}");
                HRMessageTextbox.Clear();
            }
        }

        private void RejectButton_Click(object sender, RoutedEventArgs e)
        {
            if (selectedRequest != null)
            {
                MessageBox.Show($"Rejected request from: {selectedRequest.ManagerName}\nHR Message: {HRMessageTextbox.Text}");
                HRMessageTextbox.Clear();
            }
        }
    }

    public class ManagerLeaveRequestReview
    {
        public Guid Id { get; set; }
        public string ManagerName { get; set; }
        public DateOnly Start { get; set; }
        public DateOnly End { get; set; }
        public string Reason { get; set; }
        public string HRMessage { get; set; }
        public bool HasSanctions { get; set; }
    }
}
