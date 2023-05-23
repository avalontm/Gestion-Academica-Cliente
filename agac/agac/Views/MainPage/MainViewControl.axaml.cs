using agac.Controls;
using agac.Views.CursosPage;
using agac.Views.HomePage;
using agac.Views.ProfilePage;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using System.ComponentModel;
using System.Threading.Tasks;

namespace agac.Views.MainPage;

public partial class MainViewControl : UserControl, INotifyPropertyChanged
{
    public new event PropertyChangedEventHandler? PropertyChanged;

    protected void OnPropertyChanged(string name)
    {
        PropertyChangedEventHandler handler = PropertyChanged;
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
            OnPropertyChanged("Title");
        }
    }

    bool _isOpen;
    public bool IsOpen
    {
        get { return _isOpen; }
        set
        {
            _isOpen = value;
            OnPropertyChanged("IsOpen");
        }
    }

    bool _UseSafeArea;
    public bool UseSafeArea
    {
        get { return _UseSafeArea; }
        set
        {
            _UseSafeArea = value;
            OnPropertyChanged("UseSafeArea");
        }
    }

    public static MainViewControl? Instance { private set; get; }

    public MainViewControl()
    {
        InitializeComponent();
        DataContext = this;
    }

    protected override void OnLoaded()
    {
        Instance = this;
        ToNavigate(new HomeMainView());
        base.OnLoaded();
    }

    protected override void OnUnloaded()
    {
        Instance = this;
        base.OnUnloaded();
    }

    public void ToNavigate(PageControl control)
    {
        this.Title = control.Title;
        gridMain.Children.Clear();
        gridMain.Children.Add(control);
    }


    public async void MenuCalendar()
    {
        ToNavigate(new HomeMainView());
        await Task.Delay(10);
    }

    public async void MenuCursos()
    {
        ToNavigate(new CursosMainView());
        await Task.Delay(10);
    }

    public async void MenuPropile()
    {
        ToNavigate(new ProfileMainView());
        await Task.Delay(10);
    }

}