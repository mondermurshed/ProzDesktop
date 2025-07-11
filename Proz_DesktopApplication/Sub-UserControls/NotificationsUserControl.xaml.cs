using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;

namespace Proz_DesktopApplication.Sub_UserControls
{
    public partial class NotificationsUserControl : UserControl
    {
        public NotificationsUserControl()
        {
            InitializeComponent();
            LoadDaysComboBox();
            LoadPriorityComboBox();
        }

        private void LoadDaysComboBox()
        {
            DaysComboBox.Items.Clear();
            var today = DateTime.Today;

            // Add today and previous 6 days
            for (int i = 0; i < 7; i++)
            {
                var day = today.AddDays(-i).ToString("dddd", CultureInfo.InvariantCulture); // e.g. "Monday"
                DaysComboBox.Items.Add(day);
            }

            DaysComboBox.SelectedIndex = 0; // Select today
        }

        private void LoadPriorityComboBox()
        {
            PriorityComboBox.Items.Clear();
            PriorityComboBox.Items.Add("Display All But New First");
            PriorityComboBox.Items.Add("Display All But Old First");
            PriorityComboBox.Items.Add("Display Low Level Priority Only");
            PriorityComboBox.Items.Add("Display Medium Level Priority Only");
            PriorityComboBox.Items.Add("Display High Level Priority Only");

            PriorityComboBox.SelectedIndex = 0; // Select "Low"
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // Fake data for demonstration
            var notifications = new List<Notification>
            {
                new Notification
                {
                    Title = "Upcoming Shift",
                    Message = "You have a shift tomorrow at 9 AM.",
                    CreatedAt = DateTime.Now.AddHours(-2),
                    SeenAt = null,
                    Type = "Shift Reminder",
                    Priority = "Low"
                },
                new Notification
                {
                    Title = "Manager Review",
                    Message = "Your manager added a new comment to your feedback.",
                    CreatedAt = DateTime.Now.AddDays(-1),
                    SeenAt = DateTime.Now.AddHours(-1),
                    Type = "Feedback",
                    Priority = "Medium"
                },
                new Notification
                {
                    Title = "Final Decision",
                    Message = "Your leave request has been rejected.",
                    CreatedAt = DateTime.Now.AddDays(-2),
                    SeenAt = DateTime.Now,
                    Type = "Leave",
                    Priority = "Hard"
                }
            };

            NotificationsDataGrid.ItemsSource = notifications;
        }

        // Notification model
        public class Notification
        {
            public string Title { get; set; }
            public string Message { get; set; }
            public DateTime CreatedAt { get; set; }
            public DateTime? SeenAt { get; set; }
            public string Type { get; set; }
            public string Priority { get; set; }
        }
    }
}
