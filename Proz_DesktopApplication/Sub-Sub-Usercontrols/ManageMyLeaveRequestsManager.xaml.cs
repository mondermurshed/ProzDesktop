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
    /// Interaction logic for ManageMyLeaveRequestsManager.xaml
    /// </summary>
    public partial class ManageMyLeaveRequestsManager : UserControl
    {
        public ManageMyLeaveRequestsManager()
        {
            InitializeComponent();
            LoadFakeData();
        }


        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {


        }

        private void LoadFakeData()
        {
            var LeaveRequests = new List<LeaveRequestsHigherRole>();

            // Create 3 fake rows with auto-increment ID
            LeaveRequests.Add(new LeaveRequestsHigherRole
            {
                Id = Guid.NewGuid(),
                Start = new DateOnly(2025, 7, 1),     // Example start date
                End = new DateOnly(2025, 7, 5),       // Example end date
                CreatedAt = DateTime.Now,
                Status = "Completed",
                Reason = "Reason!!",
               
                HRManagerStatus = "Padding",
                HRManagerMessage = "FInalMessage!!!!",
              
                HRManagerViewer = "Khalid",
                HasSanctions = false
            });

            LeaveRequests.Add(new LeaveRequestsHigherRole
            {
                Id = Guid.NewGuid(),
                Start = new DateOnly(2025, 7, 1),     // Example start date
                End = new DateOnly(2025, 7, 5),       // Example end date
                CreatedAt = DateTime.Now,
                Status = "Completed",
                Reason = "Reason!!",

                HRManagerStatus = "Accepted",
                HRManagerMessage = "FInalMessage!!!!!!",

                HRManagerViewer = "Khalid",
                HasSanctions = true
            });

            LeaveRequests.Add(new LeaveRequestsHigherRole
            {
                Id = Guid.NewGuid(),
                Start = new DateOnly(2025, 7, 1),     // Example start date
                End = new DateOnly(2025, 7, 5),       // Example end date
                CreatedAt = DateTime.Now,
                Status = "Completed",
                Reason = "Reason!!",

                HRManagerStatus = "Accepted",
                HRManagerMessage = "FInalMessage!!!!",

                HRManagerViewer = "Khalid",
                HasSanctions = false
            });
            LeaveRequests.Add(new LeaveRequestsHigherRole
            {
                Id = Guid.NewGuid(),
                Start = new DateOnly(2025, 7, 1),     // Example start date
                End = new DateOnly(2025, 7, 5),       // Example end date
                CreatedAt = DateTime.Now,
                Status = "Completed",
                Reason = "Reason!!",

                HRManagerStatus = "Rejected",
                HRManagerMessage = "FInalMessage!!!!",

                HRManagerViewer = "Khalid",
                HasSanctions = false

            });
            LeaveRequests.Add(new LeaveRequestsHigherRole
            {
                Id = Guid.NewGuid(),
                Start = new DateOnly(2025, 7, 1),     // Example start date
                End = new DateOnly(2025, 7, 5),       // Example end date
                CreatedAt = DateTime.Now,
                Status = "Completed",
                Reason = "Reason!!",

                HRManagerStatus = "Padding",
                HRManagerMessage = "FInalMessage!!!!",

                HRManagerViewer = "Khalid",
                HasSanctions = false
            });
           
            // Assign to the DataGrid
            LeaveRequestsDatagrid.ItemsSource = LeaveRequests;
        }

        private void LeaveRequestsDatagrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            if (LeaveRequestsDatagrid.SelectedItem is LeaveRequestsHigherRole selected)
            {
                if (selected.Completed == false || selected.Status == "Pending")
                    DeleteButton.IsEnabled = true;
                else
                    DeleteButton.IsEnabled = true;


                ReasonTextbox.Text = selected.Reason;

                    if (selected.HRManagerStatus != "Pending" && selected.HRManagerStatus != null)
                    {
                          ClearButton.IsEnabled = true;
                        SendFinalResult.IsEnabled = true;
                        HRManagerMessageTextbox.Text = selected.HRManagerMessage;
                        HRManagerNameTextbox.Text = selected.HRManagerViewer;
                        if (selected.HasSanctions == true)
                        {
                            Toggle.Visibility = Visibility.Visible;

                        }
                        else
                        {
                            Toggle.Visibility = Visibility.Collapsed;
                        }
                    }
                    else
                    {
                        SendFinalResult.IsEnabled = false;
                        ClearButton.IsEnabled = false;
                }
                
              
            }
        }
        private void FromDatePicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void SendFinalResult_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ReasonTextbox.Clear();
          
            HRManagerMessageTextbox.Clear();

            HRManagerNameTextbox.Clear();
            Toggle.Visibility = Visibility.Collapsed;
            SendFinalResult.IsEnabled = false;
            ClearButton.IsEnabled = false;
        }

    }


    public class LeaveRequestsHigherRole
    {
        public Guid Id { get; set; } // Real ID (GUID), not shown in UI
        public DateOnly Start { get; set; } //a
        public DateOnly End { get; set; } //a
        public DateTime CreatedAt { get; set; } //a
        public string Reason { get; set; }
        public string Status { get; set; } //a
        public string HRManagerStatus { get; set; } //a
        public string HRManagerMessage { get; set; }
        public bool HasSanctions { get; set; }
        public string HRManagerViewer { get; set; }

        public bool Completed { get; set; }

    }
}
