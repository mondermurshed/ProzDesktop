using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Proz_DesktopApplication.Sub_UserControls
{
    public partial class DepartmentsManagingShifts : UserControl
    {
        public DepartmentsManagingShifts()
        {
            InitializeComponent();
            LoadDepartments();
            LoadDepartmentsWithShifts();
        }



        private List<Department> allDepartments = new List<Department>();
        private List<Department> departmentsWithShifts = new();
        private List<BreakTime> breakTimesForSelected = new();

        private void LoadDepartments()
        {
            // TODO: Replace with API call
            allDepartments = new List<Department>
            {
                new Department {Department_Name = "IT" },
                new Department {Department_Name = "HR" },
                new Department {Department_Name = "Finance" },
                new Department {Department_Name = "Sales" }
            };

            DepartmentsDataGrid.ItemsSource = allDepartments;
        }
        private void LoadDepartmentsWithShifts()
        {
            // TODO: Replace with your real API call
            departmentsWithShifts = new List<Department>
    {
        new Department { Department_Name = "IT"},
        new Department { Department_Name = "Marketing"}
    };

            BreaksDepartmentsDataGrid.ItemsSource = departmentsWithShifts;
        }
        private void DepartmentSearchBox_TextChanged(object sender, TextChangedEventArgs e)
        {
           
            string searchText = DepartmentSearchBox.Text.Trim().ToLower();
            if (searchText.Length != 0)
            {
        

                var filtered = allDepartments
                    .Where(d => d.Department_Name.ToLower().Contains(searchText))
                    .ToList();

                DepartmentsDataGrid.ItemsSource = filtered;
            }
            else
            {
                DepartmentsDataGrid.ItemsSource = allDepartments;
            }
        }
        private void BreaksSearchBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            string searchText = BreaksSearchBox.Text.Trim().ToLower();

            var filtered = departmentsWithShifts
                .Where(d => d.Department_Name.ToLower().Contains(searchText))
                .ToList();

            BreaksDepartmentsDataGrid.ItemsSource = filtered;
        }
        private void BreaksDepartmentsDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (BreaksDepartmentsDataGrid.SelectedItem is not Department selectedDept)
                return;

            // TODO: Load actual breaks from the backend for the selected department.
            // Here’s fake test data:

            breakTimesForSelected = new List<BreakTime>
    {
        new BreakTime
        {
            Id = Guid.NewGuid(), // Generate a new unique ID
            Shift_Type = "Morning",
            ShiftStartEnd =new TimeOnly(22, 4),
            
            ShiftStartTime = new TimeOnly(23, 4),
            Break_Start = new TimeOnly(20, 4),
            Break_End = new TimeOnly(20, 40),
            Break_Type = "Coffee Break",
            Notes = "Quick coffee and rest"
        },
        new BreakTime
        {
              Id = Guid.NewGuid(), // Generate a new unique ID
            Shift_Type = "Evening",
              ShiftStartEnd =new TimeOnly(22, 4),
              
            ShiftStartTime = new TimeOnly(23, 4),
            Break_Start = new TimeOnly(16, 30, 0),
            Break_End = new TimeOnly(16, 45, 0),
            Break_Type = "Prayer Break",
            Notes = "Afternoon prayer time"
        }
    };

            BreaksForSelectedShiftDataGrid.ItemsSource = breakTimesForSelected;
        }

        private void CreateShiftButton_Click(object sender, RoutedEventArgs e)
        {
            //if (DepartmentsDataGrid.SelectedItem is not Department selectedDept)
            //{
            //    MessageBox.Show("Please select a department.");
            //    return;
            //}

            //var startTime = StartTimePicker.Value;
            //var endTime = EndTimePicker.Value;

            //if (startTime == null || endTime == null)
            //{
            //    MessageBox.Show("Please select both start and end times.");
            //    return;
            //}

            //// TODO: Send shift creation request to your API
            //MessageBox.Show($"Shift created for {selectedDept.Department_Name} from {startTime.Value:t} to {endTime.Value:t}");
        }

        private void DeleteMorningButtonHandller(object sender, RoutedEventArgs e)
        {

        }

        private void DeleteEveningButtonHandller(object sender, RoutedEventArgs e)
        {

        }

        private void DeleteBreakButtonHandller(object sender, RoutedEventArgs e)
        {

        }
    }
    public class Department
    {
        public Guid Department_ID { get; set; }
        public string Department_Name { get; set; }
        
    }
    public class BreakTime
    {
        public Guid Id { get; set; } // Unique identifier for the break time
        public string Shift_Type { get; set; } // "Morning" or "Evening"
        public TimeOnly ShiftStartTime { get; set; }
        public TimeOnly ShiftStartEnd { get; set; }
        public TimeOnly Break_Start { get; set; }
        public TimeOnly Break_End { get; set; }
        public string Break_Type { get; set; }
        public string Notes { get; set; }
    }

}
