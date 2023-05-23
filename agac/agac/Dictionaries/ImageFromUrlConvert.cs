using Avalonia.Data.Converters;
using Avalonia.Media.Imaging;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace agac.Dictionaries
{
    public class ImageFromUrlConvert : AsyncConverter<Bitmap>
    {
        public override async Task<Bitmap> AsyncConvert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string _url = value?.ToString() ?? "";
            string _default = parameter?.ToString() ?? "";

            if (string.IsNullOrEmpty(_url))
            {
                if (!string.IsNullOrEmpty(_default))
                {
                    return ImageManager.Assets(_default);
                }

                return ImageManager.Assets("profile.png");
            }


            return await ImageManager.FromURL(_url);
        }
    }

    public abstract class AsyncConverter<T> : IValueConverter
    {
        public abstract Task<T> AsyncConvert(object value, Type targetType, object parameter, CultureInfo culture);

        public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            try
            {
                var res = new GenericAsyncViewModel();
                res.Start(AsyncConvert(value, targetType, parameter, culture));
                return res;

            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                return ImageManager.Assets("profile.png");
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
        class GenericAsyncViewModel : INotifyPropertyChanged
        {
            private T _result;
            public event PropertyChangedEventHandler PropertyChanged;

            public T Result
            {
                get => _result;
                set
                {
                    _result = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Result)));
                }
            }

            public async void Start(Task<T> task)
            {
                Result = await task;
            }

        }
    }
}
