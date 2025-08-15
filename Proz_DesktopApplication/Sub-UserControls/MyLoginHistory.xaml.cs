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
using Proz_DesktopApplication.API;

namespace Proz_DesktopApplication.Sub_UserControls
{
    /// <summary>
    /// Interaction logic for MyLoginHistory.xaml
    /// </summary>
    public partial class MyLoginHistory : BaseUserControlMain
    {
        public List<ReturnLoginHistory> GetLoginHistory { get; set; } = new();
        public GeneralAPICalling _GeneralAPIEndpointsDefinitions;
        public bool IsLoaded { get; set; } = false;
        public MyLoginHistory()
        {
            InitializeComponent();
       
            GotFocus += OnCreatingThisUsercontrol;
        }

        private async void OnCreatingThisUsercontrol(object sender, RoutedEventArgs e)
        {
            if(IsLoaded==true)
                return;
            IsLoaded = true;

            _GeneralAPIEndpointsDefinitions = GeneralAPICalling1 ?? throw new InvalidOperationException("GeneralAPIEndpointsDefinitions is null");

            this.IsEnabled = false;
            try
            {



                var win = new IndeterminateProgressWindow("Fetching your login history...");
                win.Show();
                var response = await _GeneralAPIEndpointsDefinitions.GetUserLoginHistory();
                win.Message = "Result is collected..";
                win.Close();


                if (response.IsSuccessStatusCode && response.Content != null && response.Content.Any())
                {
                    GetLoginHistory = response.Content;

                    MyLoginHistoryDatagrid.ItemsSource = null;
                    MyLoginHistoryDatagrid.ItemsSource = GetLoginHistory;

                    this.IsEnabled = true;

                }
                else
                {
                    var msgBox2 = new ModernMessageBox($"No data was found or it didn't successfully connect to the server.",
                                                                  "Operation Information",
                                                                  ModernMessageboxIcons.Error,
                                                                  "OK");
                    msgBox2.ShowDialog();
                    MyLoginHistoryDatagrid.ItemsSource = null;
                    this.IsEnabled = true;
                }

            }
            catch (Exception ex)
            {
                var msgBox2 = new ModernMessageBox($"Didn't successfully connect to the server.",
                                                               "Operation Information",
                                                               ModernMessageboxIcons.Error,
                                                               "OK");
                msgBox2.ShowDialog();
                this.IsEnabled = true;
            }


        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var records = MyLoginHistoryDatagrid.ItemsSource as List<ReturnLoginHistory>;

            if (records == null || records.Count == 0)
                return;

            string firstToken = records[0].DeviceTokenHashed;

            var different = records.FirstOrDefault(x => x.DeviceTokenHashed != firstToken);

            if (different != null)
            {
                MyLoginHistoryDatagrid.SelectedItem = different;
                MyLoginHistoryDatagrid.ScrollIntoView(different); // Optional: Scroll to it
            }
            else
            {
                var msgBox1 = new ModernMessageBox($"No different Device Token address was found.", "The result of the searching operation",
                 
                  ModernMessageboxIcons.None,
                  "OK");
                msgBox1.ShowDialog();

               
            }
        }
       
    }
}
