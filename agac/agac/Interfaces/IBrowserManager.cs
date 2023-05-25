using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace agac.Interfaces
{
    public interface IBrowserManager
    {
        public void OpenAsync(string url);
    }
}
