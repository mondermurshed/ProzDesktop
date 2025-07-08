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
    /// Interaction logic for AddaALeaveRequest.xaml
    /// </summary>
    public partial class AddaALeaveRequest : UserControl
    {
        public AddaALeaveRequest()
        {
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {

                TillDatePicker.IsEnabled = false;
            FromDatePicker.DisplayDateStart = DateTime.Today;
            FromDatePicker.DisplayDateEnd = DateTime.Today.AddDays(30);
           
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
                TillDatePicker.IsEnabled= false;
            }
        }
    }
}
