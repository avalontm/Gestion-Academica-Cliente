using agac.ApiController;
using agac.Controls;
using agac.Models;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.Threading;
using System;
using System.Diagnostics;
using TheArtOfDev.HtmlRenderer.Avalonia;
using TheArtOfDev.HtmlRenderer.Core.Entities;

namespace agac.Views.TareasPage;

public partial class TareaInfoView : PageControl
{
    TareaModel _tarea;
    public TareaModel tarea
    {
        get { return _tarea; }
        set
        {
            _tarea = value;
            OnPropertyChanged("tarea");
        }
    }

    public TareaInfoView()
    {
        InitializeComponent();
        _htmlPanel.LinkClicked += OnLinkClicked;
        _htmlPanel.LoadComplete += (sender, args) => _htmlPanel.ScrollToElement("C4");
        DataContext = this;
    }

    protected override void OnLoaded()
    {
        base.OnLoaded();
        onLoadTarea();
    }

    async void onLoadTarea()
    {
        _htmlPanel.Text = tarea.contenido;
    }


    /// <summary>
    /// On specific link click handle it here.
    /// </summary>
    async void OnLinkClicked(object sender, HtmlRendererRoutedEventArgs<HtmlLinkClickedEventArgs> args)
    {
        await BrowserManager.OpenAsync(args.Event.Link);
    }
}