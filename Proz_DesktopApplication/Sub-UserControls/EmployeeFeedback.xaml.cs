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
using System.Windows.Controls.Primitives;
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
    /// Interaction logic for EmployeeFeedback.xaml
    /// </summary>
    public partial class EmployeeFeedback : BaseUserControlMain
    {
        public List<GetFeedbackTypesDTO> GetFeedbackTypes { get; set; } = new();
        public List<RetrunFeedbacksInformation> GetRequestedFeedbackOfMine { get; set; } = new();
        public EmployeeAPIEndpointsDefinitions employeeAPIEndpointsDefinitions;
     
        public bool loaded = false;
        public EmployeeFeedback()
        {
            InitializeComponent();
            this.Loaded += OnCreatingThisUsercontrol;
            this.GotFocus += LoadFeedbackTypes;
        }

        private async void OnCreatingThisUsercontrol(object sender, RoutedEventArgs e)
        {
            employeeAPIEndpointsDefinitions = _EmployeeAPIEndpointsDefinitions1 ?? throw new InvalidOperationException("Services1 is null");


        }
        private async void LoadFeedbackTypes(object sender, RoutedEventArgs e)
        {
            if (loaded == true)
                return;
            loaded = true;

            this.IsEnabled = false;
            try
            {



                var win = new IndeterminateProgressWindow("Loading Some important data, please wait...");
                win.Show();
                var response = await employeeAPIEndpointsDefinitions.GetFeedbackTypes();
                win.Message = "Result is collected..";
                win.Close();


                if (response.IsSuccessStatusCode && response.Content != null && response.Content.Any())
                {
                    GetFeedbackTypes = response.Content;

                    feedbackTypecombobox.ItemsSource = null;
                    feedbackTypecombobox.ItemsSource = GetFeedbackTypes;
                    feedbackTypecombobox.DisplayMemberPath = "FeedbackTypeName";
                    feedbackTypecombobox.SelectedValuePath = "Id";
                   

                    this.IsEnabled = true;

                }
                else
                {
                    var msgBox2 = new ModernMessageBox($"No feedback types were found inside the system or it didn't successfully connect to the server.",
                                                                  "Operation Information",
                                                                  ModernMessageboxIcons.Error,
                                                                  "OK");
                    msgBox2.ShowDialog();
                    feedbackTypecombobox.ItemsSource = null;
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
        private async void CreateANewFeedbackRequestEventHandler(object sender, RoutedEventArgs e)
        {

            this.IsEnabled = false;
            try
            {


                var request = new CreateANewFeedbackRequest_Request()
                {
                    FeedbackTitle = titletextbox.Text,
                    FeedbackDescription = Descriptiontextbox.Text,
                    FeedbackType = (Guid)feedbackTypecombobox.SelectedValue
                };
                var win = new IndeterminateProgressWindow("Sending your request, please wait...");
                win.Show();
                var response = await employeeAPIEndpointsDefinitions.RequestANewFeedbackRequest(request);
                win.Message = "Result is collected..";
                win.Close();


                if (response.IsSuccessStatusCode && response.Content != null)
                {

                    var msgBox2 = new ModernMessageBox($"{response.Content.Message}.",
                                                              "Operation Information",
                                                              ModernMessageboxIcons.Done,
                                                              "OK!");
                    msgBox2.ShowDialog();

                    this.IsEnabled = true;
                    return;
                }
                else
                {
                    // When server returns 400, Refit puts the error JSON as a string here
                    var rawError = response.Error?.Content;
                    CreateANewFeedbackRequest_Response errorResponse = null;
                    ValidationErrorResponse errorResponse2 = null;
                    if (!string.IsNullOrWhiteSpace(rawError))
                    {

                        try
                        {
                            errorResponse = JsonSerializer.Deserialize<CreateANewFeedbackRequest_Response>(rawError, new JsonSerializerOptions
                            {
                                PropertyNameCaseInsensitive = true
                            });
                            this.IsEnabled = true;
                        }
                        catch
                        {
                            // Fallback to FluentValidation-style error
                            errorResponse2 = JsonSerializer.Deserialize<ValidationErrorResponse>(rawError, new JsonSerializerOptions
                            {
                                PropertyNameCaseInsensitive = true
                            });

                            // Flatten dictionary errors
                            var flatErrors = errorResponse2.Errors
                                .SelectMany(kvp => kvp.Value.Select(msg => $"{kvp.Key}: {msg}"));

                            var msgBox1 = new ModernMessageBox($"{errorResponse2.Message}\n\n{string.Join("\n", flatErrors)}",
                                "Validation Error",
                               ModernMessageboxIcons.Error,
                               "OK");
                            msgBox1.ShowDialog();
                            this.IsEnabled = true;
                            return;
                        }



                        if (errorResponse?.Errors!=null && errorResponse?.Errors !="")
                        {
                            var msgBox1 = new ModernMessageBox($"Error :{errorResponse.Errors}",
                                     "Operation Information",
                                     ModernMessageboxIcons.Error,
                                     "OK");
                            msgBox1.ShowDialog();
                            this.IsEnabled = true;
                            return;
                        }

                        else
                        {

                            throw new Exception();


                        }

                    }
                    else
                    {
                        throw new Exception();
                    }
               
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
                return;
            }
        }

        //f


        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var msgBox2 = new ModernMessageBox($"Are you sure you wanna claar the data from the textboxes ?.",
                                                                "Operation Information",
                                                                ModernMessageboxIcons.Error,
                                                                "No","Yes");
            msgBox2.ShowDialog();
            if (msgBox2.Result==ModernMessageboxResult.Button2)
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
            if (FeedbacksDatagrid.SelectedItem is RetrunFeedbacksInformation selected)
            {


                    ClearButton.IsEnabled = true;   
                    titletextbox.Text = selected.FeedbackTitle;
                    descriptiontextbox.Text = selected.FeedbackDescription;
                    Answertextbox.Text = selected.FeedbackAnswer;
                    AnswerDateTimetextbox.Text = selected.AnsweredInLocal.ToString();
                    Respondenttextbox.Text = selected.AnsweredBy;
              
            }
            else
            {
                ClearButton.IsEnabled = false;
                titletextbox.Clear();
                descriptiontextbox.Clear();
                AnswerDateTimetextbox.Clear();
                Answertextbox.Clear();
                Respondenttextbox.Clear();
            }

        }

        private async void RefreshMyFeedbacks(object sender, RoutedEventArgs e)
        {
            this.IsEnabled = false;
            try
            {



                var win = new IndeterminateProgressWindow("Fetching the data...");
                win.Show();
                var response = await employeeAPIEndpointsDefinitions.GetMyFeedbackRequests();
                win.Message = "Result is collected..";
                win.Close();
                

                if (response.IsSuccessStatusCode)
                {
                    GetRequestedFeedbackOfMine = response.Content;

                    FeedbacksDatagrid.ItemsSource = null;
                    FeedbacksDatagrid.ItemsSource = GetRequestedFeedbackOfMine;

                    this.IsEnabled = true;

                }
                else
                {
                    var msgBox2 = new ModernMessageBox($"No data was found or it didn't successfully connect to the server.",
                                                                  "Operation Information",
                                                                  ModernMessageboxIcons.Error,
                                                                  "OK");
                    msgBox2.ShowDialog();
                    FeedbacksDatagrid.ItemsSource = null;
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

        private async void Deletefeedback(object sender, RoutedEventArgs e)
        {
            if(FeedbacksDatagrid.SelectedItems.Count!=1)
            {
                var msgBox2 = new ModernMessageBox($"Please select a feedback to delete.",
                                                                               "Operation Information",
                                                                               ModernMessageboxIcons.Error,
                                                                               "OK");
                msgBox2.ShowDialog();

                this.IsEnabled = true;
                return;
            }

            this.IsEnabled = false;
            try
            {

                var selectedfeedback = FeedbacksDatagrid.SelectedItem as RetrunFeedbacksInformation;
                if (selectedfeedback?.FeedbackId == Guid.Empty)
                {
                    var msgBox2 = new ModernMessageBox($"Feedback is not located to be deleted.",
                                                                     "Operation Information",
                                                                     ModernMessageboxIcons.Error,
                                                                     "OK");
                    msgBox2.ShowDialog();
            
                    this.IsEnabled = true;
                    return;
                }
                var request = new RemoveMyFeedbackRequest { FeedbackID = selectedfeedback.FeedbackId };
                var win = new IndeterminateProgressWindow("Removing Feedback...");
                win.Show();
                var response = await employeeAPIEndpointsDefinitions.RemoveMyFeedbackRequest(request);
                win.Message = "Result is collected..";
                win.Close();


                if (response.IsSuccessStatusCode)
                {

                    var msgBox2 = new ModernMessageBox($"{response.Content.Message}",
                   "Operation Information",
                   ModernMessageboxIcons.Done,
                   "OK!");
                    msgBox2.ShowDialog();

                    ClearButton.IsEnabled = false;
                    titletextbox.Clear();
                    descriptiontextbox.Clear();
                    Answertextbox.Clear();
                    AnswerDateTimetextbox.Clear();
                    Respondenttextbox.Clear();


                

          

                    this.IsEnabled = true;
                    return;
                }
                else
                {
                    var msgBox2 = new ModernMessageBox($"{response.Content.Error}.",
                                                                  "Operation Information",
                                                                  ModernMessageboxIcons.Error,
                                                                  "OK");
                    msgBox2.ShowDialog();
                    FeedbacksDatagrid.ItemsSource = null;
                    this.IsEnabled = true;
                    return;
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
    }

  
}


