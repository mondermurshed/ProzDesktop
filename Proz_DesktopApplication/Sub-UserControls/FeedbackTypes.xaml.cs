using System.Collections.Generic;
using System.Text.Json;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;
using ModernMessageBoxLib;
using Proz_DesktopApplication.API;



namespace Proz_DesktopApplication.Sub_UserControls
{
    public partial class FeedbackTypes : BaseUserControlMain
    {
        public List<GetFeedbackTypesDTO> GetfeedbackTypes { get; set; } = new();
        public AdminAPIEndpointsDefinitions adminAPIEndpointsDefinitions;
        public FeedbackTypes()
        {
            InitializeComponent();
            Loaded += OnCreatingFeedbackType;
        }

        private async void OnCreatingFeedbackType(object sender, RoutedEventArgs e)
        {
            adminAPIEndpointsDefinitions = _AdminAPIEndpointsDefinitions1 ?? throw new InvalidOperationException("Services1 is null");
           

        }



        private void LoadFeedbackTypes()
        {
          

            //FeedbackTypesDataGrid.ItemsSource = null;
            //FeedbackTypesDataGrid.ItemsSource = feedbackTypes;
        }

        private async void AddFeedbackTypeButton_Click(object sender, RoutedEventArgs e)
        {
            this.IsEnabled = false;
            try
            {
                var request = new AddANewFeedbackTypeRequest
                {
                    feedbackTypeName = FeedbackTypeTextBox.Text.Trim()
                };
                var win = new IndeterminateProgressWindow("Inserting data...");
                win.Show();
                var response = await adminAPIEndpointsDefinitions.AddANewFeedbackType(request);
                win.Message = "Result is collected..";
                win.Close();


                if (response.IsSuccessStatusCode && response.Content?.Message != null)
                {
                    var msgBox2 = new ModernMessageBox($"{string.Join('\n', response.Content.Message)})",
                                                       "Operation Information",
                                                       ModernMessageboxIcons.Done,
                                                       "OK!");
                    msgBox2.ShowDialog();
                    this.IsEnabled = true;

                }

                else
                {
                    // When server returns 400, Refit puts the error JSON as a string here
                    var rawError = response.Error?.Content;
                    AddANewFeedbackTypeResponse errorResponse = null;
                    ValidationErrorResponse errorResponse2 = null;

                    if (!string.IsNullOrWhiteSpace(rawError))
                    {
                        try
                        {
                            errorResponse = JsonSerializer.Deserialize<AddANewFeedbackTypeResponse>(rawError, new JsonSerializerOptions
                            {
                                PropertyNameCaseInsensitive = true
                            });
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

                        if (errorResponse?.Errors != null && errorResponse.Errors.Count > 0)
                        {
                            var msgBox2 = new ModernMessageBox($"{string.Join('\n', errorResponse.Errors)}.",
                                                               "Operation Information",
                                                               ModernMessageboxIcons.Error,
                                                               "OK");
                            msgBox2.ShowDialog();
                            this.IsEnabled = true;
                        }

                    }

                }
            }
            catch (Exception ex)
            {
                var msgBox2 = new ModernMessageBox($"Something went wrong..",
                                                              "Operation Information",
                                                              ModernMessageboxIcons.Error,
                                                              "OK");
                msgBox2.ShowDialog();
                this.IsEnabled = true;
            }
        }
    


        private async void RemoveFeedbackTypeButton_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button && button.DataContext is GetFeedbackTypesDTO user)
            {
                var msgBox = new ModernMessageBox($"Are you sure that you want to start the process to remove this data ?.",
                                                         "Operation Information",
                                                         ModernMessageboxIcons.Info,
                                                         "No","Yes");
                msgBox.ShowDialog();

                if (msgBox.Result == ModernMessageboxResult.Button2)
                {
                   


                this.IsEnabled = false;
                try
                {
                   
                    var request = new RemoveFeedbackTypeRequest
                    {
                        FeedbackID = user.Id,
                        ReplaceWith = ReplaceWithTextbox.Text.Trim()
                    };

                    var win = new IndeterminateProgressWindow("Deleting data...");
                    win.Show();
                    var response = await adminAPIEndpointsDefinitions.DeleteAFeedbackType(request);
                    win.Message = "Result is collected..";
                    win.Close();


                    if (response.IsSuccessStatusCode && response.Content?.Message != null)
                    {
                        var msgBox2 = new ModernMessageBox($"{string.Join('\n', response.Content.Message)})",
                                                           "Operation Information",
                                                           ModernMessageboxIcons.Done,
                                                           "OK!");
                        msgBox2.ShowDialog();
                         
                            try
                            {

                                var win1 = new IndeterminateProgressWindow("Refreshing the data...");
                                win1.Show();
                                var Refreshresponse = await adminAPIEndpointsDefinitions.GetFeedbackTypes();
                                win1.Message = "Result is collected..";
                                win1.Close();


                                if (Refreshresponse.IsSuccessStatusCode && Refreshresponse.Content != null && Refreshresponse.Content.Any())
                                {
                                    GetfeedbackTypes = Refreshresponse.Content;

                                    FeedbackTypesDataGrid.ItemsSource = null;
                                    FeedbackTypesDataGrid.ItemsSource = GetfeedbackTypes;
                                    this.IsEnabled = true;

                                }
                                else
                                {
                                    var msgBox3 = new ModernMessageBox($"No data was found or it didn't successfully connect to the server.",
                                                                                  "Operation Information",
                                                                                  ModernMessageboxIcons.Error,
                                                                                  "OK");
                                    msgBox3.ShowDialog();
                                    this.IsEnabled = true;
                                    FeedbackTypesDataGrid.ItemsSource = null;
                                }

                            }
                            catch (Exception ex)
                            {
                                this.IsEnabled = true;
                            }

                            this.IsEnabled = true;

                    }

                    else
                    {
                        // When server returns 400, Refit puts the error JSON as a string here
                        var rawError = response.Error?.Content;
                        RemoveFeedbackTypeResponse errorResponse = null;
                        ValidationErrorResponse errorResponse2 = null;

                        if (!string.IsNullOrWhiteSpace(rawError))
                        {
                            try
                            {
                                errorResponse = JsonSerializer.Deserialize<RemoveFeedbackTypeResponse>(rawError, new JsonSerializerOptions
                                {
                                    PropertyNameCaseInsensitive = true
                                });
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

                            if (errorResponse?.Errors != null && errorResponse.Errors.Count > 0)
                            {
                                var msgBox2 = new ModernMessageBox($"{string.Join('\n', errorResponse.Errors)}.",
                                                                   "Operation Information",
                                                                   ModernMessageboxIcons.Error,
                                                                   "OK");
                                msgBox2.ShowDialog();
                                this.IsEnabled = true;
                            }

                        }

                    }
                }
                catch (Exception ex)
                {
                    var msgBox2 = new ModernMessageBox($"Something went wrong..",
                                                                  "Operation Information",
                                                                  ModernMessageboxIcons.Error,
                                                                  "OK");
                    msgBox2.ShowDialog();
                    this.IsEnabled = true;
                }
                }



            }
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            this.IsEnabled = false;
            try
            {

                var win = new IndeterminateProgressWindow("Fetching the data...");
                win.Show();
                var response = await adminAPIEndpointsDefinitions.GetFeedbackTypes();
                win.Message = "Result is collected..";
                win.Close();


                if (response.IsSuccessStatusCode && response.Content != null && response.Content.Any())
                {
                    GetfeedbackTypes = response.Content;
                   
                    FeedbackTypesDataGrid.ItemsSource = null;
                    FeedbackTypesDataGrid.ItemsSource = GetfeedbackTypes;
                    this.IsEnabled = true;

                }
                else
                {
                    var msgBox2 = new ModernMessageBox($"No data was found or it didn't successfully connect to the server.",
                                                                  "Operation Information",
                                                                  ModernMessageboxIcons.Error,
                                                                  "OK");
                    msgBox2.ShowDialog();
                    FeedbackTypesDataGrid.ItemsSource = null;
                    this.IsEnabled = true;
                }

            }
            catch (Exception ex)
            {
                this.IsEnabled = true;
            }
        }
    }
 
}



//Question

//Bug

//Complaint And Advice

//Feature Request

