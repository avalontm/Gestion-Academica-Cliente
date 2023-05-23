using agac.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace agac
{
    public static class ApiUser
    {
        public static async Task<ResponseModel> Device(PostModel model)
        {
            try
            {
                return await ApiManager.client.PostAsync<ResponseModel>("user/device", model);
            }
            catch (Exception ex)
            {
                return new ResponseModel() { status = false, title = "Error", message = ex.Message };
            }
        }
    }
}
