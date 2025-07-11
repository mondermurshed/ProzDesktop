using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace Proz_DesktopApplication.Sub_Sub_Usercontrols
{
    public partial class CompletedLeaveRequestList : UserControl
    {
        public CompletedLeaveRequestList()
        {
            InitializeComponent();
            LoadCompletedRequests();
        }

        private void LoadCompletedRequests()
        {
            var completedRequests = new List<LeaveRequestsCompleted>
            {
                new LeaveRequestsCompleted
                {
                    Start = new DateOnly(2025, 7, 1),
                    End = new DateOnly(2025, 7, 5),
                    Reason = "Medical leave",
                    DepartmentManagerMessage = "Approved - valid documents provided.",
                    FinalMessage = "Approved by HR",
                    DepartmentManagerViewer = "Ahmed",
                    HRManagerViewer = "Khalid"
                },
                new LeaveRequestsCompleted
                {
                    Start = new DateOnly(2025, 7, 10),
                    End = new DateOnly(2025, 7, 12),
                    Reason = "Family emergency",
                    DepartmentManagerMessage = "Rejected due to lack of notice.",
                    FinalMessage = "HR agreed with department manager",
                    DepartmentManagerViewer = "Ahmed",
                    HRManagerViewer = "Khalid"
                }
            };

            CompletedRequestsDatagrid.ItemsSource = completedRequests;
        }

        private void CompletedRequestsDatagrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (CompletedRequestsDatagrid.SelectedItem is LeaveRequestsCompleted selected)
            {
                ReasonTextbox.Text = selected.Reason;
                DepartmentManagerMessageTextbox.Text = selected.DepartmentManagerMessage;
                FinalMessageTextbox.Text = selected.FinalMessage;
            }
        }
    }

    public class LeaveRequestsCompleted
    {
        public DateOnly Start { get; set; }
        public DateOnly End { get; set; }
        public string Reason { get; set; }
        public string DepartmentManagerMessage { get; set; }
        public string FinalMessage { get; set; }
        public string DepartmentManagerViewer { get; set; }
        public string HRManagerViewer { get; set; }
    }
}
