using Plugin.DeviceInfo;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using agac.Models;
using Plugin.FirebasePushNotification;

namespace agac.Managers
{
    public static class SesionManager
    {
        public static UserModel? user { private set; get; }
        public static bool isLogin { private set; get; }
        public static string? token { private set; get; }

        public static void onSetSesion(UserModel? _user, string _token = "")
        {
            user = _user;

            if (user != null)
            {
                token = _token;
                isLogin = true;
            }
            else
            {
                token = string.Empty;
                isLogin = false;
            }

            SettingsManager.Settings.User = user;
            SettingsManager.Settings.Token = token;
            SettingsManager.Save();
            ApiManager.onSetToken(token);
        }


        public static async Task<bool> onDevice()
        {
            if (CrossFirebasePushNotification.IsSupported)
            {
                //Suscripción al tipico general
                CrossFirebasePushNotification.Current.Subscribe("general");

                //Registramos el dispositivo para que reciba notificaciones del servidor.
                string token = CrossFirebasePushNotification.Current.Token;
                string model = CrossDeviceInfo.Current.Model;
                string name = CrossDeviceInfo.Current.DeviceName;
                string platform = CrossDeviceInfo.Current.Platform.ToString();

                PostModel post = new PostModel();
                post.data.Add(name);
                post.data.Add(model);
                post.data.Add(platform);
                post.data.Add(token);

                var response = await ApiUser.Device(post);

                if (!response.status)
                {
                    Debug.WriteLine($"[Response] {response.message}");
                    return false;
                }

                return true;
            }

            return true;
        }
    }
}
