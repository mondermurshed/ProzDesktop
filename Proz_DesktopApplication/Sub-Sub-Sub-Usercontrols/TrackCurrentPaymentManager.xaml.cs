using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace Proz_DesktopApplication.Sub_Sub_Sub_Usercontrols
{
    public partial class TrackCurrentPaymentManager : UserControl
    {
        public TrackCurrentPaymentManager()
        {
            InitializeComponent();
            LoadSubDepartments();
            SubDepartmentComboBox.SelectedIndex = 0;
        }

        private void LoadSubDepartments()
        {
            // Dummy sub-departments (replace with real ones from DB)
            var departments = new List<string> { "IT Support", "Accounting", "Sales" };
            SubDepartmentComboBox.ItemsSource = departments;
        }

        private void SubDepartments_Click(object sender, RoutedEventArgs e)
        {
            string selectedDept = SubDepartmentComboBox.SelectedItem as string;
            if (string.IsNullOrWhiteSpace(selectedDept))
            {
                MessageBox.Show("Please select a sub-department first.", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // Dummy data to simulate filtering based on department
            LoadCurrentPayment(department: selectedDept);
        }

        private void LoadCurrentPayment(string department)
        {
            // These values should be dynamically loaded per department
            PeriodStartTextBox.Text = "2025/07/01";
            PeriodEndTextBox.Text = "2025/07/31";
            BaseSalaryTextBox.Text = "150,000 YER";
            CompanyBonusTextBox.Text = "5,000 YER";
            PerformanceBonusTextBox.Text = "10,000 YER";
            DeductionsTextBox.Text = "2,000 YER";
            FinalAmountTextBox.Text = "163,000 YER";
        }
    }
}
