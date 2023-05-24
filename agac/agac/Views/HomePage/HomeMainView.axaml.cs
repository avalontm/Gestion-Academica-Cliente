using agac.ApiController;
using agac.Controls;
using agac.Managers;
using agac.Models;
using agac.Views.TareasPage;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using System;
using System.Collections.ObjectModel;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace agac.Views.HomePage;

public partial class HomeMainView : PageControl
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

    DateTime _date;
    public DateTime date
    {
        get { return _date; }
        set
        {
            _date = value;
            OnPropertyChanged("date");
        }
    }

    public HomeMainView()
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
        date = DateTime.Now;

        Title = string.Format("Calendario {0}", date.ToString("dd-MM-yyyy"));

        await DialogManager.Show();
        tareas = new ObservableCollection<TareaModel>(await ApiCalendario.Get());
        await DialogManager.Close();
    }

    public async void onTarea(object obj)
    {
        TareaModel item = obj as TareaModel;

        TareaInfoView page = new TareaInfoView();
        page.tarea = item;

        await AppManager.ToNatigate(page);
    }
}