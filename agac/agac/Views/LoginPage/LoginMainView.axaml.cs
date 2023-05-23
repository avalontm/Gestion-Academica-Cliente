using agac.Managers;
using agac.Models;
using agac.Views.MainPage;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Markup.Xaml;

namespace agac.Views.LoginPage;

public partial class LoginMainView : UserControl
{
    string _email;
    public string email
    {
        set
        {
            _email = value;
            //OnPropertyChanged();
        }
        get { return _email; }
    }

    string _password;
    public string password
    {
        set
        {
            _password = value;
            //OnPropertyChanged();
        }
        get { return _password; }
    }

    public LoginMainView()
    {
        InitializeComponent();
        email = SettingsManager.Settings.Account;
        password = SettingsManager.Settings.Password;

        DataContext = this;
    }

    private void onKeyEnter(object? sender, KeyEventArgs e)
    {
        if (e.Key == Key.Enter)
        {
            LoginCommand();
        }
    }

    public async void LoginCommand()
    {
        await DialogManager.Show("Iniciando sesion");

        CuentaModel model = new CuentaModel();
        model.email = email;
        model.password = password;
        var response = await ApiManager.onLogin(model);
        await DialogManager.Close();

        if (!response.status)
        {
            await DialogManager.Display(response.title, response.message, "OK");
            return;
        }

        string token = response.data[1].ToString();
        SesionManager.onSetSesion(response.data[0].ToConvert<UserModel>(), token);

        if (SesionManager.isLogin)
        {
            SettingsManager.Settings.Account = email;
            SettingsManager.Settings.Password = password;
            SettingsManager.Settings.Token = token;
            SettingsManager.Save();
            await AppManager.ToPage(new MainViewControl());
        }

    }
}