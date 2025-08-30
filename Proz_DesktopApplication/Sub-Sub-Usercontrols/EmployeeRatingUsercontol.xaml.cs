using ModernMessageBoxLib;
using Proz_DesktopApplication.API;
using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Windows;
using System.Windows.Controls;

namespace Proz_DesktopApplication.Sub_Sub_Usercontrols
{
    public partial class EmployeeRatingUsercontrol : BaseUserControlMain
    {
        
               public List<ReturnPerformanceRecordsResponse> GetEmployees { get; set; } = new();
        public List<ReturnAllDepartments> GetDepartments { get; set; } = new();
        public DMAPIEndpointsDefinitions DBAPIEndpointsDefinitions;
        bool isloaded = false;
        public EmployeeRatingUsercontrol()
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
               

                    SubDepartmentComboBox.DisplayMemberPath = "DepartmentName";
                    SubDepartmentComboBox.SelectedValuePath = "DepartmentID";
           

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

        private async void GetRecords(object sender, RoutedEventArgs e)
        {
            if (SubDepartmentComboBox.SelectedItem == null)
            {
                var msgBox2 = new ModernMessageBox($"Please select a sub department to fetch the performance records from.",
                                                                                "Operation Information",
                                                                                ModernMessageboxIcons.Error,
                                                                                "OK");
                msgBox2.ShowDialog();
                return;
            }

            this.IsEnabled = false;
            try
            {


                var request = new ReturnPerformanceRecordsRequest
                {
                    DepartmentID = (Guid)SubDepartmentComboBox.SelectedValue
                };
                var win = new IndeterminateProgressWindow("Fetching the data...");
                win.Show();
                var response = await DBAPIEndpointsDefinitions.GetMyEmployees(request);
                win.Message = "Result is collected..";
                win.Close();


                if (response.IsSuccessStatusCode && response.Content != null && response.Content.Any())
                {
                    GetEmployees = response.Content;

                    EmployeesDataGrid.ItemsSource = null;
                    EmployeesDataGrid.ItemsSource = GetEmployees;

                    this.IsEnabled = true;

                }
                else
                {
                    var msgBox2 = new ModernMessageBox($"No data was found or it didn't successfully connect to the server.",
                                                                  "Operation Information",
                                                                  ModernMessageboxIcons.Error,
                                                                  "OK");
                    msgBox2.ShowDialog();
                    EmployeesDataGrid.ItemsSource = null;
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

        private void EmployeesDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (EmployeesDataGrid.SelectedItem is EmployeeRecord selected)
            {

                PerformanceSlider.Value = 0;
                CommentTextbox.Clear();
               
                if (selected.rating == 1)
                    PerformanceSlider.Value = 1;
                else if (selected.rating == -1)
                    PerformanceSlider.Value = -1;
                else
                    PerformanceSlider.Value = 0;

                if (selected.RatingMessage != null)
                {
                    CommentTextbox.Text = selected.RatingMessage;
                }
            }
        }

        private async void SubmitRatingButton_Click(object sender, RoutedEventArgs e)
        {

            if (EmployeesDataGrid.SelectedItem is ReturnPerformanceRecordsResponse selected)
            {
                var msgBox3 = new ModernMessageBox($"Are you sure that you want to apply this Performance record to your employee ? ?.",
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


                    var request = new SubmitPerformanceAnswerRequest
                    {
                       EmployeeID = selected.EmployeeID,
                        Ratting = (int)PerformanceSlider.Value,
                        Comment = CommentTextbox.Text

                    };
                    var win = new IndeterminateProgressWindow("Applying your answer...");
                    win.Show();
                    var response = await DBAPIEndpointsDefinitions.PerformanceSubmitting(request);
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
                        SubmitPerformanceAnswerResponse errorResponse = null;
                        ValidationErrorResponse errorResponse2 = null;
                        if (!string.IsNullOrWhiteSpace(rawError))
                        {

                            try
                            {
                                errorResponse = JsonSerializer.Deserialize<SubmitPerformanceAnswerResponse>(rawError, new JsonSerializerOptions
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


    }

    public class EmployeeRecord
    {

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get; set; }

        public int rating { get; set; }
        public string RatingMessage { get; set; }
    }
}
