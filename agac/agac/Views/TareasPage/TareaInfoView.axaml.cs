using agac.ApiController;
using agac.Controls;
using agac.Models;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

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
}