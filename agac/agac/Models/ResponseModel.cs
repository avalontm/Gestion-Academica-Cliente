using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace agac.Models
{
    public class ResponseModel
    {
        public bool status { set; get; }
        public string title { set; get; }
        public string message { set; get; }
        public List<object> data { set; get; }

        public ResponseModel()
        {
            data = new List<object>();
        }
    }
}
