using ModernMessageBoxLib;
using Proz_DesktopApplication.API;
using Proz_DesktopApplication.Sub_Sub_Sub_Usercontrols;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
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
    /// Interaction logic for EmployeesLeaveRequestsHRManager.xaml
    /// </summary>
    public partial class EmployeesLeaveRequestsHRManager : BaseUserControlMain
    {
        public List<ReturnFinishedLeaveRequestsHRResponse> GetCompletedLeaveRequests123 { get; set; } = new();
        public List<ReturnLeaveRequestsResponse> GetLeaveRequests123 { get; set; } = new();
        public HRMAPIEndpointsDefinitions HREndpointsDefinitions;
        public EmployeesLeaveRequestsHRManager()
        {
            InitializeComponent();
            this.Loaded += OnCreatingThisUsercontrol;
        }

        private async void OnCreatingThisUsercontrol(object sender, RoutedEventArgs e)
        {
            HREndpointsDefinitions = _HREndpointsDefinitions1 ?? throw new InvalidOperationException("Services1 is null");
          

        }

        private async void GetLeaveRequests(object sender, RoutedEventArgs e)
        {
            this.IsEnabled = false;
            try
            {


           
                var win = new IndeterminateProgressWindow("Fetching the data...");
                win.Show();
                var response = await HREndpointsDefinitions.GetLeaveRequestsToManage();
                win.Message = "Result is collected..";
                win.Close();


                if (response.IsSuccessStatusCode && response.Content != null && response.Content.Any())
                {
                    GetLeaveRequests123 = response.Content;

                    HRLeaveRequestsDataGrid.ItemsSource = null;
                    HRLeaveRequestsDataGrid.ItemsSource = GetLeaveRequests123;
                    EmployeeReasonTextbox.Clear();
                    HRMessageTextbox.Clear();

                    this.IsEnabled = true;

                }
                else
                {
                    var msgBox2 = new ModernMessageBox($"No data was found or it didn't successfully connect to the server.",
                                                                  "Operation Information",
                                                                  ModernMessageboxIcons.Error,
                                                                  "OK");
                    msgBox2.ShowDialog();
                    HRLeaveRequestsDataGrid.ItemsSource = null;
                    this.IsEnabled = true;
                }

            }
            catch (Exception ex)
            {
                var msgBox2 = new ModernMessageBox($"Didn't successfully connect to the server.",
                                                               "Operation Information",
                                                               ModernMessageboxIcons.Error,
                                                               "OK");
                msgBox2.ShowDialog();
                this.IsEnabled = true;
            }
        }

        private void HRLeaveRequestsDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (HRLeaveRequestsDataGrid.SelectedItem is ReturnLeaveRequestsResponse selected)
            {
            
                EmployeeReasonTextbox.Text = selected.Reason;
            

            }
        }

        private async void ApproveButton_Click(object sender, RoutedEventArgs e)
        {
            if (HRLeaveRequestsDataGrid.SelectedItem is ReturnLeaveRequestsResponse selected)
            {
                var msgBox3 = new ModernMessageBox($"Are you sure that you want to apply this answer ?.",
                                                                 "Operation Information",
                                                                 ModernMessageboxIcons.Info,
                                                                 "Cancel", "Yes");
                msgBox3.ShowDialog();
                if (msgBox3.Result != ModernMessageboxResult.Button2)
                {
                    return;
                }
                this.IsEnabled = false;
                try
                {
                    bool approvalneeded = false;
                    if (NeedesApprovalCheckbox.IsChecked==true)
                    {
                        approvalneeded = true;
                    }
                    else
                    {
                        approvalneeded = false;
                    }

                    var request = new LeaveRequestAcceptRejectHRMRequest
                    {

                        Accept = true,
                        Comment = HRMessageTextbox.Text,
                        LeaveRequestID = selected.LeaveRequestID,
                        MustAgreeOn = approvalneeded

                    };
                    var win = new IndeterminateProgressWindow("Applying your answer...");
                    win.Show();
                    var response = await HREndpointsDefinitions.AnswerLeaveRequest(request);
                    win.Message = "Result is collected..";
                    win.Close();


                    if (response.IsSuccessStatusCode)
                    {
                        var msgBox2 = new ModernMessageBox($"{response.Content.Messagee}.",
                                                                       "Operation Information",
                                                                       ModernMessageboxIcons.Done,
                                                                       "OK!");
                        msgBox2.ShowDialog();

                        this.IsEnabled = true;
                        return;
                    }
                    else
                    {
                        // When server returns 400, Refit puts the error JSON as a string here
                        var rawError = response.Error?.Content;
                        AddAnAnswerForALeaveRequestHRMResponse errorResponse = null;
                        ValidationErrorResponse errorResponse2 = null;
                        if (!string.IsNullOrWhiteSpace(rawError))
                        {

                            try
                            {
                                errorResponse = JsonSerializer.Deserialize<AddAnAnswerForALeaveRequestHRMResponse>(rawError, new JsonSerializerOptions
                                {
                                    PropertyNameCaseInsensitive = true
                                });
                                this.IsEnabled = true;
                                if (errorResponse.Error == null || errorResponse.Error == "")
                                    throw new Exception();
                            }
                            catch
                            {
                                // Fallback to FluentValidation-style error
                                errorResponse2 = JsonSerializer.Deserialize<ValidationErrorResponse>(rawError, new JsonSerializerOptions
                                {
                                    PropertyNameCaseInsensitive = true
                                });

                                // Flatten dictionary errors
                                var flatErrors = errorResponse2.Errors
                                    .SelectMany(kvp => kvp.Value.Select(msg => $"{kvp.Key}: {msg}"));

                                var msgBox1 = new ModernMessageBox($"{errorResponse2.Message}\n\n{string.Join("\n", flatErrors)}",
                                    "Validation Error",
                                   ModernMessageboxIcons.Error,
                                   "OK");
                                msgBox1.ShowDialog();
                                this.IsEnabled = true;
                                return;
                            }

                            //asgsga
                            var msgBox2 = new ModernMessageBox($"{errorResponse.Error}.",
                                                                  "Operation Information",
                                                                  ModernMessageboxIcons.Error,
                                                                  "OK");
                            msgBox2.ShowDialog();

                            this.IsEnabled = true;
                            return;
                        }
                    }
                }
                catch (Exception ex)
                {
                    var msgBox2 = new ModernMessageBox($"Didn't successfully connect to the server.",
                                                                   "Operation Information",
                                                                   ModernMessageboxIcons.Error,
                                                                   "OK");
                    msgBox2.ShowDialog();
                    this.IsEnabled = true;
                }
            }
        }

        private async void RejectButton_Click(object sender, RoutedEventArgs e)
        {
            if (HRLeaveRequestsDataGrid.SelectedItem is ReturnLeaveRequestsResponse selected)
            {
                var msgBox3 = new ModernMessageBox($"Are you sure that you want to apply this answer ?.",
                                                                 "Operation Information",
                                                                 ModernMessageboxIcons.Info,
                                                                 "Cancel", "Yes");
                msgBox3.ShowDialog();
                if (msgBox3.Result != ModernMessageboxResult.Button2)
                {
                    return;
                }
                this.IsEnabled = false;
                try
                {
                 

                    var request = new LeaveRequestAcceptRejectHRMRequest
                    {

                        Accept = false,
                        Comment = HRMessageTextbox.Text,
                        LeaveRequestID = selected.LeaveRequestID,
                        MustAgreeOn = false

                    };
                    var win = new IndeterminateProgressWindow("Applying your answer...");
                    win.Show();
                    var response = await HREndpointsDefinitions.AnswerLeaveRequest(request);
                    win.Message = "Result is collected..";
                    win.Close();


                    if (response.IsSuccessStatusCode)
                    {
                        var msgBox2 = new ModernMessageBox($"{response.Content.Messagee}.",
                                                                       "Operation Information",
                                                                       ModernMessageboxIcons.Done,
                                                                       "OK!");
                        msgBox2.ShowDialog();

                        this.IsEnabled = true;
                        return;
                    }
                    else
                    {
                        // When server returns 400, Refit puts the error JSON as a string here
                        var rawError = response.Error?.Content;
                        AddAnAnswerForALeaveRequestHRMResponse errorResponse = null;
                        ValidationErrorResponse errorResponse2 = null;
                        if (!string.IsNullOrWhiteSpace(rawError))
                        {

                            try
                            {
                                errorResponse = JsonSerializer.Deserialize<AddAnAnswerForALeaveRequestHRMResponse>(rawError, new JsonSerializerOptions
                                {
                                    PropertyNameCaseInsensitive = true
                                });
                                this.IsEnabled = true;
                                if (errorResponse.Error == null || errorResponse.Error == "")
                                    throw new Exception();
                            }
                            catch
                            {
                                // Fallback to FluentValidation-style error
                                errorResponse2 = JsonSerializer.Deserialize<ValidationErrorResponse>(rawError, new JsonSerializerOptions
                                {
                                    PropertyNameCaseInsensitive = true
                                });

                                // Flatten dictionary errors
                                var flatErrors = errorResponse2.Errors
                                    .SelectMany(kvp => kvp.Value.Select(msg => $"{kvp.Key}: {msg}"));

                                var msgBox1 = new ModernMessageBox($"{errorResponse2.Message}\n\n{string.Join("\n", flatErrors)}",
                                    "Validation Error",
                                   ModernMessageboxIcons.Error,
                                   "OK");
                                msgBox1.ShowDialog();
                                this.IsEnabled = true;
                                return;
                            }

                            //asgsga
                            var msgBox2 = new ModernMessageBox($"{errorResponse.Error}.",
                                                                  "Operation Information",
                                                                  ModernMessageboxIcons.Error,
                                                                  "OK");
                            msgBox2.ShowDialog();

                            this.IsEnabled = true;
                            return;
                        }
                    }
                }
                catch (Exception ex)
                {
                    var msgBox2 = new ModernMessageBox($"Didn't successfully connect to the server.",
                                                                   "Operation Information",
                                                                   ModernMessageboxIcons.Error,
                                                                   "OK");
                    msgBox2.ShowDialog();
                    this.IsEnabled = true;
                }
            }
        }

        private async void GetCompletedLeaveRequests(object sender, RoutedEventArgs e)
        {
            this.IsEnabled = false;
            try
            {



                var win = new IndeterminateProgressWindow("Fetching the data...");
                win.Show();
                var response = await HREndpointsDefinitions.GetCompletedEmployeesLeaveRequestsHR();
                win.Message = "Result is collected..";
                win.Close();


                if (response.IsSuccessStatusCode && response.Content != null && response.Content.Any())
                {
                    GetCompletedLeaveRequests123 = response.Content;

                    CompletedRequestsDataGrid.ItemsSource = null;
                    CompletedRequestsDataGrid.ItemsSource = GetCompletedLeaveRequests123;
      

                    this.IsEnabled = true;

                }
                else
                {
                    var msgBox2 = new ModernMessageBox($"No data was found or it didn't successfully connect to the server.",
                                                                  "Operation Information",
                                                                  ModernMessageboxIcons.Error,
                                                                  "OK");
                    msgBox2.ShowDialog();
                    CompletedRequestsDataGrid.ItemsSource = null;
                    this.IsEnabled = true;
                }

            }
            catch (Exception ex)
            {
                var msgBox2 = new ModernMessageBox($"Didn't successfully connect to the server.",
                                                               "Operation Information",
                                                               ModernMessageboxIcons.Error,
                                                               "OK");
                msgBox2.ShowDialog();
                this.IsEnabled = true;
            }
        }

        private void CompletedRequestsDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (CompletedRequestsDataGrid.SelectedItem is ReturnFinishedLeaveRequestsHRResponse selected)
            {
                ReasonTextbox.Text = selected.Reason;
              
                HRFinalMessageTextbox.Text = selected.MyAnswer;
               
            }
        }
    }
}
