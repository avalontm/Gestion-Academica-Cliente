using agac.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace agac.Managers
{
    public static class SettingsManager
    {
        static string Root = Environment.GetFolderPath(Environment.SpecialFolder.Personal);

        public static SettingsModel? Settings { private set; get; }

        static string fileConfig = "sga_config.json";

        public static bool Load()
        {
            try
            {
                Debug.WriteLine($"[ROOT] {Root}");

                if (File.Exists(Path.Combine(Root, fileConfig)))
                {
                    string data = File.ReadAllText(Path.Combine(Root, fileConfig));
                    Settings = JsonConvert.DeserializeObject<SettingsModel>(data);
                }

                if (Settings == null)
                {
                    Settings = new SettingsModel();
                    Save();
                }

                return true;
            }
            catch (Exception ex)
            {
                Settings = new SettingsModel();
                Debug.WriteLine($"[Load] {ex}");
                return false;
            }
        }

        public static bool Save()
        {
            try
            {
                File.WriteAllText(Path.Combine(Root, fileConfig), JsonConvert.SerializeObject(Settings, Formatting.Indented));
                return true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"[Save] {ex}");
                return false;
            }
        }
    }
}
