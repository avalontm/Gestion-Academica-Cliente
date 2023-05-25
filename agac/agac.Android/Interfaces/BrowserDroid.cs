using agac.Interfaces;
using Android.App;
using Android.Content;
using Android.Net;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace agac.Android.Interfaces
{
    public class BrowserDroid : IBrowserManager
    {
        public void OpenAsync(string url)
        {
            try
            {
                Intent browserIntent = new Intent(Intent.ActionView, Uri.Parse(url));
                browserIntent.AddFlags(ActivityFlags.NewTask);
                Application.Context.StartActivity(browserIntent);
            }
            catch(System.Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }
    }
}
