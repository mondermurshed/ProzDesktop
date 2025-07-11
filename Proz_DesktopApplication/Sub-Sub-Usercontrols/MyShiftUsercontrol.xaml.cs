using System;
using System.Collections.Generic;
using System.Windows.Controls;

namespace Proz_DesktopApplication.Sub_Sub_Usercontrols
{
    public partial class MyShiftInfo : UserControl
    {
        public MyShiftInfo()
        {
            InitializeComponent();
            LoadShiftInfo();
        }

        private void LoadShiftInfo()
        {
            // Example: shift details (fetched from your Shift Table)
            var shift = new ShiftInfo
            {
                ShiftStart = new TimeOnly(8, 0),
                ShiftEnd = new TimeOnly(16, 0),
                TotalHours = 8,
                ShiftType = "Morning"
            };

            // Example: break list (fetched from Break Table)
            var breaks = new List<Break>
            {
                new Break { BreakStart = new TimeOnly(10, 0), BreakEnd = new TimeOnly(10, 15), BreakType = "Tea", Comment = "Morning tea break" },
                new Break { BreakStart = new TimeOnly(12, 30), BreakEnd = new TimeOnly(13, 0), BreakType = "Lunch", Comment = "Lunch time" }
            };

            // Fill UI
            BreaksDataGrid.ItemsSource = breaks;

            ShiftStartTextBox.Text = shift.ShiftStart.ToString("hh\\:mm");
            ShiftEndTextBox.Text = shift.ShiftEnd.ToString("hh\\:mm");
            TotalHoursTextBox.Text = shift.TotalHours.ToString() + " hours";
            ShiftTypeTextBox.Text = shift.ShiftType;
        }
    }

    public class ShiftInfo
    {
        public TimeOnly ShiftStart { get; set; }
        public TimeOnly ShiftEnd { get; set; }
        public int TotalHours { get; set; }
        public string ShiftType { get; set; }

        public TimeOnly BreakStart { get; set; }
        public TimeOnly BreakEnd { get; set; }
        public string BreakType { get; set; }
        public string Comment { get; set; }
    }

    public class Break
    {
        public TimeOnly BreakStart { get; set; }
        public TimeOnly BreakEnd { get; set; }
        public string BreakType { get; set; }
        public string Comment { get; set; }
    }
}
