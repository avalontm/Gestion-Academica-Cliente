using agac.ViewModels;
using agac.Views;
using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using Plugin.Firebase.CloudMessaging;
using System;
using System.Diagnostics;

namespace agac
{
    public partial class App : Application
    {
        public override void Initialize()
        {
            AvaloniaXamlLoader.Load(this);
        }

        public override void OnFrameworkInitializationCompleted()
        {
            if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
            {
                desktop.MainWindow = new MainWindow();
            }
            else if (ApplicationLifetime is ISingleViewApplicationLifetime singleViewPlatform)
            {
                singleViewPlatform.MainView = new MainView();
            }

            try
            {
                CrossFirebaseCloudMessaging.Current.CheckIfValidAsync();
                CrossFirebaseCloudMessaging.Current.TokenChanged += Current_TokenChanged;
                CrossFirebaseCloudMessaging.Current.NotificationReceived += Current_NotificationReceived;
            }
            catch(Exception ex)
            {
                Debug.WriteLine(ex);
            }
            base.OnFrameworkInitializationCompleted();
        }

        private void Current_NotificationReceived(object? sender, Plugin.Firebase.CloudMessaging.EventArgs.FCMNotificationReceivedEventArgs e)
        {
            Debug.WriteLine($"[NotificationReceived] {e.Notification}");
        }

        private void Current_TokenChanged(object? sender, Plugin.Firebase.CloudMessaging.EventArgs.FCMTokenChangedEventArgs e)
        {
            Debug.WriteLine($"[TokenChanged] {e.Token}");
        }
    }
}