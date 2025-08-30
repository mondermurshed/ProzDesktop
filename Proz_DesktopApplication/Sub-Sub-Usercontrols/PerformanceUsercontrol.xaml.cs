using ModernMessageBoxLib;
using Proz_DesktopApplication.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Proz_DesktopApplication.Sub_Sub_Usercontrols
{
    public partial class PerformanceUsercontrol : BaseUserControlMain
    {
        private List<ReturnPerformanceRecordsEmployeeResponse> allRecords;
        public EmployeeAPIEndpointsDefinitions employeeAPIEndpointsDefinitions;

        public PerformanceUsercontrol()
        {
            InitializeComponent();
            SetupMonthComboBoxe();
            Loaded += UserControl_Loaded;
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
           
            employeeAPIEndpointsDefinitions = _EmployeeAPIEndpointsDefinitions1 ?? throw new InvalidOperationException("Services1 is null");
            //TillDatePicker.IsEnabled = false;
            //FromDatePicker.DisplayDateStart = DateTime.Today.AddDays(1);
            //FromDatePicker.DisplayDateEnd = DateTime.Today.AddDays(30);

        }

        private void SetupMonthComboBoxe()
        {
            int currentYear = DateTime.Now.Year;
            int currentMonth = DateTime.Now.Month;


            MonthFilter.Items.Clear();
          
            for (int month = 1; month <= currentMonth; month++)
            {
                string monthName = new DateTime(currentYear, month, 1).ToString("MMMM");

                MonthFilter.Items.Add(new ComboBoxItem
                {
                    Content = monthName,
                    Tag = month
                });
           
            }

           
            MonthFilter.SelectedIndex = currentMonth - 1;
         
        }

     

       

     

        private void PerformanceDatagrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (PerformanceDatagrid.SelectedItem is ReturnPerformanceRecordsEmployeeResponse selected)
            {
              
                CommentTextBox.Text = selected.ReviewerComment;
            }
        }

        private void ResetMonthButton_Click(object sender, RoutedEventArgs e)
        {
            int currentMonth = DateTime.Now.Month;
            MonthFilter.SelectedIndex = currentMonth - 1;
        }

        private async void GetPerformanceRecords(object sender, RoutedEventArgs e)
        {
            if (MonthFilter.SelectedItem == null)
            {
                var msgBox2 = new ModernMessageBox($"Please select a month.",
                                                                                "Operation Information",
                                                                                ModernMessageboxIcons.Error,
                                                                                "OK");
                msgBox2.ShowDialog();
                return;
            }

            this.IsEnabled = false;
            try
            {
                CommentTextBox.Clear();
                var selectedItem = MonthFilter.SelectedItem as ComboBoxItem;
                var request = new ReturnPerformanceRecordsListRequest
                {
                    Month = (int)selectedItem.Tag
                };
                var win = new IndeterminateProgressWindow("Fetching the data...");
                win.Show();
                var response = await employeeAPIEndpointsDefinitions.GetMyPerformanceRecords(request);
                win.Message = "Result is collected..";
                win.Close();


                if (response.IsSuccessStatusCode && response.Content != null && response.Content.Any())
                {
                    allRecords = response.Content;

                    PerformanceDatagrid.ItemsSource = null;
                    PerformanceDatagrid.ItemsSource = allRecords;

                    this.IsEnabled = true;

                }
                else
                {
                    var msgBox2 = new ModernMessageBox($"No data was found or it didn't successfully connect to the server.",
                                                                  "Operation Information",
                                                                  ModernMessageboxIcons.Error,
                                                                  "OK");
                    msgBox2.ShowDialog();
                    PerformanceDatagrid.ItemsSource = null;
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
