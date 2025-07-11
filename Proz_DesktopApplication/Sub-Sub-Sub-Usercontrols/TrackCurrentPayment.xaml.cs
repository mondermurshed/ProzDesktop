using System.Windows.Controls;

namespace Proz_DesktopApplication.Sub_Sub_Sub_Usercontrols
{


public partial class TrackCurrentPayment : UserControl
{
    public TrackCurrentPayment()
    {
        InitializeComponent();
        LoadCurrentPayment();
    }

    private void LoadCurrentPayment()
    {
        PeriodStartTextBox.Text = "2025/07/01";
        PeriodEndTextBox.Text = "2025/07/31";
        BaseSalaryTextBox.Text = "150,000 YER";
        CompanyBonusTextBox.Text = "5,000 YER";
        PerformanceBonusTextBox.Text = "10,000 YER";
        DeductionsTextBox.Text = "2,000 YER";
        FinalAmountTextBox.Text = "163,000 YER";
    }
}
}