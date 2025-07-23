
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using ModernMessageBoxLib;

namespace Proz_DesktopApplication.Sub_UserControls
{
    public partial class MyLoginHistoryAdmin : UserControl
    {
        private List<LoginHistory> _allLoginRecords;

        public MyLoginHistoryAdmin()
        {
            InitializeComponent();
            LoadFakeData();
            SetupYearAndMonthComboBoxes();
            DepartmentComboBox.SelectedIndex = 0;
            EmployeeComboBox.SelectedIndex = 0;
        }

        private void LoadFakeData()
        {
            var LoginHistoryRecords = new List<LoginHistory>();

            // Create 3 fake rows with auto-increment ID
            LoginHistoryRecords.Add(new LoginHistory
            {

                WhenLogged = new DateTime(2023, 12, 24, 4, 24, 5),
                IPAddress = "192.168.1.1"
            });

            LoginHistoryRecords.Add(new LoginHistory
            {
                WhenLogged = new DateTime(2023, 12, 24, 4, 24, 5),
                IPAddress = "192.168.1.1"
            });

            LoginHistoryRecords.Add(new LoginHistory
            {
                WhenLogged = new DateTime(2023, 12, 24, 4, 24, 5),
                IPAddress = "192.168.1.1"
            });
            LoginHistoryRecords.Add(new LoginHistory
            {
                WhenLogged = new DateTime(2023, 12, 24, 4, 24, 5),
                IPAddress = "192.168.1.1"
            });
            LoginHistoryRecords.Add(new LoginHistory
            {
                WhenLogged = new DateTime(2023, 12, 24, 4, 24, 5),
                IPAddress = "192.168.1.1"
            });
            LoginHistoryRecords.Add(new LoginHistory
            {
                WhenLogged = new DateTime(2023, 12, 24, 4, 24, 5),
                IPAddress = "192.168.1.1"
            });
            LoginHistoryRecords.Add(new LoginHistory
            {
                WhenLogged = new DateTime(2023, 12, 24, 4, 24, 5),
                IPAddress = "192.168.1.1"
            });
            LoginHistoryRecords.Add(new LoginHistory
            {
                WhenLogged = new DateTime(2023, 12, 24, 4, 24, 5),
                IPAddress = "192.168.1.1"
            });
            LoginHistoryRecords.Add(new LoginHistory
            {
                WhenLogged = new DateTime(2023, 12, 24, 4, 24, 5),
                IPAddress = "192.168.1.1"
            });
            LoginHistoryRecords.Add(new LoginHistory
            {
                WhenLogged = new DateTime(2023, 12, 24, 4, 24, 5),
                IPAddress = "192.168.1.1"
            });
            LoginHistoryRecords.Add(new LoginHistory
            {
                WhenLogged = new DateTime(2023, 12, 24, 4, 24, 5),
                IPAddress = "192.168.1.1"
            });
            LoginHistoryRecords.Add(new LoginHistory
            {
                WhenLogged = new DateTime(2023, 12, 24, 4, 24, 5),
                IPAddress = "192.168.1.1"

            });
            LoginHistoryRecords.Add(new LoginHistory
            {
                WhenLogged = new DateTime(2023, 12, 24, 4, 24, 5),
                IPAddress = "192.168.1.1"

            });
            LoginHistoryRecords.Add(new LoginHistory
            {
                WhenLogged = new DateTime(2023, 12, 24, 4, 24, 5),
                IPAddress = "192.168.1.1"

            });
            LoginHistoryRecords.Add(new LoginHistory
            {
                WhenLogged = new DateTime(2023, 12, 24, 4, 24, 5),
                IPAddress = "192.168.1.1"

            });


            // Assign to the DataGrid
            AdminLoginDataGrid.ItemsSource = LoginHistoryRecords;
        }

        private void SetupYearAndMonthComboBoxes()
        {
            int currentYear = DateTime.Now.Year;
            int currentMonth = DateTime.Now.Month;

            // Clear previous items
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

            // Select current year by default
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var records = AdminLoginDataGrid.ItemsSource as List<LoginHistory>;

            if (records == null || records.Count == 0)
                return;

            string firstIP = records[0].IPAddress;

            var different = records.FirstOrDefault(x => x.IPAddress != firstIP);

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
            var records = AdminLoginDataGridEmployees.ItemsSource as List<LoginHistory>;

            if (records == null || records.Count == 0)
                return;

            string firstIP = records[0].IPAddress;

            var different = records.FirstOrDefault(x => x.IPAddress != firstIP);

            if (different != null)
            {
                AdminLoginDataGridEmployees.SelectedItem = different;
                AdminLoginDataGridEmployees.ScrollIntoView(different); // Optional: Scroll to it
            }
            else
            {

                var msgBox1 = new ModernMessageBox($"No different IP address was found.", "The result of the searching operation",

                ModernMessageboxIcons.None,
                "OK");
                msgBox1.ShowDialog();

            }
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

        private void DepartmentComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void EmployeeComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
    public class LoginHistory
    {
        public DateTime WhenLogged { get; set; }
        public string IPAddress { get; set; }
    }
}
