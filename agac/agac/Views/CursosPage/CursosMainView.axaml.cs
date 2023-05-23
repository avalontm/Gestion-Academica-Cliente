using agac.ApiController;
using agac.Controls;
using agac.Managers;
using agac.Models;
using agac.Views.TallerPage;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;

namespace agac.Views.CursosPage;

public partial class CursosMainView : PageControl
{
    ObservableCollection<CursoModel> _cursos;
    public ObservableCollection<CursoModel> cursos
    {
        get { return _cursos; }
        set
        {
            _cursos = value;
            OnPropertyChanged("cursos");
        }
    }

    public CursosMainView()
    {
        InitializeComponent();
        DataContext = this;
    }

    protected override void OnLoaded()
    {
        base.OnLoaded();
        onLoadCursos();
    }

    protected override void OnUnloaded()
    {
        base.OnUnloaded();
    }

    async void onLoadCursos()
    {
        await DialogManager.Show();
        cursos = new ObservableCollection<CursoModel>(await ApiCurso.Get());
        await DialogManager.Close();
    }

    public async void onCurso(object obj)
    {
        CursoModel item = obj as CursoModel;

        TalleresMainView page = new TalleresMainView();
        page.curso = item;

        await AppManager.ToNatigate(page);
    }
}