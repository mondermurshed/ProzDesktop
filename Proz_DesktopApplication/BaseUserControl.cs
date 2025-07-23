using System.Windows;
using System.Windows.Controls;
using Proz_DesktopApplication.API;

namespace Proz_DesktopApplication
{
    public class BaseUserControlMain : UserControl
    {
        protected IServiceProvider? Services1
        {
            get
            {
                var window = Window.GetWindow(this) as MainDashboardWindow;
                return window?.Services;
            }
        }

        protected IAuthAPI? AuthApi1
        {
            get
            {
                var window = Window.GetWindow(this) as MainDashboardWindow;
                return window?.AuthApi;
            }
        }

        protected GeneralAPICalling? GeneralAPICalling1
        {
            get
            {
                var window = Window.GetWindow(this) as MainDashboardWindow;
                return window?.GeneralAPICalling;
            }
        }

        protected AdminAPIEndpointsDefinitions? _AdminAPIEndpointsDefinitions1
        {
            get
            {
                var window = Window.GetWindow(this) as MainDashboardWindow;
                return window?._AdminAPIEndpointsDefinitions;
            }
        }
    }
}
