using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using agac.Dialogs;

namespace agac
{
    public class DialogManager
    {
        public static async Task Show(string message = "")
        {
            WaitDialogView.Instance.Show(message);
        }

        public static async Task Close()
        {
            WaitDialogView.Instance.Close();
        }

        public static async Task<bool> Display(string title, string message, string accept = "OK", string cancel = "")
        {
            await DialogView.Instance.Show(title, message, accept, cancel);
            return DialogView.Instance.Response;
        }
    }
}
