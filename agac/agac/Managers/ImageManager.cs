using Avalonia.Media.Imaging;
using Avalonia.Platform;
using Avalonia;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace agac
{
    public class ImageManager
    {
        public static Bitmap StringFromResource(string file)
        {
            return Assets(file);
        }

        public static Bitmap SourceFromResource(string file)
        {
            return Assets(file);
        }

        public static async Task<Bitmap> FromURL(string url)
        {
            if (string.IsNullOrEmpty(url))
            {
                return null;
            }

            try
            {
                using (HttpClient client = new HttpClient())
                {
                    var request = new HttpRequestMessage(HttpMethod.Get, url);
                    request.Headers.Add("mode", "no-cors");
                    request.Headers.Add("credentials", "omit");

                    var response = await client.SendAsync(request);
                    response.EnsureSuccessStatusCode();

                    using (HttpContent content = response.Content)
                    {
                        Stream stream = await response.Content.ReadAsStreamAsync();

                        return new Bitmap(stream);
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"[FromURL] {ex}");
                return null;
            }
        }

        public static Bitmap Assets(string file)
        {
            Uri uri;

            // Allow for assembly overrides
            if (file.StartsWith("avares://"))
            {
                uri = new Uri(file);
            }
            else
            {
                uri = new Uri($"avares://agac/Assets/{file}");
            }

            var assets = AvaloniaLocator.Current.GetService<IAssetLoader>();
            var asset = assets.Open(uri);

            return new Bitmap(asset);
        }
    }
}
