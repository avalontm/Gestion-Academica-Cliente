using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace agac
{
    public static class JsonExtention
    {
        public static T ToConvert<T>(this object obj)
        {
            return JsonConvert.DeserializeObject<T>(obj.ToString());
        }

        public static string FromConvert(this object obj)
        {
            return JsonConvert.SerializeObject(obj);
        }
    }
}
