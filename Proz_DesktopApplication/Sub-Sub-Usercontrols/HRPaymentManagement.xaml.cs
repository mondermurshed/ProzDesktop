using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Proz_DesktopApplication.Sub_Sub_Usercontrols
{
    public partial class HRPaymentManagement : UserControl
    {
        private List<EmployeeSalaryData> allSalaryData;
        private List<EmployeeFinalPaymentData> allFinalData;

        public HRPaymentManagement()
        {
            InitializeComponent();
            LoadDepartments();
            LoadFakeSalaryData();
            LoadFakeFinalData();

            DepartmentComboBox.SelectedIndex = 0;
            ShowOnlyManagerCheckBox.IsChecked = false;
            ShowManagersCheckbox.IsChecked = false;

            RefreshSalaryGrid();
            RefreshFinalGrid();
        }

        private void LoadDepartments()
        {
            // Fake department list
            var departments = new List<string> { "IT", "HR", "Finance", "Logistics" };
            DepartmentComboBox.ItemsSource = departments;
        }

        private void LoadFakeSalaryData()
        {
            allSalaryData = new List<EmployeeSalaryData>
            {
                new EmployeeSalaryData { Id = Guid.NewGuid(), EmployeeName = "Ahmed Saleh", Salary = 500, CompanyBonus = 50, Currency = "USD", IsManager = false },
                new EmployeeSalaryData { Id = Guid.NewGuid(), EmployeeName = "Fatima Ali", Salary = 600, CompanyBonus = 60, Currency = "USD", IsManager = true  },
                new EmployeeSalaryData { Id = Guid.NewGuid(), EmployeeName = "Omar Hussein", Salary = 550, CompanyBonus = 55, Currency = "USD", IsManager = false }
            };
        }

        private void LoadFakeFinalData()
        {
            allFinalData = new List<EmployeeFinalPaymentData>
            {
                new EmployeeFinalPaymentData { Id = Guid.NewGuid(), EmployeeName = "Ahmed Saleh", Salary = 500, PerformanceBonus = 30, Deductions = 10, CompanyBonus = 50, Currency = "USD", IsManager = false },
                new EmployeeFinalPaymentData { Id = Guid.NewGuid(), EmployeeName = "Fatima Ali", Salary = 600, PerformanceBonus = 40, Deductions = 20, CompanyBonus = 60, Currency = "USD", IsManager = true  },
                new EmployeeFinalPaymentData { Id = Guid.NewGuid(), EmployeeName = "Omar Hussein", Salary = 550, PerformanceBonus = 35, Deductions = 15, CompanyBonus = 55, Currency = "USD", IsManager = false }
            };
        }

        private void RefreshSalaryGrid()
        {
            var items = allSalaryData.AsEnumerable();

            if (ShowOnlyManagerCheckBox.IsChecked == true)
                items = items.Where(x => x.IsManager);

            var filter = SearchTextBox.Text;
            if (!string.IsNullOrWhiteSpace(filter))
                items = items.Where(x => x.EmployeeName.IndexOf(filter, StringComparison.OrdinalIgnoreCase) >= 0);

            BaseSalaryGrid.ItemsSource = items.ToList();
        }

        private void RefreshFinalGrid()
        {
            var items = allFinalData.AsEnumerable();

            if (ShowManagersCheckbox.IsChecked == false)
                items = items.Where(x => !x.IsManager);

            FinalPaymentGrid.ItemsSource = items.ToList();
        }

        private void SearchTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            RefreshSalaryGrid();
        }

        private void ShowManagersCheckbox_Checked(object sender, RoutedEventArgs e)
        {
            RefreshFinalGrid();
        }

        private void LoadButton_Click(object sender, RoutedEventArgs e)
        {
            // placeholder for loading from database
        }

        private void CompletedRequestsDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Common selection handler for both grids
            if (sender == BaseSalaryGrid && BaseSalaryGrid.SelectedItem is EmployeeSalaryData sal)
            {
              
                SalaryEditBox.Text = sal.Salary.ToString();
                CompanyBonusEditBox.Text = sal.CompanyBonus.ToString();
            }
            else if (sender == FinalPaymentGrid && FinalPaymentGrid.SelectedItem is EmployeeFinalPaymentData fin)
            {
                FinalSalaryBox.Text = fin.Salary.ToString();
                FinalBonusBox.Text = fin.PerformanceBonus.ToString();
                FinalDeductionBox.Text = fin.Deductions.ToString();
                FinalCompanyBonusBox.Text = fin.CompanyBonus.ToString();
            }
        }

        private void ApplySalaryChange_Click(object sender, RoutedEventArgs e)
        {
            // placeholder for applying salary change to selected employee
        }

        private void ApplyToAllEmployees_Click(object sender, RoutedEventArgs e)
        {
            // placeholder for setting base salary for all employees
        }
        private void ApplyToAllEmployeesCompanyBonus_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ApplyFinalChange_Click(object sender, RoutedEventArgs e)
        {
            // placeholder for applying final payment change
        }

    
    }

    public class EmployeeSalaryData
    {
        public Guid Id { get; set; }
        public string EmployeeName { get; set; }
        public double Salary { get; set; }
        public double CompanyBonus { get; set; }
        public string Currency { get; set; }
        public bool IsManager { get; set; }
    }

    public class EmployeeFinalPaymentData
    {
        public Guid Id { get; set; }
        public string EmployeeName { get; set; }
        public double Salary { get; set; }
        public double PerformanceBonus { get; set; }
        public double Deductions { get; set; }
        public double CompanyBonus { get; set; }
        public string Currency { get; set; }
        public bool IsManager { get; set; }
    }
}
