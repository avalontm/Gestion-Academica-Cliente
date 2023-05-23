using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace agac.Models
{
    public class TareaModel
    {
        public string? codigo { set; get; }
        public string? titulo { set; get; }
        public DateTime fecha_entrega { set; get; }
        public string? contenido { set; get; }
        public int limite { set; get; }
        public bool activo { set; get; }
    }
}
