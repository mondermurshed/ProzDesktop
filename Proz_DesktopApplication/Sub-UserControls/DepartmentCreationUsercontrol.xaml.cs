using System.Text.Json;
using System.Windows;
using System.Windows.Controls;
using ModernMessageBoxLib;
using Proz_DesktopApplication.API;

namespace Proz_DesktopApplication.Sub_UserControls
{
    public partial class DepartmentCreationUsercontrol : BaseUserControlMain
    {
        public List<ReturnAllDepartmentManagers> GetDepartmentManagers { get; set; } = new();
        public List<ReturnAllDepartmentManagers> GetDepartmentManagersthirdtab { get; set; } = new();
        public List<ReturnDepartmentsWithManagers> GetDepartmentsWithManagers { get; set; } = new();
        public List<ReturnDepartmentsNames> GetDepartmentsNames { get; set; } = new();
        public AdminAPIEndpointsDefinitions adminAPIEndpointsDefinitions;
        public DepartmentCreationUsercontrol()
        {
            InitializeComponent();
            // Later: Load data from API here
            Loaded += OnCreatingThisUsercontrol;
        }

        private async void OnCreatingThisUsercontrol(object sender, RoutedEventArgs e)
        {
            adminAPIEndpointsDefinitions = _AdminAPIEndpointsDefinitions1 ?? throw new InvalidOperationException("Services1 is null");


        }
        private async void CreateDepartmentButton_Click(object sender, RoutedEventArgs e)
        {
            this.IsEnabled = false;
            if (DepartmentNameTextBox.Text=="" || DepartmentManagersDatagrid.SelectedItems.Count!=1)
            {
                var msgBox1 = new ModernMessageBox($"Please fill the name of the department textbox as well as selecting a department manager from the grid.",
                             "Reminder",
                            ModernMessageboxIcons.Error,
                             "OK");
                msgBox1.ShowDialog();
                this.IsEnabled = true;
                return;
            }
          
            try
            {
                var request = new CreateANewDepartmentRequest
                {
                    DepartmentName = DepartmentNameTextBox.Text.Trim(),
                    ManagerID = (DepartmentManagersDatagrid.SelectedItem as ReturnAllDepartmentManagers)?.UserId ?? Guid.Empty
                };
                var win = new IndeterminateProgressWindow("Saving data...");
                win.Show();
                var response = await adminAPIEndpointsDefinitions.CreateANewDepartment(request);
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
                    CreateANewDepartmentResponse errorResponse = null;
                    ValidationErrorResponse errorResponse2 = null;

                    if (!string.IsNullOrWhiteSpace(rawError))
                    {
                        try
                        {
                            errorResponse = JsonSerializer.Deserialize<CreateANewDepartmentResponse>(rawError, new JsonSerializerOptions
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
                var msgBox2 = new ModernMessageBox($"Something went wrong..",
                                                              "Operation Information",
                                                              ModernMessageboxIcons.Error,
                                                              "OK");
                msgBox2.ShowDialog();
                this.IsEnabled = true;
            }

        }

        private async void UnassignManagerButton_Click(object sender, RoutedEventArgs e)
        {
           
            if (sender is Button button && button.DataContext is ReturnDepartmentsWithManagers user)
            {
                if(user.ManagerID==Guid.Empty)
                {
                    var msgBo = new ModernMessageBox($"This '{user.DepartmentName}' department doesn't have a manager assigned to it, please refresh if you see that this department has a manager assigned.",
                                                              "Operation Information",
                                                              ModernMessageboxIcons.Error,
                                                              "OK");
                    msgBo.ShowDialog();
                    return;
                }
                var msgBox = new ModernMessageBox($"Are you sure that you want unassign this manager '{user.ManagerName}' from the department '{user.DepartmentName}' ?",
                                                         "Operation Information",
                                                         ModernMessageboxIcons.Info,
                                                         "No", "Yes");
                msgBox.ShowDialog();

                if (msgBox.Result == ModernMessageboxResult.Button2)
                {



                    this.IsEnabled = false;
                    try
                    {

                        var request = new UnassignAManagerFromADepartmentRequest
                        {
                            DepartmentID = user.DepartmentID
                        };

                        var win = new IndeterminateProgressWindow("Performing the operation...");
                        win.Show();
                        var response = await adminAPIEndpointsDefinitions.UnassignAManagerFromADepartment(request);
                        win.Message = "Result is collected..";
                        win.Close();


                        if (response.IsSuccessStatusCode && response.Content?.Message != null)
                        {
                            var msgBox2 = new ModernMessageBox($"{string.Join('\n', response.Content.Message)})",
                                                               "Operation Information",
                                                               ModernMessageboxIcons.Done,
                                                               "OK!");
                            msgBox2.ShowDialog();

                            try
                            {

                                var win1 = new IndeterminateProgressWindow("Fetching the data...");
                                win1.Show();
                                var response1 = await adminAPIEndpointsDefinitions.GetAllDepartmentsWithItsManagers();
                                win1.Message = "Result is collected..";
                                win1.Close();


                                if (response1.IsSuccessStatusCode && response1.Content != null && response1.Content.Any())
                                {
                                    GetDepartmentsWithManagers = response1.Content;

                                    DepartmentsWithManagerDataGrid.ItemsSource = null;
                                    DepartmentsWithManagerDataGrid.ItemsSource = GetDepartmentsWithManagers;
                                    if (DepartmentsWithManagerDataGrid.Items.Count >= 2)
                                    {
                                        SearchByNmaeDepartmentmanagerTextbox.IsEnabled = true;
                                    }
                                    else
                                    {
                                        SearchByNmaeDepartmentmanagerTextbox.IsEnabled = false;
                                    }
                                    this.IsEnabled = true;

                                }
                                else
                                {
                                    var msgBox3 = new ModernMessageBox($"No data was found or it didn't successfully connect to the server.",
                                                                                  "Operation Information",
                                                                                  ModernMessageboxIcons.Error,
                                                                                  "OK");
                                    msgBox3.ShowDialog();
                                    DepartmentsWithManagerDataGrid.ItemsSource = null;
                                    this.IsEnabled = true;
                                }

                            }
                            catch (Exception ex)
                            {
                                this.IsEnabled = true;
                            }

                          

                        }

                        else
                        {
                            // When server returns 400, Refit puts the error JSON as a string here
                            var rawError = response.Error?.Content;
                            UnassignAManagerFromADepartmentResponse errorResponse = null;
                            ValidationErrorResponse errorResponse2 = null;

                            if (!string.IsNullOrWhiteSpace(rawError))
                            {
                                try
                                {
                                    errorResponse = JsonSerializer.Deserialize<UnassignAManagerFromADepartmentResponse>(rawError, new JsonSerializerOptions
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
                        var msgBox2 = new ModernMessageBox($"Something went wrong..",
                                                                      "Operation Information",
                                                                      ModernMessageboxIcons.Error,
                                                                      "OK");
                        msgBox2.ShowDialog();
                        this.IsEnabled = true;
                    }
                }



            }
        }

      

        private async void DeleteDepartment(object sender, RoutedEventArgs e) //asgasgasgsagasgsag
        {

         
            if (sender is Button button && button.DataContext is ReturnDepartmentsWithManagers user)
            {
               
                var msgBox = new ModernMessageBox($"Are you sure that you want to delete this department '{user.DepartmentName}' from the system ? (THIS IS CRITICAL!)",
                                                         "Operation Information",
                                                         ModernMessageboxIcons.Info,
                                                         "No", "Yes");
                msgBox.ShowDialog();

                if (msgBox.Result == ModernMessageboxResult.Button2)
                {
                    this.IsEnabled = false;
                    bool approval = false;
                    int count = 1;
                    do
                    {



                    try
                    {

                        var request = new RemoveADepartmentRequest
                        {
                            DepartmentID = user.DepartmentID,
                            WithUnassignEmployeesFromItAgreement = approval // Assuming you want to unassign employees from it
                        };
                  

                        var win = new IndeterminateProgressWindow("Performing the operation...");
                        win.Show();
                        var response = await adminAPIEndpointsDefinitions.DeleteADepartment(request);
                        win.Message = "Result is collected..";
                        win.Close();


                        if (response.IsSuccessStatusCode && response.Content?.Message != null)
                        {
                            var msgBox2 = new ModernMessageBox($"{string.Join('\n', response.Content.Message)})",
                                                               "Operation Information",
                                                               ModernMessageboxIcons.Done,
                                                               "OK!");
                            msgBox2.ShowDialog();

                            try
                            {

                                var win1 = new IndeterminateProgressWindow("Fetching the data...");
                                win1.Show();
                                var response1 = await adminAPIEndpointsDefinitions.GetAllDepartmentsWithItsManagers();
                                win1.Message = "Result is collected..";
                                win1.Close();


                                if (response1.IsSuccessStatusCode && response1.Content != null && response1.Content.Any())
                                {
                                    GetDepartmentsWithManagers = response1.Content;

                                    DepartmentsWithManagerDataGrid.ItemsSource = null;
                                    DepartmentsWithManagerDataGrid.ItemsSource = GetDepartmentsWithManagers;
                                    if (DepartmentsWithManagerDataGrid.Items.Count >= 2)
                                    {
                                        SearchByNmaeDepartmentmanagerTextbox.IsEnabled = true;
                                    }
                                    else
                                    {
                                        SearchByNmaeDepartmentmanagerTextbox.IsEnabled = false;
                                    }
                                    this.IsEnabled = true;
                                    return;
                                }
                                else
                                {
                                    var msgBox3 = new ModernMessageBox($"No data was found or it didn't successfully connect to the server again.",
                                                                                  "Operation Information",
                                                                                  ModernMessageboxIcons.Error,
                                                                                  "OK");
                                    msgBox3.ShowDialog();
                                    DepartmentsWithManagerDataGrid.ItemsSource = null;
                                    this.IsEnabled = true;
                                    return;
                                    }

                            }
                            catch (Exception ex)
                            {
                                this.IsEnabled = true;
                                    return;
                                }



                        }

                        else
                        {
                            // When server returns 400, Refit puts the error JSON as a string here
                            var rawError = response.Error?.Content;
                            RemoveADepartmentResponse errorResponse = null;
                            ValidationErrorResponse errorResponse2 = null;

                            if (!string.IsNullOrWhiteSpace(rawError))
                            {
                                try
                                {
                                    errorResponse = JsonSerializer.Deserialize<RemoveADepartmentResponse>(rawError, new JsonSerializerOptions
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

                                if (errorResponse?.Errors != null && errorResponse.Errors.Count > 0 && errorResponse.NeedesAdminApproval==false)
                                {
                                    var msgBox2 = new ModernMessageBox($"{string.Join('\n', errorResponse.Errors)}.",
                                                                       "Operation Information",
                                                                       ModernMessageboxIcons.Error,
                                                                       "OK");
                                    msgBox2.ShowDialog();
                                    this.IsEnabled = true;
                                        return;
                                }

                                else if (errorResponse?.Errors != null && errorResponse.Errors.Count > 0 && errorResponse.NeedesAdminApproval==true)
                                {
                                        //start 
                               var msgBox2 = new ModernMessageBox($"We noticed that the department you want to remove has employees assigned to it, do you want to cancel the operation \n" +
                                   $"or do you to delete the department and unassign all the employees in it (this will make the employees without a department).",
                                                                     "Operation Information",
                                                                     ModernMessageboxIcons.Info,
                                                                     "No, cancel the operation" , "Force delete the department at all costs");
                               msgBox2.ShowDialog();

                               if(msgBox2.Result != ModernMessageboxResult.Button2)
                                        {
                                            this.IsEnabled = true;
                                            return;
                                        }
                               else
                               {
                                            approval = true;
                                            count++;
                                            continue;
                                        }
                                


                                        //end
                                    }

                            }

                        }
                    }
                    catch (Exception ex)
                    {
                        var msgBox2 = new ModernMessageBox($"Something went wrong..",
                                                                      "Operation Information",
                                                                      ModernMessageboxIcons.Error,
                                                                      "OK");
                        msgBox2.ShowDialog();
                        this.IsEnabled = true;
                            return;
                        }


                    }

                    while (count<2);

                }



            }



        }

        private async void RefreshManagersAddDepartementSection(object sender, RoutedEventArgs e)
        {
            //SearchByNmaeDepartmentmanagerTextbox
            this.IsEnabled = false;
            try
            {

                var win = new IndeterminateProgressWindow("Fetching the data...");
                win.Show();
                var response = await adminAPIEndpointsDefinitions.GetAllDepartmentManagers();
                win.Message = "Result is collected..";
                win.Close();


                if (response.IsSuccessStatusCode && response.Content != null && response.Content.Any())
                {
                    GetDepartmentManagers = response.Content;

                    DepartmentManagersDatagrid.ItemsSource = null;
                    DepartmentManagersDatagrid.ItemsSource = GetDepartmentManagers;
                    if(DepartmentManagersDatagrid.Items.Count>=2)
                    {
                        SearchByNmaeDepartmentmanagerTextbox.IsEnabled = true;
                    }
                    else
                    {
                        SearchByNmaeDepartmentmanagerTextbox.IsEnabled = false;
                    }
                    this.IsEnabled = true;

                }
                else
                {
                    var msgBox2 = new ModernMessageBox($"No data was found or it didn't successfully connect to the server.",
                                                                  "Operation Information",
                                                                  ModernMessageboxIcons.Error,
                                                                  "OK");
                    msgBox2.ShowDialog();
                    DepartmentManagersDatagrid.ItemsSource = null;
                    this.IsEnabled = true;
                }

            }
            catch (Exception ex)
            {
                this.IsEnabled = true;
            }
        }

        private void SearchDepartmentmanagerbyname(object sender, TextChangedEventArgs e)
        {
            string filter = SearchByNmaeDepartmentmanagerTextbox.Text.Trim().ToLower();
            if (string.IsNullOrEmpty(filter))
            {
                DepartmentManagersDatagrid.ItemsSource = GetDepartmentManagers;
            }
            else
            {
                var filtered = GetDepartmentManagers.Where(u => u.FullName.ToLower().Contains(filter)).ToList();
                DepartmentManagersDatagrid.ItemsSource = filtered;
            }
        }

        private async void refreshdepartmentwithmanagersdatagrid(object sender, RoutedEventArgs e)
        {
            this.IsEnabled = false;
            try
            {

                var win = new IndeterminateProgressWindow("Fetching the data...");
                win.Show();
                var response = await adminAPIEndpointsDefinitions.GetAllDepartmentsWithItsManagers();
                win.Message = "Result is collected..";
                win.Close();


                if (response.IsSuccessStatusCode && response.Content != null && response.Content.Any())
                {
                    GetDepartmentsWithManagers = response.Content;

                    DepartmentsWithManagerDataGrid.ItemsSource = null;
                    DepartmentsWithManagerDataGrid.ItemsSource = GetDepartmentsWithManagers;
                    if (DepartmentsWithManagerDataGrid.Items.Count >= 2)
                    {
                        SearchByNmaeDepartmentmanagerTextbox.IsEnabled = true;
                    }
                    else
                    {
                        SearchByNmaeDepartmentmanagerTextbox.IsEnabled = false;
                    }
                    this.IsEnabled = true;

                }
                else
                {
                    var msgBox2 = new ModernMessageBox($"No data was found or it didn't successfully connect to the server.",
                                                                  "Operation Information",
                                                                  ModernMessageboxIcons.Error,
                                                                  "OK");
                    msgBox2.ShowDialog();
                    DepartmentsWithManagerDataGrid.ItemsSource = null;
                    this.IsEnabled = true;
                }

            }
            catch (Exception ex)
            {
                this.IsEnabled = true;
            }
        }

        private async void AssignManagerButton_Click(object sender, RoutedEventArgs e)
        {
            IsEnabled = false;
            if (DepartmentsWithoutManagerDataGrid.SelectedItems.Count != 1 || DepartmentManagersDatagridthirdtab.SelectedItems.Count != 1)
            {
                var msgBox2 = new ModernMessageBox($"Please select one department and one manager so both will be assigned.",
                                                               "Operation Information",
                                                               ModernMessageboxIcons.Error,
                                                               "OK");
                msgBox2.ShowDialog();
                IsEnabled = true;
                return;
            }

               var selecteddepartment=DepartmentsWithoutManagerDataGrid.SelectedItem as ReturnDepartmentsNames;
               var selectedmanager = DepartmentManagersDatagridthirdtab.SelectedItem as ReturnAllDepartmentManagers;

         
                var msgBox = new ModernMessageBox($"Are you sure that you want assign this manager '{selectedmanager.FullName}' to the department '{selecteddepartment.DepartmentName}' ?",
                                                         "Operation Information",
                                                         ModernMessageboxIcons.Info,
                                                         "No", "Yes");
                msgBox.ShowDialog();

                if (msgBox.Result == ModernMessageboxResult.Button2)
                {



                    this.IsEnabled = false;
                    try
                    {

                        var request = new AssignManagerToADepartmentRequest
                        {
                            DepartmentID = selecteddepartment.Id,
                            ManagerID = selectedmanager.UserId
                        };
                  

                        var win = new IndeterminateProgressWindow("Performing the operation...");
                        win.Show();
                        var response = await adminAPIEndpointsDefinitions.AssignAManagerToADepartment(request);
                        win.Message = "Result is collected..";
                        win.Close();


                        if (response.IsSuccessStatusCode && response.Content?.Message != null)
                        {
                            var msgBox2 = new ModernMessageBox($"{string.Join('\n', response.Content.Message)})",
                                                               "Operation Information",
                                                               ModernMessageboxIcons.Done,
                                                               "OK!");
                            msgBox2.ShowDialog();

                        try
                        {

                            var win2 = new IndeterminateProgressWindow("Fetching the data...");
                            win2.Show();
                            var response0 = await adminAPIEndpointsDefinitions.GetAllDepartmentManagers();
                            var response2 = await adminAPIEndpointsDefinitions.GetDeparementsNames();
                            win2.Message = "Result is collected..";
                            win2.Close();


                            if (response0.IsSuccessStatusCode && response0.Content != null && response0.Content.Any())
                            {
                                GetDepartmentManagersthirdtab = response0.Content;

                                DepartmentManagersDatagridthirdtab.ItemsSource = null;
                                DepartmentManagersDatagridthirdtab.ItemsSource = GetDepartmentManagersthirdtab;



                            }
                      
                            if (response2.IsSuccessStatusCode && response2.Content != null && response2.Content.Any())
                            {
                                GetDepartmentsNames = response2.Content;

                                DepartmentsWithoutManagerDataGrid.ItemsSource = null;
                                DepartmentsWithoutManagerDataGrid.ItemsSource = GetDepartmentsNames;


                            }

                            this.IsEnabled = true;
                        }
                        catch (Exception ex)
                        {
                            this.IsEnabled = true;
                        }



                    }

                        else
                        {
                            // When server returns 400, Refit puts the error JSON as a string here
                            var rawError = response.Error?.Content;
                            AssignManagerToADepartmentResponse errorResponse = null;
                            ValidationErrorResponse errorResponse2 = null;

                            if (!string.IsNullOrWhiteSpace(rawError))
                            {
                                try
                                {
                                    errorResponse = JsonSerializer.Deserialize<AssignManagerToADepartmentResponse>(rawError, new JsonSerializerOptions
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
                        var msgBox2 = new ModernMessageBox($"Something went wrong..",
                                                                      "Operation Information",
                                                                      ModernMessageboxIcons.Error,
                                                                      "OK");
                        msgBox2.ShowDialog();
                        this.IsEnabled = true;
                    }
                }

            IsEnabled = true;

            







        }

     

        private async void RefreshInTab3(object sender, RoutedEventArgs e)
        {
            this.IsEnabled = false;
            try
            {

                var win = new IndeterminateProgressWindow("Fetching the data...");
                win.Show();
                var response = await adminAPIEndpointsDefinitions.GetAllDepartmentManagers();
                var response2 = await adminAPIEndpointsDefinitions.GetDeparementsNames();
                win.Message = "Result is collected..";
                win.Close();


                if (response.IsSuccessStatusCode && response.Content != null && response.Content.Any())
                {
                    GetDepartmentManagersthirdtab = response.Content;

                    DepartmentManagersDatagridthirdtab.ItemsSource = null;
                    DepartmentManagersDatagridthirdtab.ItemsSource = GetDepartmentManagersthirdtab;



                }
                else
                {
                    DepartmentManagersDatagridthirdtab.ItemsSource = null;
                }

                if (response2.IsSuccessStatusCode && response2.Content != null && response2.Content.Any())
                {
                    GetDepartmentsNames = response2.Content;

                    DepartmentsWithoutManagerDataGrid.ItemsSource = null;
                    DepartmentsWithoutManagerDataGrid.ItemsSource = GetDepartmentsNames;


                }
                else
                {
                    DepartmentsWithoutManagerDataGrid.ItemsSource = null;
                    
                }

                this.IsEnabled = true;
            }
            catch (Exception ex)
            {
                this.IsEnabled = true;
            }
        }
    }
}
//DepartmentsWithoutManagerDataGrid