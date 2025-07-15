using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Proz_DesktopApplication.Sub_Sub_Sub_Usercontrols
{
    public partial class AnsweredDepartmentManagersLeaveRequestsByTheHRManager : UserControl
    {
        private List<string> subDepartments;
        private List<CompletedManagerLeaveRequest> allRequests;
        private List<CompletedManagerLeaveRequest> filteredRequests;

        public AnsweredDepartmentManagersLeaveRequestsByTheHRManager()
        {
            InitializeComponent();
         
            LoadFakeCompletedManagerRequests();
            
           
        }

     

        private void LoadFakeCompletedManagerRequests()
        {
            allRequests = new List<CompletedManagerLeaveRequest>
            {
                new CompletedManagerLeaveRequest
                {
                    Id = Guid.NewGuid(),
                    ManagerName = "Hussein Omar",
                    Start = new DateOnly(2025, 6, 3),
                    End = new DateOnly(2025, 6, 7),
                    Reason = "Medical treatment",
                    HRManagerMessage = "Approved after document review.",
                    HasSanctions = false,
                },
                new CompletedManagerLeaveRequest
                {
                    Id = Guid.NewGuid(),
                    ManagerName = "Sana Ahmed",
                    Start = new DateOnly(2025, 6, 10),
                    End = new DateOnly(2025, 6, 12),
                    Reason = "Family wedding",
                    
                    HRManagerMessage = "Declined due to staff shortage.",
                    HasSanctions = true,
                }
            };
        }

       

        

        private void CompletedRequestsDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (CompletedRequestsDataGrid.SelectedItem is CompletedManagerLeaveRequest selected)
            {
                ReasonTextbox.Text = selected.Reason;
                HRFinalMessageTextbox.Text = selected.HRManagerMessage;
                NeededApprovalCheckbox.IsChecked = selected.HasSanctions;
            }
        }
    }

    public class CompletedManagerLeaveRequest
    {
        public Guid Id { get; set; }
        public string ManagerName { get; set; }
        public DateOnly Start { get; set; }
        public DateOnly End { get; set; }
        public string Reason { get; set; }
        public string HRManagerMessage { get; set; }
        public bool HasSanctions {  get; set; }
    }
}
