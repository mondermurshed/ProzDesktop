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
    /// Interaction logic for EmployeesLeaveRequestsManager.xaml
    /// </summary>
    public partial class EmployeesLeaveRequestsManager : BaseUserControlMain
    {

        public List<ReturnFinishedLeaveRequestsResponse> GetCompletedLeaveRequests123 { get; set; } = new();
        public List<ReturnMyEmployeesLeaveRequests> GetLeaveRequests123 { get; set; } = new();
        public List<ReturnAllDepartments> GetDepartments { get; set; } = new();
        public DMAPIEndpointsDefinitions DBAPIEndpointsDefinitions;
        bool isloaded = false;
        public EmployeesLeaveRequestsManager()
        {
            InitializeComponent();
            Loaded += OnCreatingThisUsercontrol;
        }
        private async void OnCreatingThisUsercontrol(object sender, RoutedEventArgs e)
        {
            DBAPIEndpointsDefinitions = _DMAPIEndpointsDefinitions1 ?? throw new InvalidOperationException("Services1 is null");
            GotFocus += UserControl_GotFocus;

        }

        private async void UserControl_GotFocus(object sender, RoutedEventArgs e)
        {

            if (isloaded == true)
                return;
            isloaded = true;

            this.IsEnabled = false;
            try
            {



                var win = new IndeterminateProgressWindow("Loading Some important data, please wait...");
                win.Show();
                var response = await DBAPIEndpointsDefinitions.GetMyDepartments();
                win.Message = "Result is collected..";
                win.Close();


                if (response.IsSuccessStatusCode && response.Content != null && response.Content.Any())
                {
                    GetDepartments = response.Content;

                    SubDepartmentComboBox.ItemsSource = null;
                    SubDepartmentComboBox.ItemsSource = GetDepartments;
                    SubDepartmentComboBoxtab2.ItemsSource = null;
                    SubDepartmentComboBoxtab2.ItemsSource = GetDepartments;

                    SubDepartmentComboBox.DisplayMemberPath = "DepartmentName";
                    SubDepartmentComboBox.SelectedValuePath = "DepartmentID";
                    SubDepartmentComboBoxtab2.DisplayMemberPath = "DepartmentName";
                    SubDepartmentComboBoxtab2.SelectedValuePath = "DepartmentID";

                    this.IsEnabled = true;

                }
                else
                {
                    var msgBox2 = new ModernMessageBox($"No assigned departments were found inside the system for you or it didn't successfully connect to the server.",
                                                                  "Operation Information",
                                                                  ModernMessageboxIcons.Error,
                                                                  "OK");
                    msgBox2.ShowDialog();
                    SubDepartmentComboBox.ItemsSource = null;
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

        private async void GetButton_Click(object sender, RoutedEventArgs e)
        {

            if (SubDepartmentComboBox.SelectedItem == null)
            {
                var msgBox2 = new ModernMessageBox($"Please select a sub department to fetch the leave requests from.",
                                                                                "Operation Information",
                                                                                ModernMessageboxIcons.Error,
                                                                                "OK");
                msgBox2.ShowDialog();
                return;
            }

            this.IsEnabled = false;
            try
            {


                var request = new ReturnMyEmployeesLeaveRequests_Request_
                {
                    Department = (Guid)SubDepartmentComboBox.SelectedValue
                };
                var win = new IndeterminateProgressWindow("Fetching the data...");
                win.Show();
                var response = await DBAPIEndpointsDefinitions.GetEmployeesLeaveRequests(request);
                win.Message = "Result is collected..";
                win.Close();


                if (response.IsSuccessStatusCode && response.Content != null && response.Content.Any())
                {
                    GetLeaveRequests123 = response.Content;

                    EmployeeLeaveRequestsDataGrid.ItemsSource = null;
                    EmployeeLeaveRequestsDataGrid.ItemsSource = GetLeaveRequests123;

                    this.IsEnabled = true;

                }
                else
                {
                    var msgBox2 = new ModernMessageBox($"No data was found or it didn't successfully connect to the server.",
                                                                  "Operation Information",
                                                                  ModernMessageboxIcons.Error,
                                                                  "OK");
                    msgBox2.ShowDialog();
                    EmployeeLeaveRequestsDataGrid.ItemsSource = null;
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

        private void EmployeeLeaveRequestsDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (EmployeeLeaveRequestsDataGrid.SelectedItem is ReturnMyEmployeesLeaveRequests selected)
            {
                EmployeeReasonTextbox.Text = selected.Reason;
             
            
            }
        }

        private async void ApproveButton_Click(object sender, RoutedEventArgs e)
        {

            if (EmployeeLeaveRequestsDataGrid.SelectedItem is ReturnMyEmployeesLeaveRequests selected)
            {
                var msgBox3 = new ModernMessageBox($"Are you sure that you want to apply this answer ?.",
                                                                 "Operation Information",
                                                                 ModernMessageboxIcons.Info,
                                                                 "Cancel", "Yes");
                msgBox3.ShowDialog();
                if(msgBox3.Result != ModernMessageboxResult.Button2)
                {
                    return;
                }
                this.IsEnabled = false;
                try
                {


                    var request = new LeaveRequestAcceptRejectRequest
                    {
                        Accept = true,
                        Comment = EmployeeReasonTextbox.Text,
                        LeaveRequestID = selected.LeaveRequestID
                     
                    };
                    var win = new IndeterminateProgressWindow("Applying your answer...");
                    win.Show();
                    var response = await DBAPIEndpointsDefinitions.AddLeaveRequestAnswer(request);
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
                        AddAnAnswerForALeaveRequestResponse errorResponse = null;
                        ValidationErrorResponse errorResponse2 = null;
                        if (!string.IsNullOrWhiteSpace(rawError))
                        {

                            try
                            {
                                errorResponse = JsonSerializer.Deserialize<AddAnAnswerForALeaveRequestResponse>(rawError, new JsonSerializerOptions
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


            if (EmployeeLeaveRequestsDataGrid.SelectedItem is ReturnMyEmployeesLeaveRequests selected)
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


                    var request = new LeaveRequestAcceptRejectRequest
                    {
                        Accept = false,
                        Comment = EmployeeReasonTextbox.Text,
                        LeaveRequestID = selected.LeaveRequestID

                    };
                    var win = new IndeterminateProgressWindow("Applying your answer...");
                    win.Show();
                    var response = await DBAPIEndpointsDefinitions.AddLeaveRequestAnswer(request);
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
                        AddAnAnswerForALeaveRequestResponse errorResponse = null;
                        ValidationErrorResponse errorResponse2 = null;
                        if (!string.IsNullOrWhiteSpace(rawError))
                        {

                            try
                            {
                                errorResponse = JsonSerializer.Deserialize<AddAnAnswerForALeaveRequestResponse>(rawError, new JsonSerializerOptions
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

        private async void GetCompletedLeaveRequestsButton_Click(object sender, RoutedEventArgs e)
        {
            if (SubDepartmentComboBoxtab2.SelectedItem == null)
            {
                var msgBox2 = new ModernMessageBox($"Please select a sub department to fetch the leave requests from.",
                                                                                "Operation Information",
                                                                                ModernMessageboxIcons.Error,
                                                                                "OK");
                msgBox2.ShowDialog();
                return;
            }

            this.IsEnabled = false;
            try
            {


                var request = new ReturnFinishedLeaveRequestsRequest
                {
                    Department = (Guid)SubDepartmentComboBoxtab2.SelectedValue
                };
                var win = new IndeterminateProgressWindow("Fetching the data...");
                win.Show();
                var response = await DBAPIEndpointsDefinitions.GetCompletedEmployeesLeaveRequests(request);
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
            if (CompletedRequestsDataGrid.SelectedItem is ReturnFinishedLeaveRequestsResponse selected)
            {
                EmployeeMessageTextboxCompleted.Text = selected.Reason;
                ManagerMessageTextboxCompleted.Text = selected.MyAnswer;

            }
        }
    }
}
