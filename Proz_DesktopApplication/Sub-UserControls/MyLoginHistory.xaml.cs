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
using ModernMessageBoxLib;

namespace Proz_DesktopApplication.Sub_UserControls
{
    /// <summary>
    /// Interaction logic for MyLoginHistory.xaml
    /// </summary>
    public partial class MyLoginHistory : UserControl
    {
        public MyLoginHistory()
        {
            InitializeComponent();
            LoadFakeData();
        }
        private void LoadFakeData()
        {
            var LoginHistoryRecords = new List<LoginHistory>();

            // Create 3 fake rows with auto-increment ID
            LoginHistoryRecords.Add(new LoginHistory
            {

                WhenLogged = new DateTime(2023, 12, 24, 4, 24, 5),
                IPAddress = "192.168.1.1"
            });

            LoginHistoryRecords.Add(new LoginHistory
            {
                WhenLogged = new DateTime(2023, 12, 24, 4, 24, 5),
                IPAddress = "192.168.1.1"
            });

            LoginHistoryRecords.Add(new LoginHistory
            {
                WhenLogged = new DateTime(2023, 12, 24, 4, 24, 5),
                IPAddress = "192.168.1.1"
            });
            LoginHistoryRecords.Add(new LoginHistory
            {
                WhenLogged = new DateTime(2023, 12, 24, 4, 24, 5),
                IPAddress = "192.168.1.1"
            });
            LoginHistoryRecords.Add(new LoginHistory
            {
                WhenLogged = new DateTime(2023, 12, 24, 4, 24, 5),
                IPAddress = "192.168.1.1"
            });
            LoginHistoryRecords.Add(new LoginHistory
            {
                WhenLogged = new DateTime(2023, 12, 24, 4, 24, 5),
                IPAddress = "192.168.1.1"
            });
            LoginHistoryRecords.Add(new LoginHistory
            {
                WhenLogged = new DateTime(2023, 12, 24, 4, 24, 5),
                IPAddress = "192.168.1.1"
            });
            LoginHistoryRecords.Add(new LoginHistory
            {
                WhenLogged = new DateTime(2023, 12, 24, 4, 24, 5),
                IPAddress = "192.168.1.1"
            });
            LoginHistoryRecords.Add(new LoginHistory
            {
                WhenLogged = new DateTime(2023, 12, 24, 4, 24, 5),
                IPAddress = "192.168.1.1"
            });
            LoginHistoryRecords.Add(new LoginHistory
            {
                WhenLogged = new DateTime(2023, 12, 24, 4, 24, 5),
                IPAddress = "192.168.1.1"
            });
            LoginHistoryRecords.Add(new LoginHistory
            {
                WhenLogged = new DateTime(2023, 12, 24, 4, 24, 5),
                IPAddress = "192.168.1.1"
            });
            LoginHistoryRecords.Add(new LoginHistory
            {
                WhenLogged = new DateTime(2023, 12, 24, 4, 24, 5),
                IPAddress = "192.168.1.1"

            });
            LoginHistoryRecords.Add(new LoginHistory
            {
                WhenLogged = new DateTime(2023, 12, 24, 4, 24, 5),
                IPAddress = "192.168.1.1"

            });
            LoginHistoryRecords.Add(new LoginHistory
            {
                WhenLogged = new DateTime(2023, 12, 24, 4, 24, 5),
                IPAddress = "192.168.1.1"

            });
            LoginHistoryRecords.Add(new LoginHistory
            {
                WhenLogged = new DateTime(2023, 12, 24, 4, 24, 5),
                IPAddress = "192.168.1.1"

            });
    

            // Assign to the DataGrid
            LoginHistoryDatagrid.ItemsSource = LoginHistoryRecords;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var records = LoginHistoryDatagrid.ItemsSource as List<LoginHistory>;

            if (records == null || records.Count == 0)
                return;

            string firstIP = records[0].IPAddress;

            var different = records.FirstOrDefault(x => x.IPAddress != firstIP);

            if (different != null)
            {
                LoginHistoryDatagrid.SelectedItem = different;
                LoginHistoryDatagrid.ScrollIntoView(different); // Optional: Scroll to it
            }
            else
            {
                
                QModernMessageBox.Show("No different IP address was found.", "The result of the searching operation", QModernMessageBox.QModernMessageBoxButtons.Ok, ModernMessageboxIcons.Info);
            }
        }
        public class LoginHistory
        {

            public DateTime WhenLogged { get; set; }
            public string IPAddress { get; set; }
        }
    }
}
