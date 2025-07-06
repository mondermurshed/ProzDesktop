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
    /// Interaction logic for AnswersToMyLeaveRequests.xaml
    /// </summary>
    public partial class AnswersToMyLeaveRequests : UserControl
    {
        public AnswersToMyLeaveRequests()
        {
            InitializeComponent();
            LoadFakeData();
        }

        private void LoadFakeData()
        {
            var Answers = new List<LeaveRequestsAnswer>();

            // Create 3 fake rows with auto-increment ID
            Answers.Add(new LeaveRequestsAnswer
            {
                Id = Guid.NewGuid(),
                Start = new DateOnly(2025, 7, 1),     // Example start date
                End = new DateOnly(2025, 7, 5),       // Example end date
                CreatedAt = DateTime.Now,
                FinalStatus = "Pending"
            });

            Answers.Add(new LeaveRequestsAnswer
            {
                Id = Guid.NewGuid(),
                Start = new DateOnly(2025, 7, 1),     // Example start date
                End = new DateOnly(2025, 7, 5),       // Example end date
                CreatedAt = DateTime.Now,
                FinalStatus = "Pending"
            });

            Answers.Add(new LeaveRequestsAnswer
            {
                Id = Guid.NewGuid(),
                Start = new DateOnly(2025, 7, 1),     // Example start date
                End = new DateOnly(2025, 7, 5),       // Example end date
                CreatedAt = DateTime.Now,
                FinalStatus = "Pending"
            });
            Answers.Add(new LeaveRequestsAnswer
            {
                Id = Guid.NewGuid(),
                Start = new DateOnly(2025, 7, 2),     // Example start date
                End = new DateOnly(2025, 7, 6),       // Example end date
                CreatedAt = DateTime.Now,
                FinalStatus = "Pending"
            });
            Answers.Add(new LeaveRequestsAnswer
            {
                Id = Guid.NewGuid(),
                Start = new DateOnly(2025, 7, 8),     // Example start date
                End = new DateOnly(2025, 7, 10),       // Example end date
                CreatedAt = DateTime.Now,
                FinalStatus = "Pending"
            });
            Answers.Add(new LeaveRequestsAnswer
            {
                Id = Guid.NewGuid(),
                Start = new DateOnly(2025, 7, 9),     // Example start date
                End = new DateOnly(2025, 7, 10),       // Example end date
                CreatedAt = DateTime.Now,
                FinalStatus = "Approved"
            });
            Answers.Add(new LeaveRequestsAnswer
            {
                Id = Guid.NewGuid(),
                Start = new DateOnly(2025, 7, 2),     // Example start date
                End = new DateOnly(2025, 7, 4),       // Example end date
                CreatedAt = DateTime.Now,
                FinalStatus = "Approved"
            });
            Answers.Add(new LeaveRequestsAnswer
            {
                Id = Guid.NewGuid(),
                Start = new DateOnly(2025, 7, 5),     // Example start date
                End = new DateOnly(2025, 7, 7),       // Example end date
                CreatedAt = DateTime.Now,
                FinalStatus = "Rejected"
            });
            Answers.Add(new LeaveRequestsAnswer
            {
                Id = Guid.NewGuid(),
                Start = new DateOnly(2025, 7, 1),     // Example start date
                End = new DateOnly(2025, 7, 4),       // Example end date
                CreatedAt = DateTime.Now,
                FinalStatus = "Rejected"
            });
            Answers.Add(new LeaveRequestsAnswer
            {
                Id = Guid.NewGuid(),
                Start = new DateOnly(2025, 7, 2),     // Example start date
                End = new DateOnly(2025, 7, 10),       // Example end date
                CreatedAt = DateTime.Now,
                FinalStatus = "Pending"
            });
            Answers.Add(new LeaveRequestsAnswer
            {
                Id = Guid.NewGuid(),
                Start = new DateOnly(2025, 6, 25),     // Example start date
                End = new DateOnly(2025, 7, 5),       // Example end date
                CreatedAt = DateTime.Now,
                FinalStatus = "Pending"
            });
            Answers.Add(new LeaveRequestsAnswer
            {
                Id = Guid.NewGuid(),
                Start = new DateOnly(2025, 7, 1),     // Example start date
                End = new DateOnly(2025, 7, 5),       // Example end date
                CreatedAt = DateTime.Now,
                FinalStatus="Pending"

            });
            // Assign to the DataGrid
            LeaveRequestsAnswers.ItemsSource = Answers;
        }
        public class LeaveRequestsAnswer
        {
            public Guid Id { get; set; } // Real ID (GUID), not shown in UI
            public DateOnly Start { get; set; }
            public DateOnly End { get; set; }
            public DateTime CreatedAt { get; set; }
            public string  FinalStatus {  get; set; }

        }
    }
}
