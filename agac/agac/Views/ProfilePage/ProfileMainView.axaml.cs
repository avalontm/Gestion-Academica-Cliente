using agac.Controls;
using agac.Managers;
using agac.Models;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

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
}