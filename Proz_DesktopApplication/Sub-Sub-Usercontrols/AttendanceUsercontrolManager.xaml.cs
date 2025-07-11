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
    /// Interaction logic for AttendanceUsercontrolManager.xaml
    /// </summary>
    public partial class AttendanceUsercontrolManager : UserControl
    {
        public AttendanceUsercontrolManager()
        {
            InitializeComponent();
            LoadMonths();
            LoadFakeData();
        }

        private void LoadMonths()
        {
            var monthNames = System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat.MonthNames
                             .Where(m => !string.IsNullOrEmpty(m))
                             .Select((name, index) => new { Name = name, Number = index + 1 })
                             .ToList();

            MonthFilter.ItemsSource = monthNames;
            MonthFilter.DisplayMemberPath = "Name";
            MonthFilter.SelectedValuePath = "Number";

            int currentMonth = DateTime.Now.Month;
            MonthFilter.SelectedValue = currentMonth;
        }


        private void LoadFakeData()
        {
            var AttendanceRecords = new List<AttendanceClassManager>();

            // Create 3 fake rows with auto-increment ID
            AttendanceRecords.Add(new AttendanceClassManager
            {
                CheckInTime = new TimeOnly(7, 55),
                ShiftTimeStarts = new TimeOnly(8, 0),
                CheckOutTime = new TimeOnly(16, 5),
                ShiftTimeEnds = new TimeOnly(16, 0),
                CheckInStatus = "On Time",
                CheckOutStatus = "On Time",
               
                CreateAt = new DateOnly(2025, 7, 1)
            });

            AttendanceRecords.Add(new AttendanceClassManager
            {
                CheckInTime = new TimeOnly(8, 18),
                ShiftTimeStarts = new TimeOnly(8, 0),
                CheckOutTime = new TimeOnly(16, 3),
                ShiftTimeEnds = new TimeOnly(16, 0),
                CheckInStatus = "Late",
                CheckOutStatus = "On Time",
              
                CreateAt = new DateOnly(2025, 7, 2)
            });

            AttendanceRecords.Add(new AttendanceClassManager
            {
                CheckInTime = new TimeOnly(8, 22),
                ShiftTimeStarts = new TimeOnly(8, 0),
                CheckOutTime = new TimeOnly(15, 45),
                ShiftTimeEnds = new TimeOnly(16, 0),
                CheckInStatus = "Late",
                CheckOutStatus = "Left Early",
             
                CreateAt = new DateOnly(2025, 7, 3)
            });
            AttendanceRecords.Add(new AttendanceClassManager
            {
                CheckInTime = new TimeOnly(7, 59),
                ShiftTimeStarts = new TimeOnly(8, 0),
                CheckOutTime = new TimeOnly(16, 10),
                ShiftTimeEnds = new TimeOnly(16, 0),
                CheckInStatus = "On Time",
                CheckOutStatus = "Overtime",
               
                CreateAt = new DateOnly(2025, 7, 4)
            });
            AttendanceRecords.Add(new AttendanceClassManager
            {
                CheckInTime = new TimeOnly(8, 35),
                ShiftTimeStarts = new TimeOnly(8, 0),
                CheckOutTime = new TimeOnly(15, 30),
                ShiftTimeEnds = new TimeOnly(16, 0),
                CheckInStatus = "Late",
                CheckOutStatus = "Left Early",
              
                CreateAt = new DateOnly(2025, 7, 5)
            });

            // Assign to the DataGrid
            AttendanceDatagrid.ItemsSource = AttendanceRecords;
        }
        private void AttendanceDatagrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (AttendanceDatagrid.SelectedItem is AttendanceClass selected)
            {
                CheckInTimeTextBox.Text = selected.CheckInTime.ToString("hh\\:mm");
                CheckOutTimeTextBox.Text = selected.CheckOutTime.ToString("hh\\:mm");
                ShiftStartTextBox.Text = selected.ShiftTimeStarts.ToString("hh\\:mm");
                ShiftEndTextBox.Text = selected.ShiftTimeEnds.ToString("hh\\:mm");
               
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int currentMonth = DateTime.Now.Month;
            MonthFilter.SelectedValue = currentMonth;
        }
    }


    public class AttendanceClassManager
    {

        public TimeOnly CheckInTime { get; set; }
        public TimeOnly ShiftTimeStarts { get; set; }
        public TimeOnly CheckOutTime { get; set; }
        public TimeOnly ShiftTimeEnds { get; set; }
        public string CheckInStatus { get; set; }
        public string CheckOutStatus { get; set; }
        public DateOnly CreateAt { get; set; }
    }
}
