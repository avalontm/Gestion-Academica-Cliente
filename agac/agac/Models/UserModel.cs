using agac.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace agac.Models
{
    public class UserModel
    {

        public int carrera_id { set; get; }
        public int role_id { set; get; }
        public string? codigo { set; get; }
        public string? nombre { set; get; }
        public string? email { set; get; }

        public string? avatar { set; get; }

        public string? rol_nombre { set; get; }
    }
}
