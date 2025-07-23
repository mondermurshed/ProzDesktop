using System.Windows;
using System.Windows.Controls;

namespace Proz_DesktopApplication.Sub_UserControls
{
    public partial class DepartmentCreationUsercontrol : UserControl
    {
        public DepartmentCreationUsercontrol()
        {
            InitializeComponent();
            // Later: Load data from API here
        }

        private void CreateDepartmentButton_Click(object sender, RoutedEventArgs e)
        {
            string deptName = DepartmentNameTextBox.Text.Trim();
            string email = ManagerEmailTextBox.Text.Trim();

            // TODO: Call your API to create department and assign manager
        }

        private void UnassignManagerButton_Click(object sender, RoutedEventArgs e)
        {
            if (DepartmentsWithManagerDataGrid.SelectedItem == null)
                return;

            // TODO: Call your API to unassign the manager from the selected department
        }

        private void AssignManagerButton_Click(object sender, RoutedEventArgs e)
        {
            if (DepartmentsWithoutManagerDataGrid.SelectedItem == null)
                return;

            string email = AssignManagerEmailTextBox.Text.Trim();

            // TODO: Call your API to assign the manager to the selected department
        }

        private void DeleteDepartment(object sender, RoutedEventArgs e)
        {

        }
    }
}
