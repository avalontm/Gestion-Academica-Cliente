using Avalonia.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using agac.Views.MainPage;

namespace agac.Controls
{
    public class PageControl : UserControl, INotifyPropertyChanged
    {
        public new event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler? handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }

        string _title;
        public string Title
        {
            get { return _title; }
            set
            {
                _title = value;
                if (MainViewControl.Instance != null)
                {
                    MainViewControl.Instance.Title = _title;
                }
                OnPropertyChanged("Title");
            }
        }


        protected override void OnLoaded()
        {
            base.OnLoaded();
            if (MainViewControl.Instance != null)
            {
                MainViewControl.Instance.Title = Title;
            }
        }
    }
}
