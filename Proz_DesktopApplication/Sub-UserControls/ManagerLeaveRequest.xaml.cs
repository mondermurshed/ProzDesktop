using ModernMessageBoxLib;
using Proz_DesktopApplication.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
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

namespace Proz_DesktopApplication.Sub_UserControls
{
    /// <summary>
    /// Interaction logic for ManagerLeaveRequest.xaml
    /// </summary>
    public partial class ManagerLeaveRequest : UserControl
    {
        public ManagerLeaveRequest()
        {
            InitializeComponent();
        }
        private void FromDatePicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            TillDatePicker.Text = "";
            if (FromDatePicker.SelectedDate != null)
            {
                TillDatePicker.IsEnabled = true;
                DateTime fromDate = FromDatePicker.SelectedDate.Value;
                TillDatePicker.DisplayDateStart = fromDate;
                TillDatePicker.DisplayDateEnd = fromDate.AddDays(30);
            }
            else
            {
                TillDatePicker.IsEnabled = false;
            }
        }

        private async void CreateANLeaveRequest(object sender, RoutedEventArgs e)
        {
           


        }

        private void LeaveRequestsDatagrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {



            
        }
    }
}
