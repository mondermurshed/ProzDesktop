using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Proz_DesktopApplication.Sub_Sub_Sub_Usercontrols
{
    public partial class CompletedPaymentsUsercontrolManager : UserControl
    {
        private List<CompletedPaymentRecordManager> allPayments;

        public CompletedPaymentsUsercontrolManager()
        {
            InitializeComponent();
            LoadSubDepartments();
            LoadYears();
            LoadFakePayments();
            SubDepartmentComboBox.SelectedIndex = 0;
        }

        private void LoadSubDepartments()
        {
            var departments = new List<string> { "Accounting", "Support", "Networking" };
            SubDepartmentComboBox.ItemsSource = departments;
        }

        private void LoadYears()
        {
            int currentYear = DateTime.Now.Year;
            var years = Enumerable.Range(currentYear - 3, 4).ToList();
            YearFilter.ItemsSource = years;
            YearFilter.SelectedItem = currentYear;
        }

        private void LoadFakePayments()
        {
            allPayments = new List<CompletedPaymentRecordManager>
            {
                new CompletedPaymentRecordManager
                {
                    PaymentPeriodStart = new DateOnly(2025, 6, 1),
                    PaymentPeriodEnd = new DateOnly(2025, 6, 30),
                    BaseSalary = 150000,
                    CompanyBonus = 5000,
                    PerformanceBonus = 10000,
                    Deductions = 2000,
                    CurrencyType = "YER",
                    FinalAmount = "163,000 YER",
                    Status = "Paid"
                },
                new CompletedPaymentRecordManager
                {
                    PaymentPeriodStart = new DateOnly(2024, 12, 1),
                    PaymentPeriodEnd = new DateOnly(2024, 12, 31),
                    BaseSalary = 145000,
                    CompanyBonus = 0,
                    PerformanceBonus = 5000,
                    Deductions = 3000,
                    CurrencyType = "YER",
                    FinalAmount = "147,000 YER",
                    Status = "Unpaid"
                },
                new CompletedPaymentRecordManager
                {
                    PaymentPeriodStart = new DateOnly(2023, 11, 1),
                    PaymentPeriodEnd = new DateOnly(2023, 11, 30),
                    BaseSalary = 140000,
                    CompanyBonus = 0,
                    PerformanceBonus = 0,
                    Deductions = 0,
                    CurrencyType = "YER",
                    FinalAmount = "140,000 YER",
                    Status = "Paid"
                }
            };

            FilterAndDisplayPayments();
        }

        private void FilterAndDisplayPayments()
        {
            var selectedYear = (int?)YearFilter.SelectedItem;
            if (selectedYear == null) return;

            var filtered = allPayments
                .Where(p => p.PaymentPeriodStart.Year == selectedYear)
                .Where(p => OnlyPaidCheckbox.IsChecked != true || p.Status == "Unpaid")
                .ToList();

            CompletedPaymentsDataGrid.ItemsSource = filtered;
        }

        private void GetButton_Click(object sender, RoutedEventArgs e)
        {
            if (SubDepartmentComboBox.SelectedItem == null)
            {
                MessageBox.Show("Please select a sub-department.", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            FilterAndDisplayPayments();
        }

        private void ReloadButton_Click(object sender, RoutedEventArgs e)
        {
            FilterAndDisplayPayments();
        }

        private void ResetYearButton_Click(object sender, RoutedEventArgs e)
        {
            YearFilter.SelectedItem = DateTime.Now.Year;
        }

        private void CompletedPaymentsDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Future use
        }
    }

    public class CompletedPaymentRecordManager
    {
        public DateOnly PaymentPeriodStart { get; set; }
        public DateOnly PaymentPeriodEnd { get; set; }
        public double BaseSalary { get; set; }
        public double CompanyBonus { get; set; }
        public double PerformanceBonus { get; set; }
        public double Deductions { get; set; }
        public string CurrencyType { get; set; }
        public string FinalAmount { get; set; }
        public string Status { get; set; }
    }
}
