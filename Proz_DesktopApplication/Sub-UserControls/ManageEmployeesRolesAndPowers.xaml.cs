using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text.Json;
using System.Windows;
using System.Windows.Controls;
using ModernMessageBoxLib;
using System.Windows.Media;
using Proz_DesktopApplication.API;
using System.Windows.Interop;

namespace Proz_DesktopApplication.Sub_UserControls
{
    public partial class ManageEmployeesRolesAndPowers : BaseUserControlMain
    {
       public List<GetAllUsersResponse> UsersList { get; set; } = new();
        public List<GetAllUsersResponse> UsersList2 { get; set; } = new(); 
        public AdminAPIEndpointsDefinitions adminAPIEndpointsDefinitions;
        public ManageEmployeesRolesAndPowers()
        {
            InitializeComponent();

            Loaded += OnManageEmployeesRolesAndPowersLoaded;
         
        }

        private async void OnManageEmployeesRolesAndPowersLoaded(object sender, RoutedEventArgs e)
        {
            adminAPIEndpointsDefinitions = _AdminAPIEndpointsDefinitions1 ?? throw new InvalidOperationException("Services1 is null");
            //await LoadUsers();
            ////LoadHRManagers();

        }

      
        private void LoadHRManagers()
        {
            //var hrManagers = UsersList
            //    .Where(u => u.RoleName == "HR Manager")
            //    .Select(u => new HRPower
            //    {
            //        Id = u.Id,
            //        FullName = u.FullName,
            //        HasFullPower = true // Default to full power
            //    })
            //    .ToList();

            //HRManagersGrid.ItemsSource = hrManagers;
        }
        private void SearchUsersTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            string filter = SearchUsersTextBox.Text.Trim().ToLower();
            if (string.IsNullOrEmpty(filter))
            {
                UsersRolesDataGrid.ItemsSource = UsersList;
            }
            else
            {
                var filtered = UsersList.Where(u => u.FullName.ToLower().Contains(filter)).ToList();
                UsersRolesDataGrid.ItemsSource = filtered;
            }
        }

        private void SearchHRManagersTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            //string filter = SearchHRManagersTextBox.Text.Trim().ToLower();

            //var filtered = UsersList
            //    .Where(u => u.RoleName == "HR Manager" && u.FullName.ToLower().Contains(filter))
            //    .Select(u => new HRPower
            //    {
            //        Id = u.Id,
            //        FullName = u.FullName,
            //        HasFullPower = true // You can adjust if needed
            //    })
            //    .ToList();

            //HRManagersGrid.ItemsSource = filtered;
        }

        private async void DeleteUserButton_Click(object sender, RoutedEventArgs e)
        {
            var msgBox2 = new ModernMessageBox($"Are you sure that you want to delete this user from the system ?",
                                                   "Operation Information",
                                                   ModernMessageboxIcons.Info,
                                                   "No", "Yes");
            msgBox2.ShowDialog();

            if (msgBox2.Result == ModernMessageboxResult.Button2)
            {



                if (sender is Button button && button.DataContext is GetAllUsersResponse user)
                {
                    try
                    {
                        this.IsEnabled = false;
                        var request = new AdminDeleteAccountRequest { UserID = user.id };
                        var win = new IndeterminateProgressWindow("Please wait while we are waiting for the server to response.");
                        win.Show();
                     
                        var response = await adminAPIEndpointsDefinitions.DeleteAccount(request);
                        win.Message = "Showing the result..";
                        win.Close();


                        if (response.IsSuccessStatusCode && response.Content?.Message?.Any() == true)
                        {
                            var msgBox1 = new ModernMessageBox($"{string.Join('\n', response.Content.Message)}",
                                                          "Operation Information",
                                                          ModernMessageboxIcons.Done,
                                                          "OK!");
                            msgBox1.ShowDialog();
                            this.IsEnabled = true;

                        }
                        else
                        {
                            // When server returns 400, Refit puts the error JSON as a string here
                            var rawError = response.Error?.Content;

                            if (!string.IsNullOrWhiteSpace(rawError))
                            {

                                var errorResponse = JsonSerializer.Deserialize<AdminDeleteAccountResponse>(rawError, new JsonSerializerOptions
                                {
                                    PropertyNameCaseInsensitive = true
                                });


                                if (errorResponse?.Errors?.Any() == true)
                                {
                                    var msgBox1 = new ModernMessageBox($"Error : {string.Join('\n', errorResponse.Errors)}",
                                                          "Operation Information",
                                                          ModernMessageboxIcons.Error,
                                                          "OK");
                                    msgBox1.ShowDialog();
                                    
                                }
                            }
                            else
                            {
                                var msgBox1 = new ModernMessageBox($"Something went wrong happended..",
                                                         "Operation Information",
                                                         ModernMessageboxIcons.Error,
                                                         "OK");
                                msgBox1.ShowDialog();
                            }
                            this.IsEnabled = true;
                        }
                    }
                    catch (Exception ex)
                    {
                        var msg = new ModernMessageBox($"Network error or app bug: {ex.Message} ", "Something went wrong!", ModernMessageboxIcons.Error, "OK");
                        msg.ShowDialog();
                        this.IsEnabled = true;
                    }
                }
            }
        }

        private async void ChangeRoleEventHandler(object sender, RoutedEventArgs e)
        {
        
            if (sender is RadioButton radioButton && radioButton.DataContext is GetAllUsersResponse user)
            {

                string rolename = radioButton.Tag.ToString();
             
                var msgBox2 = new ModernMessageBox($"Are you sure that you want to change the role of this user from {user.RoleName} to {rolename} in the system ?",
                                                 "Operation Information",
                                                 ModernMessageboxIcons.Info,
                                                 "No", "Yes");
            msgBox2.ShowDialog();

            if (msgBox2.Result == ModernMessageboxResult.Button2)
            {



               
                    try
                    {
                        this.IsEnabled = false;
                        var request = new AdminChangeRoleRequest { UserId= user.id, NewRoles= rolename };
                        var win = new IndeterminateProgressWindow("Please wait while we are waiting for the server to to collect an answer.");
                        win.Show();
                        var response = await adminAPIEndpointsDefinitions.UpdateUsersRole(request);
                        win.Message = "Showing the answer..";
                        win.Close();


                        if (response.IsSuccessStatusCode && response.Content?.Message?.Any() == true)
                        {
                          
                            var msgBox1 = new ModernMessageBox($"{string.Join('\n', response.Content.Message)}",
                                                          "Operation Information",
                                                          ModernMessageboxIcons.Done,
                                                          "OK!");
                            msgBox1.ShowDialog();
                            this.IsEnabled = true;
                        }
                        else
                        {
                            // When server returns 400, Refit puts the error JSON as a string here
                            var rawError = response.Error?.Content;

                            if (!string.IsNullOrWhiteSpace(rawError))
                            {

                                var errorResponse = JsonSerializer.Deserialize<AdminChangeRoleResponse>(rawError, new JsonSerializerOptions
                                {
                                    PropertyNameCaseInsensitive = true
                                });


                                if (errorResponse?.Errors?.Any() == true)
                                {
                                    var msgBox1 = new ModernMessageBox($"Error : {string.Join('\n', errorResponse.Errors)}",
                                                          "Operation Information",
                                                          ModernMessageboxIcons.Error,
                                                          "OK");
                                    msgBox1.ShowDialog();

                                    UsersList = UsersList2.Select(user => new GetAllUsersResponse
                                    {
                                        id = user.id,
                                        FullName = user.FullName,
                                        RoleName = user.RoleName,
                                        IsUser = user.IsUser,
                                        IsEmployee = user.IsEmployee,
                                        IsDepartmentManager = user.IsDepartmentManager,
                                        IsHRManager = user.IsHRManager,
                                        IsAdmin = user.IsAdmin
                                    }).ToList();

                                    UsersRolesDataGrid.ItemsSource = null;
                                    UsersRolesDataGrid.ItemsSource = UsersList;

                                }
                                this.IsEnabled = true;
                            }
                            else
                            {
                                var msgBox1 = new ModernMessageBox($"Something went wrong happended..",
                                                         "Operation Information",
                                                         ModernMessageboxIcons.Error,
                                                         "OK");
                                msgBox1.ShowDialog();

                                UsersList = UsersList2.Select(user => new GetAllUsersResponse
                                {
                                    id = user.id,
                                    FullName = user.FullName,
                                    RoleName = user.RoleName,
                                    IsUser = user.IsUser,
                                    IsEmployee = user.IsEmployee,
                                    IsDepartmentManager = user.IsDepartmentManager,
                                    IsHRManager = user.IsHRManager,
                                    IsAdmin = user.IsAdmin
                                }).ToList();

                                UsersRolesDataGrid.ItemsSource = null;
                                UsersRolesDataGrid.ItemsSource = UsersList;
                                this.IsEnabled = true;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        var msg = new ModernMessageBox($"Network error or app bug: {ex.Message} ", "Something went wrong!", ModernMessageboxIcons.Error, "OK");
                        msg.ShowDialog();

                        UsersList = UsersList2.Select(user => new GetAllUsersResponse
                        {
                            id = user.id,
                            FullName = user.FullName,
                            RoleName = user.RoleName,
                            IsUser = user.IsUser,
                            IsEmployee = user.IsEmployee,
                            IsDepartmentManager = user.IsDepartmentManager,
                            IsHRManager = user.IsHRManager,
                            IsAdmin = user.IsAdmin
                        }).ToList();

                        UsersRolesDataGrid.ItemsSource = null;
                        UsersRolesDataGrid.ItemsSource = UsersList;
                        this.IsEnabled = true;
                    }
                
            }
            else
               {
                  

                    UsersList = UsersList2.Select(user => new GetAllUsersResponse
                    {
                        id = user.id,
                        FullName = user.FullName,
                        RoleName = user.RoleName,
                        IsUser = user.IsUser,
                        IsEmployee = user.IsEmployee,
                        IsDepartmentManager = user.IsDepartmentManager,
                        IsHRManager = user.IsHRManager,
                        IsAdmin = user.IsAdmin
                    }).ToList();

                    UsersRolesDataGrid.ItemsSource = null;
                    UsersRolesDataGrid.ItemsSource = UsersList;
                    this.IsEnabled = true;
                }
               

            }
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            this.IsEnabled = false;
            try
            {

                var win = new IndeterminateProgressWindow("Fetching data...");
                win.Show();
                var response = await adminAPIEndpointsDefinitions.GetAllUsers();
                win.Message = "Result is collected..";
                win.Close();


                if (response.IsSuccessStatusCode && response.Content != null && response.Content.Any())
                {
                    UsersList = response.Content;
                    UsersList2 = response.Content.Select(user=> new GetAllUsersResponse
                    {
                        id = user.id,
                        FullName = user.FullName,
                        RoleName = user.RoleName,
                        IsUser = user.IsUser,
                        IsEmployee = user.IsEmployee,
                        IsDepartmentManager = user.IsDepartmentManager,
                        IsHRManager = user.IsHRManager,
                        IsAdmin = user.IsAdmin
                    }).ToList();

                    UsersRolesDataGrid.ItemsSource = UsersList;
                    this.IsEnabled = true;

                }
                else
                {
                    var msgBox2 = new ModernMessageBox($"Non data was found or it didn't successfully connect to the server.",
                                                                  "Operation Information",
                                                                  ModernMessageboxIcons.Error,
                                                                  "OK");
                    msgBox2.ShowDialog();
                    this.IsEnabled = true;
                }

            }
            catch (Exception ex)
            {
                this.IsEnabled = true;
            }
        }

    }



    public class HRPower
    {
        public Guid Id { get; set; }
        public string FullName { get; set; }

       public bool HasFullPower { get; set; }
    }
}
