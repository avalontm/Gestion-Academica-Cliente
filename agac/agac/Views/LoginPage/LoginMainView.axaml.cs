using agac.Managers;
using agac.Models;
using agac.Views.MainPage;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Markup.Xaml;
using System.Diagnostics;

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

        UserModel user = response.data[0].ToConvert<UserModel>();
        string token = response.data[1].ToString();

        SesionManager.onSetSesion(user, token);

        if (SesionManager.isLogin)
        {
            await AppManager.ToPage(new MainViewControl());
        }

    }
}