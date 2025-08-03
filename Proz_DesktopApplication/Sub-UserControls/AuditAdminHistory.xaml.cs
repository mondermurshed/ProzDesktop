using ModernMessageBoxLib;
using Proz_DesktopApplication.API;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace Proz_DesktopApplication.Sub_UserControls
{
    public partial class AuditAdminHistory : BaseUserControlMain
    {
       
        public List<ReturnAllManagersAndAdmins> GetAllManagersAndAdminsDatagrid { get; set; } = new();
        public List<GetLogsForAPersonResponse> GetLogsType { get; set; } = new();
        public AdminAPIEndpointsDefinitions adminAPIEndpointsDefinitions;

        public AuditAdminHistory()
        {
            InitializeComponent();
            Loaded += OnCreatingThisUsercontrol;
        }

        private async void OnCreatingThisUsercontrol(object sender, RoutedEventArgs e)
        {
            adminAPIEndpointsDefinitions = _AdminAPIEndpointsDefinitions1 ?? throw new InvalidOperationException("Services1 is null");


        }


        private async void RefreshManagersAndAdmins(object sender, RoutedEventArgs e)
        {

            this.IsEnabled = false;
            try
            {



                var win = new IndeterminateProgressWindow("Fetching the data...");
                win.Show();
                var response = await adminAPIEndpointsDefinitions.GetAllManagersAndAdmins();
                win.Message = "Result is collected..";
                win.Close();


                if (response.IsSuccessStatusCode && response.Content != null && response.Content.Any())
                {
                    GetAllManagersAndAdminsDatagrid = response.Content;

                    ManagerAndAdminsShowingDatagrid.ItemsSource = null;
                    ManagerAndAdminsShowingDatagrid.ItemsSource = GetAllManagersAndAdminsDatagrid;

                    this.IsEnabled = true;

                }
                else
                {
                    var msgBox2 = new ModernMessageBox($"No data was found or it didn't successfully connect to the server.",
                                                                  "Operation Information",
                                                                  ModernMessageboxIcons.Error,
                                                                  "OK");
                    msgBox2.ShowDialog();
                    ManagerAndAdminsShowingDatagrid.ItemsSource = null;
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

    
        private async void ManagerAndAdminsShowingDatagrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ManagerAndAdminsShowingDatagrid.SelectedItem == null)
            {
                AuditAdminDataGrid.ItemsSource = null;
                return;
            }
            this.IsEnabled = false;
            try
            {
                var selected = ManagerAndAdminsShowingDatagrid.SelectedItem as ReturnAllManagersAndAdmins;

                var request = new GetLogsForAPersonRequest
                {
                    TargetID = selected.ID
                };
                var win = new IndeterminateProgressWindow("Fetching the data...");
                win.Show();
                var response = await adminAPIEndpointsDefinitions.GetLogs(request);
                win.Message = "Result is collected..";
                win.Close();


                if (response.IsSuccessStatusCode && response.Content != null && response.Content.Any())
                {
                    GetLogsType = response.Content;

                    AuditAdminDataGrid.ItemsSource = null;
                    AuditAdminDataGrid.ItemsSource = GetLogsType;

                    this.IsEnabled = true;

                }
                else
                {
                    var msgBox2 = new ModernMessageBox($"No data was found or it didn't successfully connect to the server.",
                                                                  "Operation Information",
                                                                  ModernMessageboxIcons.Error,
                                                                  "OK");
                    msgBox2.ShowDialog();
                    AuditAdminDataGrid.ItemsSource = null;
                    this.IsEnabled = true;
                }

            }
            catch (Exception ex)
            {
                var msgBox2 = new ModernMessageBox($"Frontend Bug or it didn't successfully connect to the server.",
                                                               "Operation Information",
                                                               ModernMessageboxIcons.Error,
                                                               "OK");
                msgBox2.ShowDialog();
                this.IsEnabled = true;
            }
        }

      
    }
}
