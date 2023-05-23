using agac.ApiController;
using agac.Controls;
using agac.Models;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Markup.Xaml;
using System.Collections.ObjectModel;

namespace agac.Views.TareasPage;

public partial class TareasMainView : PageControl
{
    ObservableCollection<TareaModel> _tareas;
    public ObservableCollection<TareaModel> tareas
    {
        get { return _tareas; }
        set
        {
            _tareas = value;
            OnPropertyChanged("tareas");
        }
    }

    TallerModel _taller;
    public TallerModel taller
    {
        get { return _taller; }
        set
        {
            _taller = value;
            OnPropertyChanged("taller");
        }
    }

    public TareasMainView()
    {
        InitializeComponent();
        DataContext = this;
    }

    protected override void OnLoaded()
    {
        base.OnLoaded();
        onLoadTareas();
    }

    protected override void OnUnloaded()
    {
        base.OnUnloaded();
    }

    async void onLoadTareas()
    {
        if (taller == null)
        {
            return;
        }

        Title = taller.nombre;

        await DialogManager.Show();
        tareas = new ObservableCollection<TareaModel>(await ApiTarea.Get(taller.codigo));
        await DialogManager.Close();
    }

    public void onTarea(object obj)
    {

    }
}