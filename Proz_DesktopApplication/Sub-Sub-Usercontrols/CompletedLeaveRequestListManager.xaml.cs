using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Proz_DesktopApplication.Sub_Sub_Usercontrols
{
    /// <summary>
    /// Interaction logic for CompletedLeaveRequestListManager.xaml
    /// </summary>
    public partial class CompletedLeaveRequestListManager : UserControl
    {
        public CompletedLeaveRequestListManager()
        {
            InitializeComponent();
            LoadCompletedRequests();
        }
        private void LoadCompletedRequests()
        {
            var completedRequests = new List<LeaveRequestsCompletedManager>
            {
                new LeaveRequestsCompletedManager
                {
                    Start = new DateOnly(2025, 7, 1),
                    End = new DateOnly(2025, 7, 5),
                    Reason = "Medical leave",
                   
                    HRMessage = "Approved by HR",
                 
                    HRViewer = "Khalid"
                },
                new LeaveRequestsCompletedManager
                {
                    Start = new DateOnly(2025, 7, 10),
                    End = new DateOnly(2025, 7, 12),
                    Reason = "Family emergency",
                  
                    HRMessage = "HR agreed with department manager",
                  
                    HRViewer = "Khalid"
                }
            };

            CompletedRequestsDatagrid.ItemsSource = completedRequests;
        }

        private void CompletedRequestsDatagrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (CompletedRequestsDatagrid.SelectedItem is LeaveRequestsCompletedManager selected)
            {
                ReasonTextbox.Text = selected.Reason;
                HRManagerMessageTextbox.Text = selected.HRMessage;
            }
        }

    }

    public class LeaveRequestsCompletedManager
    {
        public DateOnly Start { get; set; }
        public DateOnly End { get; set; }
        public string Reason { get; set; }
        public string HRMessage { get; set; }
        public string HRViewer { get; set; }
    }
}
