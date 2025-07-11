using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
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
                CreatedAt = DateTime.Now,
                Status = "Completed",
                Reason="Reason!!",
                DepartmentManagerStatus="Rejected",
                DepartmentManagerViewer="Ahmed",
                FinalStatus="Padding",
                FinalMessage="FInalMessage!!!!",
                DepartmentManagerMessage="DepartmnemtMessage!!!",
                HRManagerViewer="Khalid",
                HasSanctions=false
            });

            feedbacks.Add(new LeaveRequests
            {
                Id = Guid.NewGuid(),
                Start = new DateOnly(2025, 7, 1),     // Example start date
                End = new DateOnly(2025, 7, 5),       // Example end date
                CreatedAt = DateTime.Now,
                Reason = "Reason!!",
                DepartmentManagerStatus = "Approved",
                DepartmentManagerViewer = "Ahmed",
                FinalStatus = "Approved",
                FinalMessage = "FInalMessage!!!!",
                DepartmentManagerMessage = "DepartmnemtMessage!!!",
                HRManagerViewer = "Khalid",
                HasSanctions = true
            });

            feedbacks.Add(new LeaveRequests
            {
                Id = Guid.NewGuid(),
                Start = new DateOnly(2025, 7, 1),     // Example start date
                End = new DateOnly(2025, 7, 5),       // Example end date
                CreatedAt = DateTime.Now,
                Reason = "Reason!!",
                DepartmentManagerStatus = "Rejected",
                DepartmentManagerViewer = "Ahmed",
                FinalStatus = "Padding",
                FinalMessage = "FInalMessage!!!!",
                DepartmentManagerMessage = "DepartmnemtMessage!!!",
                HRManagerViewer = "Khalid",
                HasSanctions = false
            });
            feedbacks.Add(new LeaveRequests
            {
                Id = Guid.NewGuid(),
                Start = new DateOnly(2025, 7, 2),     // Example start date
                End = new DateOnly(2025, 7, 6),       // Example end date
                CreatedAt = DateTime.Now,
                Reason = "Reason!!",
                DepartmentManagerStatus = "Padding",
                DepartmentManagerViewer = null,
                FinalStatus = null,
                FinalMessage = null,
                DepartmentManagerMessage = null,
                HRManagerViewer = null,
                HasSanctions = false,

            });
            feedbacks.Add(new LeaveRequests
            {
                Id = Guid.NewGuid(),
                Start = new DateOnly(2025, 7, 8),     // Example start date
                End = new DateOnly(2025, 7, 10),       // Example end date
                CreatedAt = DateTime.Now,
                Reason = "Reason!!",
                DepartmentManagerStatus = "Rejected",
                DepartmentManagerViewer = "Ahmed",
                FinalStatus = null,
                FinalMessage = null,
                DepartmentManagerMessage = "DepartmnemtMessage!!!",
                HRManagerViewer = null,
                HasSanctions = false
            });
            feedbacks.Add(new LeaveRequests
            {
                Id = Guid.NewGuid(),
                Start = new DateOnly(2025, 7, 9),     // Example start date
                End = new DateOnly(2025, 7, 10),       // Example end date
                CreatedAt = DateTime.Now,
                Reason = "Reason!!",
                DepartmentManagerStatus = "Approved",
                DepartmentManagerViewer = "Ahmed",
                FinalStatus = "Padding",
                FinalMessage = null,
                DepartmentManagerMessage = "DepartmnemtMessage!!!",
                HRManagerViewer = null,
                HasSanctions = false
            });
            feedbacks.Add(new LeaveRequests
            {
                Id = Guid.NewGuid(),
                Start = new DateOnly(2025, 7, 2),     // Example start date
                End = new DateOnly(2025, 7, 4),       // Example end date
                CreatedAt = DateTime.Now,
                Reason = "Reason!!",
                DepartmentManagerStatus = "Approved",
                DepartmentManagerViewer = "Ahmed",
                FinalStatus = "Rejected",
                FinalMessage = "FInalMessage!!!!",
                DepartmentManagerMessage = "DepartmnemtMessage!!!",
                HRManagerViewer = "Khalid",
                HasSanctions = false
            });
            feedbacks.Add(new LeaveRequests
            {
                Id = Guid.NewGuid(),
                Start = new DateOnly(2025, 7, 5),     // Example start date
                End = new DateOnly(2025, 7, 7),       // Example end date
                CreatedAt = DateTime.Now,
                Reason = "Reason!!",
                DepartmentManagerStatus = "Approved",
                DepartmentManagerViewer = "Ahmed",
                FinalStatus = "Approved",
                FinalMessage = "FInalMessage!!!!",
                DepartmentManagerMessage = "DepartmnemtMessage!!!",
                HRManagerViewer = "Khalid",
                HasSanctions = true
            });
           
            // Assign to the DataGrid
            LeaveRequestsDatagrid.ItemsSource = feedbacks;
        }

        private void LeaveRequestsDatagrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
         
            if (LeaveRequestsDatagrid.SelectedItem is LeaveRequests selected)
            {
                if(selected.Completed==false || selected.Status=="Pending")
                DeleteButton.IsEnabled = true;
                else
                DeleteButton.IsEnabled = true;


                ReasonTextbox.Text = selected.Reason;
            if (selected.DepartmentManagerStatus!="Pending" && selected.DepartmentManagerStatus != null)
                {
                    ClearButton.IsEnabled = true;
                    DepartmentManagerMessageTextbox.Text = selected.DepartmentManagerMessage;
                    DepartmentManagerNameTextbox.Text = selected.DepartmentManagerViewer;
                    if(selected.FinalStatus!="Pending" && selected.FinalStatus != null)
                    {
                        SendFinalResult.IsEnabled = true;
                        FinalMessageTextbox.Text = selected.FinalMessage;
                        HRManagerNameTextbox.Text = selected.HRManagerViewer;
                        if(selected.HasSanctions==true)
                        {
                        Toggle.Visibility=Visibility.Visible;

                        }
                        else
                        {
                            Toggle.Visibility = Visibility.Collapsed;
                        }
                    }
                    else
                    {
                        SendFinalResult.IsEnabled = false;
                    }
                }
            else
                {
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
            DepartmentManagerMessageTextbox.Clear();
            FinalMessageTextbox.Clear();
            DepartmentManagerNameTextbox.Clear();
            HRManagerNameTextbox.Clear();
            Toggle.Visibility = Visibility.Collapsed;
            SendFinalResult.IsEnabled=false;
            ClearButton.IsEnabled=false;
        }
    }


    public class LeaveRequests
    {
        public Guid Id { get; set; } // Real ID (GUID), not shown in UI
        public DateOnly Start { get; set; } //a
        public DateOnly End { get; set; } //a
        public DateTime CreatedAt { get; set; } //a
        public string Reason { get; set; }
        public string Status {  get; set; } //a
        public string DepartmentManagerStatus {  get; set; } //a
        public string DepartmentManagerMessage {  get; set; }
        public string FinalStatus {  get; set; } //a
        public string FinalMessage {  get; set; }
        public bool HasSanctions {  get; set; }
        public string DepartmentManagerViewer {  get; set; }
        public string HRManagerViewer {  get; set; }

        public bool Completed {  get; set; }

    }
}
