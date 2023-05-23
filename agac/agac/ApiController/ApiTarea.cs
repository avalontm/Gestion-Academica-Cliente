using agac.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace agac.ApiController
{
    public static  class ApiTarea
    {
        public static async Task<List<TareaModel>> Get(string taller_codigo)
        {
            try
            {
                return await ApiManager.client.GetAsync<List<TareaModel>>($"tarea/{taller_codigo}");
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
