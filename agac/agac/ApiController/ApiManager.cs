using agac.Models;
using PluginAPI;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace agac.ApiController
{
    public static class ApiManager
    {
#if DEBUG
        public readonly static string HOST = "http://192.168.1.104"; //"http://192.168.1.241:8080";
#else
        public readonly static string HOST = "http://mollusca.com.mx";
#endif

        static WebClientManager _delivery;
        public static WebClientManager delivery => _delivery ?? (_delivery = new WebClientManager(string.Format("{0}/delivery", HOST)));

        static WebClientManager _client;
        public static WebClientManager client => _client ?? (_client = new WebClientManager(string.Format("{0}/api", HOST)));

        public static void onSetToken(string token)
        {
            client.CreateToken(token);
        }


        public static async Task<ResponseModel> onLogin(CuentaModel item)
        {
            try
            {
                return await client.PostAsync<ResponseModel>("auth", item);
            }
            catch (Exception ex)
            {
                return new ResponseModel() { status = false, title = "Error", message = ex.Message };
            }
        }

        public static async Task<UserModel> onAuth()
        {
            try
            {
                return await client.GetAsync<UserModel>("auth");
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"[onAuth] {ex}");
                return null;
            }
        }

    }
}
