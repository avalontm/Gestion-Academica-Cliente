using agac.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace agac.ApiController
{
    public static class ApiCurso
    {
        public static async Task<List<CursoModel>> Get()
        {
            try
            {
                return await ApiManager.client.GetAsync<List<CursoModel>>("curso");
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
