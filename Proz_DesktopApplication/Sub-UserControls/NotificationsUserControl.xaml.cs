using Microsoft.AspNetCore.SignalR.Client;
using Proz_DesktopApplication.HelperServices;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Media;
using System.Windows;
using System.Windows.Controls;
using ToastNotifications;
using ToastNotifications.Lifetime;
using ToastNotifications.Messages;
using ToastNotifications.Position;

namespace Proz_DesktopApplication.Sub_UserControls
{
    public partial class NotificationsUserControl : BaseUserControlMain
    {
        private MainHubService _hubConnection;
        private bool isloaded = false;
        public NotificationsUserControl()
        {
            InitializeComponent();
           
        }

        private async void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            if (isloaded == true)
                return;
            isloaded = true;
            _hubConnection = MainHub ?? throw new InvalidOperationException("MainHUB is null");

            Notifier notifier = new Notifier(cfg =>
            {
                cfg.PositionProvider = new WindowPositionProvider(
                    parentWindow: Application.Current.MainWindow,
                    corner: Corner.BottomRight,
                    offsetX: 10,
                    offsetY: 10);

                cfg.LifetimeSupervisor = new TimeAndCountBasedLifetimeSupervisor(
                    notificationLifetime: TimeSpan.FromSeconds(3),
                    maximumNotificationCount: MaximumNotificationCount.FromCount(5));

                cfg.Dispatcher = Application.Current.Dispatcher;
                cfg.DisplayOptions.Width = 350;
                cfg.DisplayOptions.TopMost = true;


            });

            _hubConnection.Connection.On<NotificationResponse>("NewNotification", payload =>
            {
                 Dispatcher.Invoke( () =>
                {
                   var data = new NotificationResponse
                   {
                       Title = payload.Title,
                       Message = payload.Message,
                       Created_At = payload.Created_At,
                       Type = payload.Type,
                       Priority = payload.Priority
                   };

                  

                    NotificationsDataGrid.Items.Add(data);
                    ////var player = new SoundPlayer("Sounds/NotificationSound.wav");
                    ////player.Play();
                    notifier.ShowInformation("A new notification is here, go check it!");
                  
                    

                });
            });
        }




       

    }
    public class NotificationResponse
    {
        public string Title { get; set; }
        public string Message { get; set; }
        public DateTime Created_At { get; set; }
        public string Type { get; set; }
        public string Priority { get; set; }
        public string SentAtLocal => Created_At.ToLocalTime().ToString("yyyy-MM-dd HH:mm:ss");
    }
}
