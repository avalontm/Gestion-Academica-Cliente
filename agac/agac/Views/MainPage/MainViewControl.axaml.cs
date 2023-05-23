using agac.Controls;
using agac.Managers;
using agac.Models;
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

    UserModel _user;
    public UserModel User
    {
        get { return _user; }
        set
        {
            _user = value;
            OnPropertyChanged("User");
        }
    }

    public static MainViewControl? Instance { private set; get; }

    public MainViewControl()
    {
        InitializeComponent();
        Instance = this;
        DataContext = this;
    }

    protected override void OnLoaded()
    {
        Instance = this;
        User = SesionManager.user;
        MenuCalendar();
        base.OnLoaded();
    }

    protected override void OnUnloaded()
    {
        Instance = null;
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
        await AppManager.ToNatigate(new HomeMainView(), true);
    }

    public async void MenuCursos()
    {
        await AppManager.ToNatigate(new CursosMainView(), true);
    }

    public async void MenuPropile()
    {
        await AppManager.ToNatigate(new ProfileMainView(), true);
    }

    public async void onBack()
    {
        await AppManager.ToBack();
    }
}