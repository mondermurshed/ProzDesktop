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
using MaterialDesignThemes.Wpf;
using ModernMessageBoxLib;

namespace Proz_DesktopApplication.Sub_Sub_Usercontrols
{
    /// <summary>
    /// Interaction logic for ManageMyFeedbacks.xaml
    /// </summary>
    public partial class ManageMyFeedbacks : UserControl
    {
        public ManageMyFeedbacks()
        {
            InitializeComponent();
            LoadFakeData();
        }
        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
           
        }
       
        private void LoadFakeData()
        {
            var feedbacks = new List<Feedback>();

            // Create 3 fake rows with auto-increment ID
            feedbacks.Add(new Feedback
            {
                Id = Guid.NewGuid(), // ✅ Generate a unique ID
                Type = "Improvement",
                Title = "Problem with my data insertion, i can't even resore data",
                Description="asgsags gsj agsa gas gwkgw qmwq qwm gmqwg qwgwqg qwg weehrehew gegweg ewgew gweg erge gsefa  fewgw gwehre hwe gewgwe gweg ewgew eg we gew gewg wegwet we gewgkewf egw fwg, w gsgsm mge ges egmg qwkg mqw gqwg",
                Date = new DateTime(2023, 12, 24, 4, 24, 5),
                Completed = false,

            });

            feedbacks.Add(new Feedback
            {
                Id = Guid.NewGuid(), // ✅ Generate a unique ID
                Type = "Help question",
                Title = "You can put a button to make things easy for me when navigting to the add column section",
                Description = "asgsags gsj agsa gas gwkgw qmwq qwm gmqwg qwgwqg qwg weehrehew gegweg ewgew gweg erge gsefa  fewgw gwehre hwe gewgwe gweg ewgew eg we gew gewg wegwet we gewgkewf egw fwg, w gsgsm mge ges egmg qwkg mqw gqwg",
                Date = new DateTime(2025, 5, 11, 18, 4, 15), // 6:04:15 PM
                Completed =true,
                Answer = "answer!! afsafas fsaf asfn asjfsam asfas fsajf   fwf we geg ewgj ewjgw eg we jg  ewjgewjg kewg wegj ewg we gwe gwe geg wej gewj ewjg ew ",
                AnswerDate = new DateTime(2023, 12, 24, 4, 24, 5),
                Respondent = "Ahmed"
            });

            feedbacks.Add(new Feedback
            {
                Id = Guid.NewGuid(), // ✅ Generate a unique ID
                Type = "Suggestion",
                Title = "You can put a button to make ",
                Description = "asgsags gsj agsa gas gwkgw qmwq qwm gmqwg qwgwqg qwg weehrehew gegweg ewgew gweg erge gsefa  fewgw gwehre hwe gewgwe gweg ewgew eg we gew gewg wegwet we gewgkewf egw fwg, w gsgsm mge ges egmg qwkg mqw gqwg",
                Date = new DateTime(2024, 9, 30, 12, 15, 30),
                Completed=false
            });
            feedbacks.Add(new Feedback
            {
                Id = Guid.NewGuid(), // ✅ Generate a unique ID
                Type = "Suggestion",
                Title = "You can put a button to make ",
                Description = "asgsags gsj agsa gas gwkgw qmwq qwm gmqwg qwgwqg qwg weehrehew gegweg ewgew gweg erge gsefa  fewgw gwehre hwe gewgwe gweg ewgew eg we gew gewg wegwet we gewgkewf egw fwg, w gsgsm mge ges egmg qwkg mqw gqwg",
                Date = new DateTime(2024, 9, 30, 12, 15, 30),
                Completed=false
            });
            feedbacks.Add(new Feedback
            {
                Id = Guid.NewGuid(), // ✅ Generate a unique ID
                Type = "Suggestion",
                Title = "You can put a button to make ",
                Description = "asgsags gsj agsa gas gwkgw qmwq qwm gmqwg qwgwqg qwg weehrehew gegweg ewgew gweg erge gsefa  fewgw gwehre hwe gewgwe gweg ewgew eg we gew gewg wegwet we gewgkewf egw fwg, w gsgsm mge ges egmg qwkg mqw gqwg",
                Date = new DateTime(2024, 9, 30, 12, 15, 30),
                Completed=false
            });
            feedbacks.Add(new Feedback
            {
                Id = Guid.NewGuid(), // ✅ Generate a unique ID
                Type = "Suggestion",
                Title = "You can put a button to make ",
                Description = "asgsags gsj agsa gas gwkgw qmwq qwm gmqwg qwgwqg qwg weehrehew gegweg ewgew gweg erge gsefa  fewgw gwehre hwe gewgwe gweg ewgew eg we gew gewg wegwet we gewgkewf egw fwg, w gsgsm mge ges egmg qwkg mqw gqwg",
                Date = new DateTime(2024, 9, 30, 12, 15, 30),
                Completed = false
            });
            feedbacks.Add(new Feedback
            {
                Id = Guid.NewGuid(), // ✅ Generate a unique ID
                Type = "Suggestion",
                Title = "You can put a button to make ",
                Description = "asgsags gsj agsa gas gwkgw qmwq qwm gmqwg qwgwqg qwg weehrehew gegweg ewgew gweg erge gsefa  fewgw gwehre hwe gewgwe gweg ewgew eg we gew gewg wegwet we gewgkewf egw fwg, w gsgsm mge ges egmg qwkg mqw gqwg",
                Date = new DateTime(2024, 9, 30, 12, 15, 30),
                Completed=true,
                Answer = "answer!! afsafas fsaf asfn asjfsam asfas fsajf   fwf we geg ewgj ewjgw eg we jg  ewjgewjg kewg wegj ewg we gwe gwe geg wej gewj ewjg ew ",
                AnswerDate = new DateTime(2023, 12, 24, 4, 24, 5),
                Respondent = "Ahmed"
            });
            feedbacks.Add(new Feedback
            {
                Id = Guid.NewGuid(), // ✅ Generate a unique ID
                Type = "Suggestion",
                Title = "You can put a button to make ",
                Description = "asgsags gsj agsa gas gwkgw qmwq qwm gmqwg qwgwqg qwg weehrehew gegweg ewgew gweg erge gsefa  fewgw gwehre hwe gewgwe gweg ewgew eg we gew gewg wegwet we gewgkewf egw fwg, w gsgsm mge ges egmg qwkg mqw gqwg",
                Date = new DateTime(2024, 9, 30, 12, 15, 30),
                Completed=false
            });
            feedbacks.Add(new Feedback
            {
                Id = Guid.NewGuid(), // ✅ Generate a unique ID
                Type = "Suggestion",
                Title = "You can put a button to make ",
                Description = "asgsags gsj agsa gas gwkgw qmwq qwm gmqwg qwgwqg qwg weehrehew gegweg ewgew gweg erge gsefa  fewgw gwehre hwe gewgwe gweg ewgew eg we gew gewg wegwet we gewgkewf egw fwg, w gsgsm mge ges egmg qwkg mqw gqwg",
                Date = new DateTime(2024, 9, 30, 12, 15, 30),
                Completed=false
            });
            feedbacks.Add(new Feedback
            {
                Id = Guid.NewGuid(), // ✅ Generate a unique ID
                Type = "Suggestion",
                Title = "You can put a button to make ",
                Date = new DateTime(2024, 9, 30, 12, 15, 30),
                Completed=true,
                Answer = "answer!! afsafas fsaf asfn asjfsam asfas fsajf   fwf we geg ewgj ewjgw eg we jg  ewjgewjg kewg wegj ewg we gwe gwe geg wej gewj ewjg ew ",
                AnswerDate = new DateTime(2023, 12, 24, 4, 24, 5),
                Respondent = "Ahmed"
            });
            feedbacks.Add(new Feedback
            {
                Id = Guid.NewGuid(), // ✅ Generate a unique ID
                Type = "Suggestion",
                Title = "You can put a button to make ",
                Description = "asgsags gsj agsa gas gwkgw qmwq qwm gmqwg qwgwqg qwg weehrehew gegweg ewgew gweg erge gsefa  fewgw gwehre hwe gewgwe gweg ewgew eg we gew gewg wegwet we gewgkewf egw fwg, w gsgsm mge ges egmg qwkg mqw gqwg",
                Date = new DateTime(2024, 9, 30, 12, 15, 30),
                Completed=false
            });
            feedbacks.Add(new Feedback
            {
                Id = Guid.NewGuid(), // ✅ Generate a unique ID
                Type = "Suggestion",
                Title = "You can put a button to make ",
                Description = "asgsags gsj agsa gas gwkgw qmwq qwm gmqwg qwgwqg qwg weehrehew gegweg ewgew gweg erge gsefa  fewgw gwehre hwe gewgwe gweg ewgew eg we gew gewg wegwet we gewgkewf egw fwg, w gsgsm mge ges egmg qwkg mqw gqwg",
                Date = new DateTime(2024, 9, 30, 12, 15, 30),
                Completed = false

            });
            // Assign to the DataGrid
            FeedbacksDatagrid.ItemsSource = feedbacks;
        }

       
      

      

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
          if( QModernMessageBox.Show("Are you sure you wanna claar the data from the textboxes ?", "Warnning message",QModernMessageBox.QModernMessageBoxButtons.YesNo,ModernMessageboxIcons.Warning)==ModernMessageboxResult.Button1)
            {
                titletextbox.Clear();
                descriptiontextbox.Clear();
                AnswerDateTimetextbox.Clear();
                Answertextbox.Clear();
                Respondenttextbox.Clear();
            }
      
        }

        private void FeedbacksDatagrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (FeedbacksDatagrid.SelectedItem is Feedback selected)
            {
              
                if (selected.Completed == true)
                {
                    ClearButton.IsEnabled = true;
                    titletextbox.Text = selected.Title;
                    descriptiontextbox.Text = selected.Description;
                    Answertextbox.Text = selected.Answer;
                    AnswerDateTimetextbox.Text = selected.AnswerDate.ToString("hh\\:mm");
                    Respondenttextbox.Text = selected.Respondent;
                }
                else
                {
                    ClearButton.IsEnabled = false;
                }
            }
          
        }


    }

    public class Feedback
    {
        public Guid Id { get; set; } // Real ID (GUID), not shown in UI
        public string Type { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public bool Completed {  get; set; }

        public string Answer {  get; set; }
        public DateTime AnswerDate {  get; set; }

        public string Respondent {  get; set; }
    }
}

