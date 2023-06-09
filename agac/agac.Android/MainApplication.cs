using Android.App;
using Android.OS;
using Android.Runtime;
using Plugin.FirebasePushNotification;
using System;

namespace agac.Android;

[Application]
public class MainApplication : Application
{
    public MainApplication(IntPtr handle, JniHandleOwnership transer) : base(handle, transer)
    {
    }

    public override void OnCreate()
    {
        base.OnCreate();

        //Set the default notification channel for your app when running Android Oreo
        if (Build.VERSION.SdkInt >= BuildVersionCodes.O)
        {
            //Change for your default notification channel id here
            FirebasePushNotificationManager.DefaultNotificationChannelId = "FirebasePushNotificationChannel";

            //Change for your default notification channel name here
            FirebasePushNotificationManager.DefaultNotificationChannelName = "General";
        }

        FirebasePushNotificationManager.Initialize(this, false);

    }
}
