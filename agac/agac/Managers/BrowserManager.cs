using agac.Interfaces;
using Splat;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace agac
{
    public static class BrowserManager
    {
        public static async Task OpenAsync(string url)
        {
            try
            {
                Locator.Current.GetService<IBrowserManager>().OpenAsync(url);
            }
            catch
            {

            }
            Debug.WriteLine($"[LINK] {url}");
        }
    }
}
