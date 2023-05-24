using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Avalonia.Android;
using Plugin.CurrentActivity;
using Plugin.FirebasePushNotification;
using System.Diagnostics;

namespace agac.Android
{
    [Activity(Label = "agac.Android", Theme = "@style/MyTheme.NoActionBar", Icon = "@drawable/icon", LaunchMode = LaunchMode.SingleTop, ConfigurationChanges = ConfigChanges.Orientation | ConfigChanges.ScreenSize)]
    public class MainActivity : AvaloniaMainActivity
    {

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            CrossCurrentActivity.Current.Init(this, savedInstanceState);
            FirebasePushNotificationManager.ProcessIntent(this, Intent);
        }

        protected override void OnNewIntent(Intent? intent)
        {
            FirebasePushNotificationManager.ProcessIntent(this, intent);
            base.OnNewIntent(intent);
        }
    }
}