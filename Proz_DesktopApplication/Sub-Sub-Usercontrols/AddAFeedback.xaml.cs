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

namespace Proz_DesktopApplication.Sub_Sub_Usercontrols
{
    /// <summary>
    /// Interaction logic for AddAFeedback.xaml
    /// </summary>
    public partial class AddAFeedback : UserControl
    {
        public AddAFeedback()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            QModernMessageBox.Show("Your feedback has been stored successfully!", "Operation result", QModernMessageBox.QModernMessageBoxButtons.Ok, ModernMessageboxIcons.Done);
        }
    }
}
