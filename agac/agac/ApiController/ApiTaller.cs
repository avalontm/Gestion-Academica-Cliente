using agac.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace agac.ApiController
{
    public static class ApiTaller
    {
        public static async Task<List<TallerModel>> Get(string curso_codigo)
        {
            try
            {
                return await ApiManager.client.GetAsync<List<TallerModel>>($"taller/{curso_codigo}");
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
