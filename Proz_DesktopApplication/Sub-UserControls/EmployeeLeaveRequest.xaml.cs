using ModernMessageBoxLib;
using Proz_DesktopApplication.API;
using Proz_DesktopApplication.Sub_Sub_Usercontrols;
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

namespace Proz_DesktopApplication.Sub_UserControls
{
    /// <summary>
    /// Interaction logic for EmployeeLeaveRequest.xaml
    /// </summary>
    public partial class EmployeeLeaveRequest : BaseUserControlMain
    {
        public List<ReturnLeaveRequestsInformation> GetmyLeaveRequests { get; set; } = new();
        public EmployeeAPIEndpointsDefinitions employeeAPIEndpointsDefinitions;
        public EmployeeLeaveRequest()
        {
            InitializeComponent();
            Loaded += UserControl_Loaded;
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            //string formatted = FromDatePicker.SelectedDate.Value.ToString("yyyy-MM-dd");
            employeeAPIEndpointsDefinitions = _EmployeeAPIEndpointsDefinitions1 ?? throw new InvalidOperationException("Services1 is null");
            TillDatePicker.IsEnabled = false;
            FromDatePicker.DisplayDateStart = DateTime.Today.AddDays(1);
            FromDatePicker.DisplayDateEnd = DateTime.Today.AddDays(30);

        }
        private void FromDatePicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            TillDatePicker.Text = "";
            if (FromDatePicker.SelectedDate != null)
            {
                TillDatePicker.IsEnabled = true;
                DateTime fromDate = FromDatePicker.SelectedDate.Value;
                TillDatePicker.DisplayDateStart = fromDate;
                TillDatePicker.DisplayDateEnd = fromDate.AddDays(30);
            }
            else
            {
                TillDatePicker.IsEnabled = false;
            }
        }

        private async void CreateANLeaveRequest(object sender, RoutedEventArgs e)
        {
            if (FromDatePicker.SelectedDate == null || TillDatePicker.SelectedDate == null)
            {
                var msgBox1 = new ModernMessageBox("Please fill your dates fields.",
                                                     "Operation Information",
                                                     ModernMessageboxIcons.Error,
                                                     "OK");
                msgBox1.ShowDialog();
                return;
            }
            this.IsEnabled = false;
            try
            {


                var request = new CreateANewLeaveRequest_Request()
                {
                    FromDATE = FromDatePicker.SelectedDate.Value.ToString("yyyy-MM-dd"),
                    ToDATE = TillDatePicker.SelectedDate.Value.ToString("yyyy-MM-dd"),
                    Reason = ReasonTextBox.Text.Trim()
                };
                var win = new IndeterminateProgressWindow("Sending your request, please wait...");
                win.Show();
                var response = await employeeAPIEndpointsDefinitions.RequestANewLeaveRequestRequest(request);
                win.Message = "Result is collected..";
                win.Close();


                if (response.IsSuccessStatusCode && response.Content != null)
                {

                    var msgBox2 = new ModernMessageBox($"{response.Content.Message}.",
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
                    CreateANewLeaveRequest_Response_ errorResponse = null;
                    ValidationErrorResponse errorResponse2 = null;
                    if (!string.IsNullOrWhiteSpace(rawError))
                    {

                        try
                        {
                            errorResponse = JsonSerializer.Deserialize<CreateANewLeaveRequest_Response_>(rawError, new JsonSerializerOptions
                            {
                                PropertyNameCaseInsensitive = true
                            });
                            this.IsEnabled = true;
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



                        if (errorResponse?.Errors != null && errorResponse?.Errors != "")
                        {
                            var msgBox1 = new ModernMessageBox($"Error :{errorResponse.Errors}",
                                     "Operation Information",
                                     ModernMessageboxIcons.Error,
                                     "OK");
                            msgBox1.ShowDialog();
                            this.IsEnabled = true;
                            return;
                        }

                        else
                        {

                            throw new Exception();


                        }

                    }
                    else
                    {
                        throw new Exception();
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
                return;
            }


        }

        private void LeaveRequestsDatagrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            if (LeaveRequestsDatagrid.SelectedItem is ReturnLeaveRequestsInformation selected)
            {
                MyAgreementCheckbox.Visibility = Visibility.Collapsed;
                SendFinalResult.Visibility = Visibility.Collapsed;
                SendFinalResult.IsEnabled = false;
              
                ReasonTextbox.Text = selected.Reason;
                DepartmentManagerMessageTextbox.Text = selected.DepartmentManagerComment;
                FinalMessageTextbox.Text = selected.FinalStatusComment;
                DepartmentManagerAnsweredAtTextbox.Text = selected.DMAnsweredAtLocal;
                DepartmentManagerAnsweredByTextbox.Text = selected.DMName;
                HRManagerAnsweredAtTextbox.Text = selected.HRMAnsweredAtLocal;
                HRManagerAnsweredByTextbox.Text = selected.HRMName;

                if (selected.Completed == true)
                    return;

                if (selected.Completed == false && selected.HasSanctions == true)
                {
                    MyAgreementCheckbox.Visibility = Visibility.Visible;
                    SendFinalResult.Visibility = Visibility.Visible;
                    SendFinalResult.IsEnabled = true;


                }


            }
        }
        //private void FromDatePicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        //{

        //}

        private async void SendFinalResult_Click(object sender, RoutedEventArgs e)
        {
            if (LeaveRequestsDatagrid.SelectedItems.Count != 1)
            {
                var msgBox2 = new ModernMessageBox($"Please select a Leave request.",
                                                                               "Operation Information",
                                                                               ModernMessageboxIcons.Error,
                                                                               "OK");
                msgBox2.ShowDialog();

                this.IsEnabled = true;
                return;
            }
            bool agreed = false;
            if (MyAgreementCheckbox.IsChecked == true)
                agreed = true;
            if(agreed==false)
            {
                var msgBox2 = new ModernMessageBox($"Are you sure that you want to set your answer as 'i don't agree about these sanctions' ? This will reject your leave request.",
                                               "Operation Information",
                                               ModernMessageboxIcons.Error,
                                               "No","Yes");
                msgBox2.ShowDialog();
                if(msgBox2.Result != ModernMessageboxResult.Button2)
                {
                    this.IsEnabled = true;
                    return;
                }
            }
            else
            {
                var msgBox2 = new ModernMessageBox($"Are you sure that you want to set your answer as 'i agree about these sanctions' ?",
                                                             "Operation Information",
                                                             ModernMessageboxIcons.Error,
                                                             "No", "Yes");
                msgBox2.ShowDialog();
                if (msgBox2.Result != ModernMessageboxResult.Button2)
                {
                    this.IsEnabled = true;
                    return;
                }
            }
          

            this.IsEnabled = false;
            try
            {

                var selectedfeedback = LeaveRequestsDatagrid.SelectedItem as ReturnLeaveRequestsInformation;
                if (selectedfeedback?.LeaveRequestId == Guid.Empty)
                {
                    var msgBox2 = new ModernMessageBox($"Leave request is not located to be deleted.",
                                                                     "Operation Information",
                                                                     ModernMessageboxIcons.Error,
                                                                     "OK");
                    msgBox2.ShowDialog();

                    this.IsEnabled = true;
                    return;
                }
            
                        var request = new AgreeOnLeaveRequestDecisionRequest { LeaveRequestID = selectedfeedback.LeaveRequestId, Agreed= agreed };
                var win = new IndeterminateProgressWindow("Setting The Answer On The Leave Request...");
                win.Show();
                var response = await employeeAPIEndpointsDefinitions.AgreeonLeaveRequestRequest(request);
                win.Message = "Result is collected..";
                win.Close();


                if (response.IsSuccessStatusCode)
                {

                    var msgBox2 = new ModernMessageBox($"{response.Content.Message}",
                   "Operation Information",
                   ModernMessageboxIcons.Done,
                   "OK!");
                    msgBox2.ShowDialog();



                    ReasonTextbox.Clear();
                    DepartmentManagerMessageTextbox.Clear();
                    FinalMessageTextbox.Clear();
                    DepartmentManagerAnsweredAtTextbox.Clear();
                    DepartmentManagerAnsweredByTextbox.Clear();
                    HRManagerAnsweredAtTextbox.Clear();
                    HRManagerAnsweredByTextbox.Clear();
                    MyAgreementCheckbox.Visibility = Visibility.Collapsed;
                    SendFinalResult.Visibility = Visibility.Collapsed;
                    LeaveRequestsDatagrid.SelectedCells.Clear();





                    this.IsEnabled = true;
                    return;
                }
                else
                {
                    var msgBox2 = new ModernMessageBox($"{response.Content.Error}.",
                                                                  "Operation Information",
                                                                  ModernMessageboxIcons.Error,
                                                                  "OK");
                    msgBox2.ShowDialog();
                    LeaveRequestsDatagrid.ItemsSource = null;
                    this.IsEnabled = true;
                    return;
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



        private async void RefreshMyFeedbacks(object sender, RoutedEventArgs e)
        {


            this.IsEnabled = false;
            try
            {



                var win = new IndeterminateProgressWindow("Fetching the data...");
                win.Show();
                var response = await employeeAPIEndpointsDefinitions.GetMyLeaveRequestsRequests();
                win.Message = "Result is collected..";
                win.Close();


                if (response.IsSuccessStatusCode)
                {
                    GetmyLeaveRequests = response.Content;

                    LeaveRequestsDatagrid.ItemsSource = null;
                    LeaveRequestsDatagrid.ItemsSource = GetmyLeaveRequests;

                    this.IsEnabled = true;

                }
                else
                {
                    var msgBox2 = new ModernMessageBox($"No data was found or it didn't successfully connect to the server.",
                                                                  "Operation Information",
                                                                  ModernMessageboxIcons.Error,
                                                                  "OK");
                    msgBox2.ShowDialog();
                    LeaveRequestsDatagrid.ItemsSource = null;
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

        private async void DeleteLeaveRequest(object sender, RoutedEventArgs e)
        {


            if (LeaveRequestsDatagrid.SelectedItems.Count != 1)
            {
                var msgBox2 = new ModernMessageBox($"Please select a Leave request record to delete.",
                                                                               "Operation Information",
                                                                               ModernMessageboxIcons.Error,
                                                                               "OK");
                msgBox2.ShowDialog();

                this.IsEnabled = true;
                return;
            }

            this.IsEnabled = false;
            try
            {

                var selectedfeedback = LeaveRequestsDatagrid.SelectedItem as ReturnLeaveRequestsInformation;
                if (selectedfeedback?.LeaveRequestId == Guid.Empty)
                {
                    var msgBox2 = new ModernMessageBox($"Leave request is not located to be deleted.",
                                                                     "Operation Information",
                                                                     ModernMessageboxIcons.Error,
                                                                     "OK");
                    msgBox2.ShowDialog();

                    this.IsEnabled = true;
                    return;
                }
                var request = new RemoveMyLeaveRequest { LeaveRequestID = selectedfeedback.LeaveRequestId };
                var win = new IndeterminateProgressWindow("Removing Leave request...");
                win.Show();
                var response = await employeeAPIEndpointsDefinitions.RemoveMyLeaveRequest(request);
                win.Message = "Result is collected..";
                win.Close();


                if (response.IsSuccessStatusCode)
                {

                    var msgBox2 = new ModernMessageBox($"{response.Content.Message}",
                   "Operation Information",
                   ModernMessageboxIcons.Done,
                   "OK!");
                    msgBox2.ShowDialog();

              

                    ReasonTextbox.Clear();
                    DepartmentManagerMessageTextbox.Clear();
                    FinalMessageTextbox.Clear();
                    DepartmentManagerAnsweredAtTextbox.Clear();
                    DepartmentManagerAnsweredByTextbox.Clear();
                    HRManagerAnsweredAtTextbox.Clear();
                    HRManagerAnsweredByTextbox.Clear();
                    MyAgreementCheckbox.Visibility = Visibility.Collapsed;
                    SendFinalResult.IsEnabled = false;
                    LeaveRequestsDatagrid.SelectedCells.Clear();





                    this.IsEnabled = true;
                    return;
                }
                else
                {
                    var msgBox2 = new ModernMessageBox($"{response.Content.Error}.",
                                                                  "Operation Information",
                                                                  ModernMessageboxIcons.Error,
                                                                  "OK");
                    msgBox2.ShowDialog();
                    LeaveRequestsDatagrid.ItemsSource = null;
                    this.IsEnabled = true;
                    return;
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

}




