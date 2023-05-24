using Avalonia.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using agac.Views.MainPage;
using Avalonia;
using Avalonia.Metadata;
using agac.Models;

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

        List<ToolbarModel> _toolbar;
        public List<ToolbarModel> Toolbar
        {
            get { return _toolbar; }
            set
            {
                _toolbar = value;
                if (MainViewControl.Instance != null)
                {
                    MainViewControl.Instance.Toolbar = _toolbar;
                }
                OnPropertyChanged("Toolbar");
            }
        }

        protected override void OnLoaded()
        {
            base.OnLoaded();
            OnToolbar();

            if (MainViewControl.Instance != null)
            {
                MainViewControl.Instance.Title = Title;
            }
        }

        public virtual void OnToolbar()
        {
            if (MainViewControl.Instance != null)
            {
                if (Toolbar == null)
                {
                    MainViewControl.Instance.Toolbar = null;
                    return;
                }

                MainViewControl.Instance.Toolbar = new List<ToolbarModel>(Toolbar);
                
            }
        }
    }
}
