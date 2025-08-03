
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using ModernMessageBoxLib;
using Proz_DesktopApplication.API;

namespace Proz_DesktopApplication.Sub_UserControls
{
    public partial class MyLoginHistoryAdmin : BaseUserControlMain
    {
        //
        public List<ReturnAllManagers> GetAllManagersDatagrid { get; set; } = new();
        public List<ReturnLoginHistoryForMyselfResponse> myyselfLoginHistory { get; set; } = new();
        public List<ReturnLoginHistoryForManagerResponse> managerLoginHistory { get; set; } = new();
        public AdminAPIEndpointsDefinitions adminAPIEndpointsDefinitions;
        public MyLoginHistoryAdmin()
        {
            InitializeComponent();
            SetupYearAndMonthComboBoxes();
            //DepartmentComboBox.SelectedIndex = 0;
            //EmployeeComboBox.SelectedIndex = 0;
            Loaded += OnCreatingThisUsercontrol;
        }


        private async void OnCreatingThisUsercontrol(object sender, RoutedEventArgs e)
        {
            adminAPIEndpointsDefinitions = _AdminAPIEndpointsDefinitions1 ?? throw new InvalidOperationException("Services1 is null");


        }
      

        private void SetupYearAndMonthComboBoxes()
        {
            int currentYear = DateTime.Now.Year;
            int currentMonth = DateTime.Now.Month;

            
            YearComboBox.Items.Clear();
            MonthComboBox.Items.Clear();
            YearComboBoxEmployees.Items.Clear();
            MonthComboBoxEmployees.Items.Clear();
            // Add years: current year down to 4 years before
            for (int year = currentYear; year >= currentYear - 4; year--)
            {
                YearComboBox.Items.Add(year.ToString());
                YearComboBoxEmployees.Items.Add(year.ToString());
            }

          
            YearComboBox.SelectedItem = currentYear.ToString();
            YearComboBoxEmployees.SelectedItem = currentYear.ToString();
            // Add months: from January to current month
            for (int month = 1; month <= currentMonth; month++)
            {
                string monthName = new DateTime(currentYear, month, 1).ToString("MMMM");
                
                MonthComboBox.Items.Add(new ComboBoxItem
                {
                    Content = monthName,
                    Tag = month
                });
                MonthComboBoxEmployees.Items.Add(new ComboBoxItem
                {
                    Content = monthName,
                    Tag = month
                });
            }

            // Select current month by default
            MonthComboBox.SelectedIndex = currentMonth - 1;
            MonthComboBoxEmployees.SelectedIndex = currentMonth - 1;
        }

        private void FindDifferentRecordFirstTAB(object sender, RoutedEventArgs e)
        {
            var records = AdminLoginDataGrid.ItemsSource as List<ReturnLoginHistoryForMyselfResponse>;

            if (records == null || records.Count == 0)
                return;

            string firstDeviceID = records[0].DeviceTokenHashed;

            var different = records.FirstOrDefault(x => x.DeviceTokenHashed != firstDeviceID);

            if (different != null)
            {
                AdminLoginDataGrid.SelectedItem = different;
                AdminLoginDataGrid.ScrollIntoView(different); // Optional: Scroll to it
            }
            else
            {

                var msgBox1 = new ModernMessageBox($"No different IP address was found.", "The result of the searching operation",

                ModernMessageboxIcons.None,
                "OK");
                msgBox1.ShowDialog();

            }


        }

        private void Button_Click_Employees(object sender, RoutedEventArgs e)
        {
            //    var records = AdminLoginDataGridEmployees.ItemsSource as List<LoginHistory>;

            //    if (records == null || records.Count == 0)
            //        return;

            //    string firstIP = records[0].IPAddress;

            //    var different = records.FirstOrDefault(x => x.IPAddress != firstIP);

            //    if (different != null)
            //    {
            //        AdminLoginDataGridEmployees.SelectedItem = different;
            //        AdminLoginDataGridEmployees.ScrollIntoView(different); // Optional: Scroll to it
            //    }
            //    else
            //    {

            //        var msgBox1 = new ModernMessageBox($"No different IP address was found.", "The result of the searching operation",

            //        ModernMessageboxIcons.None,
            //        "OK");
            //        msgBox1.ShowDialog();

            //    }
        }

        private void YearComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void MonthComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void SortOrderComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void YearComboBoxEmployees_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void MonthComboBoxEmployees_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void SortOrderComboBoxEmployees_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }




        private async void refreshdataMyself(object sender, RoutedEventArgs e)
        {


            this.IsEnabled = false;
            try
            {
                var selectedSortMethod = SortOrderComboBox.SelectedItem as ComboBoxItem;
                bool sortMethod = true;

                if (selectedSortMethod != null && bool.TryParse(selectedSortMethod.Tag?.ToString(), out bool parsed))
                {
                    sortMethod = parsed;
                }

                var selectedItem = MonthComboBox.SelectedItem as ComboBoxItem;
                var request = new ReturnLoginHistoryForMyselfRequest() { Year=Convert.ToInt32( YearComboBox.SelectedValue), Month= Convert.ToInt32( selectedItem.Tag), ReturnItAs= sortMethod };
                var win = new IndeterminateProgressWindow("Fetching the data...");
                win.Show();
                var response = await adminAPIEndpointsDefinitions.GetLoginHistoryOfMine(request);
                win.Message = "Result is collected..";
                win.Close();


                if (response.IsSuccessStatusCode && response.Content != null && response.Content.Any())
                {
                    myyselfLoginHistory = response.Content;

                    AdminLoginDataGrid.ItemsSource = null;
                    AdminLoginDataGrid.ItemsSource = myyselfLoginHistory;
                
                    this.IsEnabled = true;

                }
                else
                {
                    var msgBox2 = new ModernMessageBox($"No data was found or it didn't successfully connect to the server.",
                                                                  "Operation Information",
                                                                  ModernMessageboxIcons.Error,
                                                                  "OK");
                    msgBox2.ShowDialog();
                    AdminLoginDataGrid.ItemsSource = null;
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

        private async void RefreshDataSecondTab(object sender, RoutedEventArgs e)
        {
        
            try
            {

                if(ManagerShowingDatagrid.SelectedItems.Count!=1)
                {
                    var msgBox2 = new ModernMessageBox($"Select a manager so you can see its login history.",
                                                                                     "Operation Information",
                                                                                     ModernMessageboxIcons.Error,
                                                                                     "OK");
                    msgBox2.ShowDialog();
                    AdminLoginDataGridEmployees.ItemsSource = null;
                    this.IsEnabled = true;
                    return;
                }
                var selectedSortMethod = SortOrderComboBoxEmployees.SelectedItem as ComboBoxItem;
                bool sortMethod = true;

                if (selectedSortMethod != null && bool.TryParse(selectedSortMethod.Tag?.ToString(), out bool parsed))
                {
                    sortMethod = parsed;
                }
              
                var selectedItem = MonthComboBoxEmployees.SelectedItem as ComboBoxItem;
                var ManagerRow = ManagerShowingDatagrid.SelectedItem as ReturnAllManagers;

                var request = new ReturnLoginHistoryForManagerRequest() { Year = Convert.ToInt32(YearComboBoxEmployees.SelectedValue), Month = Convert.ToInt32(selectedItem.Tag), ReturnItAs = sortMethod,ID= ManagerRow.ID };
                var win = new IndeterminateProgressWindow("Fetching the data...");
                win.Show();
                var response = await adminAPIEndpointsDefinitions.GetLoginHistoryOfManager(request);
                win.Message = "Result is collected..";
                win.Close();


                if (response.IsSuccessStatusCode && response.Content != null && response.Content.Any())
                {
                    managerLoginHistory = response.Content;

                    AdminLoginDataGridEmployees.ItemsSource = null;
                    AdminLoginDataGridEmployees.ItemsSource = managerLoginHistory;

                    this.IsEnabled = true;

                }
                else
                {
                    var msgBox2 = new ModernMessageBox($"No data was found or it didn't successfully connect to the server.",
                                                                  "Operation Information",
                                                                  ModernMessageboxIcons.Error,
                                                                  "OK");
                    msgBox2.ShowDialog();
                    AdminLoginDataGridEmployees.ItemsSource = null;
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

        private async void RefreshManagersSecondTab(object sender, RoutedEventArgs e)
        {


            this.IsEnabled = false;
            try
            {
           
             
              
                var win = new IndeterminateProgressWindow("Fetching the data...");
                win.Show();
                var response = await adminAPIEndpointsDefinitions.GetAllManagers();
                win.Message = "Result is collected..";
                win.Close();


                if (response.IsSuccessStatusCode && response.Content != null && response.Content.Any())
                {
                    GetAllManagersDatagrid = response.Content;

                    ManagerShowingDatagrid.ItemsSource = null;
                    ManagerShowingDatagrid.ItemsSource = GetAllManagersDatagrid;

                    this.IsEnabled = true;

                }
                else
                {
                    var msgBox2 = new ModernMessageBox($"No data was found or it didn't successfully connect to the server.",
                                                                  "Operation Information",
                                                                  ModernMessageboxIcons.Error,
                                                                  "OK");
                    msgBox2.ShowDialog();
                    ManagerShowingDatagrid.ItemsSource = null;
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
    }
    
}
//ReturnLoginHistoryForMyselfRequest