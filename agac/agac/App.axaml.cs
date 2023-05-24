using agac.ViewModels;
using agac.Views;
using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using Plugin.FirebasePushNotification;
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
                Debug.WriteLine($"[Token] {CrossFirebasePushNotification.Current.Token}");
                CrossFirebasePushNotification.Current.OnTokenRefresh += Current_OnTokenRefresh;
                CrossFirebasePushNotification.Current.OnNotificationReceived += Current_OnNotificationReceived;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }

            base.OnFrameworkInitializationCompleted();
        }

        void Current_OnNotificationReceived(object source, FirebasePushNotificationDataEventArgs e)
        {
            Debug.WriteLine($"[OnNotificationReceived]");

            foreach (var data in e.Data)
            {
                Debug.WriteLine($"[DATA] {data.Key} = {data.Value}");
            }
        }

        public void Current_OnTokenRefresh(object source, FirebasePushNotificationTokenEventArgs e)
        {
            Debug.WriteLine($"[OnTokenRefresh] {e.Token}");
        }
    }
}