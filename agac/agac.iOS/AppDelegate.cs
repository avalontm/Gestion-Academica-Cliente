using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Notifications;
using Avalonia.iOS;
using Avalonia.Media;
using Avalonia.ReactiveUI;
using Firebase.Core;
using Foundation;

using UIKit;

namespace agac.iOS
{
    // The UIApplicationDelegate for the application. This class is responsible for launching the 
    // User Interface of the application, as well as listening (and optionally responding) to 
    // application events from iOS.
    [Register("AppDelegate")]
    public partial class AppDelegate : AvaloniaAppDelegate<App>
    {


        protected override AppBuilder CustomizeAppBuilder(AppBuilder builder)
        {
            //FirebasePushNotificationManager.Initialize(options, true);
            settingsForRemoteNotifications();
            return builder.UseReactiveUI();
        }

        private void settingsForRemoteNotifications()
        {
            UIRemoteNotificationType notificationTypes = UIRemoteNotificationType.Alert | UIRemoteNotificationType.Badge | UIRemoteNotificationType.Sound;
            UIApplication.SharedApplication.RegisterForRemoteNotificationTypes(notificationTypes);
        }

        /*
          private static CrossFirebaseSettings CreateCrossFirebaseSettings()
          {
              return new CrossFirebaseSettings(isCloudMessagingEnabled: true);
          }
          */

    }
}