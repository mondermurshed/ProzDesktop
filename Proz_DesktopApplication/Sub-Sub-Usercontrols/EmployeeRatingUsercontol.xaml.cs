using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace Proz_DesktopApplication.Sub_Sub_Usercontrols
{
    public partial class EmployeeRatingUsercontrol : UserControl
    {
        private List<EmployeeRecord> departmentEmployees;
        private EmployeeRecord selectedEmployee;

        public EmployeeRatingUsercontrol()
        {
            InitializeComponent();
            LoadFakeEmployees();
        }

        private void LoadFakeEmployees()
        {
            departmentEmployees = new List<EmployeeRecord>
            {
                new EmployeeRecord { FirstName = "Ahmed", LastName = "Saleh", rating=-1, RatingMessage="Very bad!!!!!" },
                new EmployeeRecord { FirstName = "Fatima", LastName = "Ali", rating=1, RatingMessage="Today he deserves this!" },
                new EmployeeRecord { FirstName = "Yasir", LastName = "Nabil", rating=0, RatingMessage=null},
            };

            foreach (var emp in departmentEmployees)
                emp.FullName = emp.FirstName + " " + emp.LastName;

            EmployeesDataGrid.ItemsSource = departmentEmployees;
        }

        private void EmployeesDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (EmployeesDataGrid.SelectedItem is EmployeeRecord selected)
            {

                PerformanceSlider.Value = 0;
                CommentTextbox.Clear();
                TargetTextbox.Text = selected.FullName;
                if (selected.rating == 1)
                    PerformanceSlider.Value = 1;
                else if (selected.rating == -1)
                    PerformanceSlider.Value = -1;
                else
                    PerformanceSlider.Value = 0;

                if (selected.RatingMessage != null)
                {
                    CommentTextbox.Text = selected.RatingMessage;
                }
            }
        }

        private void SubmitRatingButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }

    public class EmployeeRecord
    {

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get; set; }

        public int rating { get; set; }
        public string RatingMessage { get; set; }
    }
}
