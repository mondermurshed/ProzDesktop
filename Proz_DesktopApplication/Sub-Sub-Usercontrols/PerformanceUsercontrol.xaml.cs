using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Proz_DesktopApplication.Sub_Sub_Usercontrols
{
    public partial class PerformanceUsercontrol : UserControl
    {
        private List<PerformanceRecord> allRecords;

        public PerformanceUsercontrol()
        {
            InitializeComponent();
            LoadMonths();
            LoadFakePerformanceData();
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

        private void LoadFakePerformanceData()
        {
            allRecords = new List<PerformanceRecord>
            {
                new PerformanceRecord { Date = new DateOnly(2025, 7, 1), Evaluator = "Mr. Khaled", Score = 1, Status = "Excellent", Comment = "Exceeded expectations in all tasks." },
                new PerformanceRecord { Date = new DateOnly(2025, 7, 5), Evaluator = "Mr. Khaled", Score = 0, Status = "Normal", Comment = "Met most objectives but needs to improve consistency." },
                new PerformanceRecord { Date = new DateOnly(2025, 7, 10), Evaluator = "Mr. Khaled", Score = 0, Status = "Normal", Comment = "Performance declined due to missed deadlines." }
            };

            FilterPerformanceByMonth();
        }

        private void FilterPerformanceByMonth()
        {
            if (MonthFilter.SelectedValue is int month)
            {
                var filtered = allRecords.Where(p => p.Date.Month == month).ToList();
                PerformanceDatagrid.ItemsSource = filtered;
            }
        }

        private void PerformanceDatagrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (PerformanceDatagrid.SelectedItem is PerformanceRecord selected)
            {
                EvaluatorTextBox.Text = selected.Evaluator;
                CommentTextBox.Text = selected.Comment;
            }
        }

        private void ResetMonthButton_Click(object sender, RoutedEventArgs e)
        {
            MonthFilter.SelectedValue = DateTime.Now.Month;
        }
    }

    public class PerformanceRecord
    {
        public PerformanceRecord()
        {
            Status = ScoreConverter(Score);
        }
        public DateOnly Date { get; set; }
        public string Evaluator { get; set; } //المقيم
        public int Score { get; set; }
        public string Comment { get; set; }
        public string Status { get; set; }

        public string ScoreConverter(int score)
        {
            if (score == -1)
                return "Bad";
            else if (score == 1)
                return "Excellent";
            else
                return "Normal";
            
        }
     
            
    }
}
