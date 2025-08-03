using Proz_DesktopApplication.API;
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
    /// Interaction logic for AddEmployeesToDepartmentsUsercontrol.xaml
    /// </summary>
    public partial class AddEmployeesToDepartmentsUsercontrol : BaseUserControlMain
    {
        public AdminAPIEndpointsDefinitions adminAPIEndpointsDefinitions;
        public AddEmployeesToDepartmentsUsercontrol()
        {
            InitializeComponent();
            Loaded += OnCreatingThisUsercontrol;
        }

        private async void OnCreatingThisUsercontrol(object sender, RoutedEventArgs e)
        {
            adminAPIEndpointsDefinitions = _AdminAPIEndpointsDefinitions1 ?? throw new InvalidOperationException("Services1 is null");
        }

        private void AssignEventHandler(object sender, RoutedEventArgs e)
        {

        }

        private void RefreshEmployeeList(object sender, RoutedEventArgs e)
        {

        }

        private void RefreshDepartmentList(object sender, RoutedEventArgs e)
        {

        }
    }
}
