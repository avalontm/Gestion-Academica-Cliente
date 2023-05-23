using agac.Models;
using PluginAPI;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace agac
{
    public static class ApiManager
    {
#if DEBUG
        public readonly static string HOST = "https://avalontm.info"; //"http://192.168.1.13";
#else
        public readonly static string HOST = "https://avalontm.info";
#endif

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
                return null;
            }
        }

    }
}
