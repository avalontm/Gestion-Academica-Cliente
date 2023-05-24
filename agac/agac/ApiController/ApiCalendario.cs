using agac.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace agac.ApiController
{
    public static class ApiCalendario
    {

        public static async Task<List<TareaModel>> Get()
        {
            try
            {
                return await ApiManager.client.GetAsync<List<TareaModel>>($"calendario");
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }

}
