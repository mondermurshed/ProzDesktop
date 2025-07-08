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

namespace Proz_DesktopApplication.Sub_UserControls
{
    /// <summary>
    /// Interaction logic for MyPersonalData.xaml
    /// </summary>
    public partial class MyPersonalData : UserControl
    {
        public MyPersonalData()
        {
            InitializeComponent();
            List<string> userPhoneNumbers = new List<string>
        {
            "+1 123-456-7890",
            "+44 20 7946 0958",
            "+967 777 123 456"
        };

            PhoneNumbersControl.ItemsSource = userPhoneNumbers;
        }
    }
}
