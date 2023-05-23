using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace agac.Models
{
    public class PostModel
    {
        public List<object> data { get; set; }

        public PostModel()
        {
            data = new List<object>();
        }
    }
}
