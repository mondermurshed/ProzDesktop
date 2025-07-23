using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace Proz_DesktopApplication.Sub_UserControls
{
    public partial class AuditAdminHistory : UserControl
    {
        public AuditAdminHistory()
        {
            InitializeComponent();
            SetupManagerComboBox();
        }

        private void SetupManagerComboBox()
        {
            // You will replace this later with real manager names from your API
            ManagerComboBox.Items.Clear();
            ManagerComboBox.Items.Add("All Managers"); // Optional: shows all records
            ManagerComboBox.Items.Add("HR Manager - Sarah Johnson");
            ManagerComboBox.Items.Add("Department Manager - Ahmed Ali");
            ManagerComboBox.Items.Add("Department Manager - Mona Saeed");

            ManagerComboBox.SelectedIndex = 0;
        }

        private void ManagerComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Later: Filter the records shown in AuditAdminDataGrid by selected manager
        }

        // Data model you’ll fill later using your API
        public class AuditAdminLog
        {
            public string ActionType { get; set; }
            public string PerformedAt { get; set; }
            public string Notes { get; set; }
            public int PerformerAccountId { get; set; }
            public int TargetEntityId { get; set; }
        }
    }
}
