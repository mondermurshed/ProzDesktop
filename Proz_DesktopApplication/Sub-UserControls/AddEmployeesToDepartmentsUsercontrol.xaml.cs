using ModernMessageBoxLib;
using Proz_DesktopApplication.API;
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
    /// Interaction logic for AddEmployeesToDepartmentsUsercontrol.xaml
    /// </summary>
    public partial class AddEmployeesToDepartmentsUsercontrol : BaseUserControlMain
    {
        public List<ReturnDepartments> GetAllDepartmentsList { get; set; } = new();
        public List<ReturnEmployees> GetAllEmployeesList { get; set; } = new();
        public AdminAPIEndpointsDefinitions adminAPIEndpointsDefinitions;
        public AddEmployeesToDepartmentsUsercontrol()
        {
            InitializeComponent();
            Loaded += OnCreatingThisUsercontrol;
        }

        private async void OnCreatingThisUsercontrol(object sender, RoutedEventArgs e)
        {
            adminAPIEndpointsDefinitions = _AdminAPIEndpointsDefinitions1 ?? throw new InvalidOperationException("Services1 is null");
        }

        private async void AssignEventHandler(object sender, RoutedEventArgs e)
        {

            try
            {

                if (EmployeeListDatagrid.SelectedItems.Count != 1 && DepartmentListDatagrid.SelectedItems.Count != 1)
                {
                    var msgBox2 = new ModernMessageBox($"Select an employee + a department to get assigned.",
                                                                                     "Operation Information",
                                                                                     ModernMessageboxIcons.Error,
                                                                                     "OK");
                    msgBox2.ShowDialog();

                    this.IsEnabled = true;
                    return;
                }



                var SelectedEmployeeRow = EmployeeListDatagrid.SelectedItem as ReturnEmployees;
                var SelectedDepartmentRow = DepartmentListDatagrid.SelectedItem as ReturnDepartments;

                var request = new AssignEmployeeToADepartmentRequest() { EmployeeID = SelectedEmployeeRow.ID, DepartmentID = SelectedDepartmentRow.Id };
                var win = new IndeterminateProgressWindow("Fetching the data...");
                win.Show();
                var response = await adminAPIEndpointsDefinitions.AssignAnEmployeeToADepartment(request);
                win.Message = "Result is collected..";
                win.Close();


                if (response.IsSuccessStatusCode && response.Content?.Message != null)
                {
                    var msgBox2 = new ModernMessageBox($"{string.Join('\n', response.Content.Message)})",
                                                       "Operation Information",
                                                       ModernMessageboxIcons.Done,
                                                       "OK!");
                    msgBox2.ShowDialog();
                    this.IsEnabled = true;

                }

                else
                {
                    // When server returns 400, Refit puts the error JSON as a string here
                    var rawError = response.Error?.Content;
                    AssignEmployeeToADepartmentResponse errorResponse = null;
                    ValidationErrorResponse errorResponse2 = null;

                    if (!string.IsNullOrWhiteSpace(rawError))
                    {
                        try
                        {
                            errorResponse = JsonSerializer.Deserialize<AssignEmployeeToADepartmentResponse>(rawError, new JsonSerializerOptions
                            {
                                PropertyNameCaseInsensitive = true
                            });
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

                        if (errorResponse?.Errors != null && errorResponse.Errors.Count > 0)
                        {
                            var msgBox2 = new ModernMessageBox($"{string.Join('\n', errorResponse.Errors)}.",
                                                               "Operation Information",
                                                               ModernMessageboxIcons.Error,
                                                               "OK");
                            msgBox2.ShowDialog();
                            this.IsEnabled = true;
                        }

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

        private async void RefreshEmployeeList(object sender, RoutedEventArgs e)
        {
            this.IsEnabled = false;
            try
            {



                var win = new IndeterminateProgressWindow("Fetching the data...");
                win.Show();
                var response = await adminAPIEndpointsDefinitions.GetEmployees();
                win.Message = "Result is collected..";
                win.Close();


                if (response.IsSuccessStatusCode && response.Content != null && response.Content.Any())
                {
                    GetAllEmployeesList = response.Content;

                    EmployeeListDatagrid.ItemsSource = null;
                    EmployeeListDatagrid.ItemsSource = GetAllEmployeesList;

                    this.IsEnabled = true;

                }
                else
                {
                    var msgBox2 = new ModernMessageBox($"No data was found or it didn't successfully connect to the server.",
                                                                  "Operation Information",
                                                                  ModernMessageboxIcons.Error,
                                                                  "OK");
                    msgBox2.ShowDialog();
                    EmployeeListDatagrid.ItemsSource = null;
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

        private async void RefreshDepartmentList(object sender, RoutedEventArgs e)
        {

            this.IsEnabled = false;
            try
            {



                var win = new IndeterminateProgressWindow("Fetching the data...");
                win.Show();
                var response = await adminAPIEndpointsDefinitions.GetDepartmentsALL();
                win.Message = "Result is collected..";
                win.Close();


                if (response.IsSuccessStatusCode && response.Content != null && response.Content.Any())
                {
                    GetAllDepartmentsList = response.Content;

                    DepartmentListDatagrid.ItemsSource = null;
                    DepartmentListDatagrid.ItemsSource = GetAllDepartmentsList;

                    this.IsEnabled = true;

                }
                else
                {
                    var msgBox2 = new ModernMessageBox($"No data was found or it didn't successfully connect to the server.",
                                                                  "Operation Information",
                                                                  ModernMessageboxIcons.Error,
                                                                  "OK");
                    msgBox2.ShowDialog();
                    DepartmentListDatagrid.ItemsSource = null;
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

        private async void UnassignFromDepartment(object sender, RoutedEventArgs e)
        {

            if (sender is Button button && button.DataContext is ReturnEmployees user)
            {
                //if (user.ID == Guid.Empty)
                //{
                //    var msgBo = new ModernMessageBox($"This '{user.DepartmentName}' department doesn't have a manager assigned to it, please refresh if you see that this department has a manager assigned.",
                //                                              "Operation Information",
                //                                              ModernMessageboxIcons.Error,
                //                                              "OK");
                //    msgBo.ShowDialog();
                //    return;
                //}

                this.IsEnabled = false;
                try
                {

                    var request = new GetDepartmentOfEmployeeRequest
                    {
                        EmployeeID = user.ID
                    };

                    var win = new IndeterminateProgressWindow("Searching Employee...");
                    win.Show();
                    var response = await adminAPIEndpointsDefinitions.GetEmployeeDepartment(request);
                    win.Message = "Result is collected..";
                    win.Close();


                    if (response.IsSuccessStatusCode)
                    {
                        var msgBox2 = new ModernMessageBox($"We found that this employee is assigned to the '{response.Content.DepartmentName?? "**No Name**"}' department. Do you really wish to unassign the employee from it ?",
                                                           "Operation Information",
                                                           ModernMessageboxIcons.Info,
                                                           "No", "Yes");
                        msgBox2.ShowDialog();

                        if (msgBox2.Result == ModernMessageboxResult.Button2)
                        {
                            //s



                            this.IsEnabled = false;
                            var request1 = new UnassignEmployeeToADepartmentRequest
                            {
                                EmployeeID = user.ID,
                                DepartmentID = response.Content.DepartmentID


                            };
                            try
                            {
                                
                            

                                var win1 = new IndeterminateProgressWindow("Performing the operation...");
                                win1.Show();
                                var response3 = await adminAPIEndpointsDefinitions.UnassignAnEmployeeToADepartment(request1);
                                win1.Message = "Result is collected..";
                                win1.Close();


                                if (response3.IsSuccessStatusCode && response3.Content?.Message != null)
                                {
                                    var msgBox3 = new ModernMessageBox($"{string.Join('\n', response3.Content.Message)})",
                                                                       "Operation Information",
                                                                       ModernMessageboxIcons.Done,
                                                                       "OK!");
                                    msgBox3.ShowDialog();
                                    this.IsEnabled = true;
                           

                                }

                                else
                                {
                                    // When server returns 400, Refit puts the error JSON as a string here
                                    var rawError = response3.Error?.Content;
                                    UnassignEmployeeToADepartmentResponse errorResponse = null;
                                    ValidationErrorResponse errorResponse2 = null;

                                    if (!string.IsNullOrWhiteSpace(rawError))
                                    {
                                        try
                                        {
                                            errorResponse = JsonSerializer.Deserialize<UnassignEmployeeToADepartmentResponse>(rawError, new JsonSerializerOptions
                                            {
                                                PropertyNameCaseInsensitive = true
                                            });
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

                                        if (errorResponse?.Errors != null && errorResponse.Errors.Count > 0)
                                        {
                                            var msgBox3 = new ModernMessageBox($"{string.Join('\n', errorResponse.Errors)}.",
                                                                               "Operation Information",
                                                                               ModernMessageboxIcons.Error,
                                                                               "OK");
                                            msgBox3.ShowDialog();
                                            this.IsEnabled = true;
                                        }

                                    }

                                }
                            }
                            catch (Exception ex)
                            {
                                var msgBox4 = new ModernMessageBox($"Something went wrong..",
                                                                              "Operation Information",
                                                                              ModernMessageboxIcons.Error,
                                                                              "OK");
                                msgBox4.ShowDialog();
                                this.IsEnabled = true;
                            }





                            //e
                        }
                        else
                        {
                            this.IsEnabled = true;
                            return;
                        }


                    }
                    else
                    {
                        var msgBox2 = new ModernMessageBox($"The employee '{user.FullName}' is not assigned to anything, yet.",
                                                                               "Operation Information",
                                                                               ModernMessageboxIcons.Error,
                                                                               "OK");
                        msgBox2.ShowDialog();
                        this.IsEnabled = true;
                        return;
                     
                    }
                }
                catch
                {
               var msgBox2 = new ModernMessageBox($"Something went wrong!.",
               "Operation Information",
               ModernMessageboxIcons.Error,
               "OK");
                        msgBox2.ShowDialog();
                    this.IsEnabled = true;
                    return;
                       
                }
                }


        }
    }
}
