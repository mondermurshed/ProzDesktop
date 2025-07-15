using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

namespace Proz_DesktopApplication.Sub_Sub_Usercontrols
{
    /// <summary>
    /// Interaction logic for ManageDepartmentsInformationHRManager.xaml
    /// </summary>
    public partial class ManageDepartmentsInformationHRManager : UserControl
    {
        private List<DepartmentViewModel> allDepartments;

        public ManageDepartmentsInformationHRManager()
        {
            InitializeComponent();
            LoadFakeDepartments(); // Replace with API/data call later
        }
        private void LoadFakeDepartments()
        {
           allDepartments = new List<DepartmentViewModel>
            {
                new DepartmentViewModel { Id = Guid.NewGuid(), Name = "IT" , ManagerName="Mohammed", Currency="USD", DefaultSalary = 800 },
                new DepartmentViewModel { Id = Guid.NewGuid(), Name = "Finance" , ManagerName="Yousuuf", Currency="USD",DefaultSalary = 900 },
                new DepartmentViewModel { Id = Guid.NewGuid(), Name = "Logistics" , ManagerName="Khalid", Currency="USD", DefaultSalary = 700 },
                new DepartmentViewModel { Id = Guid.NewGuid(), Name = "HR", ManagerName="Ahmed", Currency="USD", DefaultSalary = 1000 }
            };

            DepartmentsDataGrid.ItemsSource = allDepartments;
        }

        private void SearchTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            string search = SearchTextBox.Text.Trim().ToLower();

            var filtered = allDepartments
                .Where(d => d.Name.ToLower().Contains(search))
                .ToList();

            DepartmentsDataGrid.ItemsSource = filtered;
        }

        private void UpdateSalary_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button btn && btn.Tag is DepartmentViewModel dept)
            {
                // In real app, call API or update DB here
                MessageBox.Show($"Updated default salary for {dept.Name} to {dept.DefaultSalary:C}");
            }
        }
    }
    public class DepartmentViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string ManagerName { get; set; }
        public decimal DefaultSalary { get; set; }
        public string Currency {  get; set; }
    }
}
