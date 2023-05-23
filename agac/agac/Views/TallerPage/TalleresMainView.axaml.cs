using agac.ApiController;
using agac.Controls;
using agac.Managers;
using agac.Models;
using agac.Views.TareasPage;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using System.Collections.ObjectModel;

namespace agac.Views.TallerPage;

public partial class TalleresMainView : PageControl
{
    ObservableCollection<TallerModel> _talleres;
    public ObservableCollection<TallerModel> talleres
    {
        get { return _talleres; }
        set
        {
            _talleres = value;
            OnPropertyChanged("talleres");
        }
    }

    CursoModel _curso;
    public CursoModel curso
    {
        get { return _curso; }
        set
        {
            _curso = value;
            OnPropertyChanged("curso");
        }
    }

    public TalleresMainView()
    {
        InitializeComponent();
        DataContext = this;
    }

    protected override void OnLoaded()
    {
        base.OnLoaded();
        onLoadTalleres();
    }

    protected override void OnUnloaded()
    {
        base.OnUnloaded();
    }

    async void onLoadTalleres()
    {
        if(curso == null)
        {
            return;
        }

        Title = curso.nombre;

        await DialogManager.Show();
        talleres = new ObservableCollection<TallerModel>(await ApiTaller.Get(curso.codigo));
        await DialogManager.Close();
    }

    public async void onTaller(object obj)
    {
        TallerModel item = obj as TallerModel;

        TareasMainView page = new TareasMainView();
        page.taller = item;

        await AppManager.ToNatigate(page);
    }
}