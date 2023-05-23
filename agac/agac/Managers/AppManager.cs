using agac.Controls;
using agac.Views.MainPage;
using agac.Views;
using Avalonia.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace agac.Managers
{
    public static class AppManager
    {
        public static NavigationManager navManager { private set; get; } = new NavigationManager();

        public static async Task ToPage(UserControl control)
        {
            navManager.Clear();
            MainView.Instance.ToPage(control);
            await Task.Delay(10);
        }

        public static async Task ToNatigate(PageControl page, bool root = false)
        {
            if (root)
            {
                navManager.SetRoot(page);
            }
            else
            {
                navManager.Add(page);
            }

            MainViewControl.Instance.ToNavigate(page);
            await Task.Delay(10);
        }

        public static async Task ToBack()
        {
            if (navManager.Count > 0)
            {
                var page = navManager.LastOrDefault();

                if (page != null)
                {
                    navManager.Remove(page);

                    page = navManager.LastOrDefault();

                    if (page != null)
                    {
                        MainViewControl.Instance.ToNavigate(page);
                    }
                    else
                    {
                        var rootPage = navManager.root;

                        if (rootPage != null)
                        {
                            MainViewControl.Instance.ToNavigate(rootPage);
                        }
                    }
                }
            }
            await Task.Delay(10);


        }
    }
}
