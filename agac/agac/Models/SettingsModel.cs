using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace agac.Models
{
    public class SettingsModel
    {
        public UserModel? User { set; get; }
        public string? Token { set; get; }
    }
}
