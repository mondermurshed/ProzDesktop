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
    /// Interaction logic for ManageMyLeaveReqests.xaml
    /// </summary>
    public partial class ManageMyLeaveReqests : UserControl
    {
        public ManageMyLeaveReqests()
        {
            InitializeComponent();
            LoadFakeData();
        }
      

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
          

        }

        private void LoadFakeData()
        {
            var feedbacks = new List<LeaveRequests>();

            // Create 3 fake rows with auto-increment ID
            feedbacks.Add(new LeaveRequests
            {
                Id = Guid.NewGuid(),
                Start = new DateOnly(2025, 7, 1),     // Example start date
                End = new DateOnly(2025, 7, 5),       // Example end date
                CreatedAt = DateTime.Now
            });

            feedbacks.Add(new LeaveRequests
            {
                Id = Guid.NewGuid(),
                Start = new DateOnly(2025, 7, 1),     // Example start date
                End = new DateOnly(2025, 7, 5),       // Example end date
                CreatedAt = DateTime.Now
            });

            feedbacks.Add(new LeaveRequests
            {
                Id = Guid.NewGuid(),
                Start = new DateOnly(2025, 7, 1),     // Example start date
                End = new DateOnly(2025, 7, 5),       // Example end date
                CreatedAt = DateTime.Now
            });
            feedbacks.Add(new LeaveRequests
            {
                Id = Guid.NewGuid(),
                Start = new DateOnly(2025, 7, 2),     // Example start date
                End = new DateOnly(2025, 7, 6),       // Example end date
                CreatedAt = DateTime.Now
            });
            feedbacks.Add(new LeaveRequests
            {
                Id = Guid.NewGuid(),
                Start = new DateOnly(2025, 7, 8),     // Example start date
                End = new DateOnly(2025, 7, 10),       // Example end date
                CreatedAt = DateTime.Now
            });
            feedbacks.Add(new LeaveRequests
            {
                Id = Guid.NewGuid(),
                Start = new DateOnly(2025, 7, 9),     // Example start date
                End = new DateOnly(2025, 7, 10),       // Example end date
                CreatedAt = DateTime.Now
            });
            feedbacks.Add(new LeaveRequests
            {
                Id = Guid.NewGuid(),
                Start = new DateOnly(2025, 7, 2),     // Example start date
                End = new DateOnly(2025, 7, 4),       // Example end date
                CreatedAt = DateTime.Now
            });
            feedbacks.Add(new LeaveRequests
            {
                Id = Guid.NewGuid(),
                Start = new DateOnly(2025, 7, 5),     // Example start date
                End = new DateOnly(2025, 7, 7),       // Example end date
                CreatedAt = DateTime.Now
            });
            feedbacks.Add(new LeaveRequests
            {
                Id = Guid.NewGuid(),
                Start = new DateOnly(2025, 7, 1),     // Example start date
                End = new DateOnly(2025, 7, 4),       // Example end date
                CreatedAt = DateTime.Now
            });
            feedbacks.Add(new LeaveRequests
            {
                Id = Guid.NewGuid(),
                Start = new DateOnly(2025, 7, 2),     // Example start date
                End = new DateOnly(2025, 7, 10),       // Example end date
                CreatedAt = DateTime.Now
            });
            feedbacks.Add(new LeaveRequests
            {
                Id = Guid.NewGuid(),
                Start = new DateOnly(2025, 6, 25),     // Example start date
                End = new DateOnly(2025, 7, 5),       // Example end date
                CreatedAt = DateTime.Now
            });
            feedbacks.Add(new LeaveRequests
            {
                Id = Guid.NewGuid(),
                Start = new DateOnly(2025, 7, 1),     // Example start date
                End = new DateOnly(2025, 7, 5),       // Example end date
                CreatedAt = DateTime.Now

            });
            // Assign to the DataGrid
            LeaveRequestsDatagrid.ItemsSource = feedbacks;
        }

        private void LeaveRequestsDatagrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void FromDatePicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
     
        }
    }


    public class LeaveRequests
    {
        public Guid Id { get; set; } // Real ID (GUID), not shown in UI
        public DateOnly Start { get; set; }
        public DateOnly End { get; set; }
        public DateTime CreatedAt { get; set; }
     
    }
}
