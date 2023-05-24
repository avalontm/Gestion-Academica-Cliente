using agac.Controls;
using agac.Managers;
using agac.Models;
using agac.Views.LoginPage;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Plugin.FirebasePushNotification;
using ReactiveUI;
using System.Diagnostics;
using System.Threading.Tasks;

namespace agac.Views.ProfilePage;

public partial class ProfileMainView : PageControl
{
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

    public ProfileMainView()
    {
        InitializeComponent();
        DataContext = this;
    }

    protected override void OnLoaded()
    {
        User = SesionManager.user;
        onLoadUser();
        base.OnLoaded();
    }

    async void onLoadUser()
    {
        await DialogManager.Show();
        User = await ApiManager.onAuth();
        await DialogManager.Close();
    }

    public override void OnToolbar()
    {
        Toolbar = new System.Collections.Generic.List<ToolbarModel>();
        Toolbar.Add(new ToolbarModel() { icon = ImageManager.SourceFromResource("icon_off.png"), command = ReactiveCommand.Create(onLogout) });
        base.OnToolbar();
    }

    async void onLogout()
    {
        bool status = await DialogManager.Display("Confirmar", "¿Esta seguro que desea cerrar sesion?", "SI", "NO");

        if (!status)
        {
            return;
        }

        await DialogManager.Show();
        SesionManager.onSetSesion(null);

        //Damos de baja el tipico general
        CrossFirebasePushNotification.Current.Unsubscribe("general");

        await Task.Delay(1000);
        await AppManager.ToPage(new LoginMainView());
        await DialogManager.Close();
    }
}