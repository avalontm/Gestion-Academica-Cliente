using agac.Managers;
using agac.Models;
using agac.Views.LoginPage;
using agac.Views.MainPage;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Newtonsoft.Json;
using System.ComponentModel;
using System.Diagnostics;
using System.Threading.Tasks;

namespace agac.Views;

public partial class LoadingView : UserControl, INotifyPropertyChanged
{
    public new event PropertyChangedEventHandler? PropertyChanged;

    protected void OnPropertyChanged(string name)
    {
        PropertyChangedEventHandler? handler = PropertyChanged;
        if (handler != null)
        {
            handler(this, new PropertyChangedEventArgs(name));
        }
    }

    string _message = "";
    public string Message
    {
        get { return _message; }
        set
        {
            _message = value;
            OnPropertyChanged("Message");
        }
    }

    bool isAnimation;

    public LoadingView()
    {
        InitializeComponent();
        isAnimation = true;
        DataContext = this;
    }

    protected override void OnLoaded()
    {
        base.OnLoaded();
        onLoading();
    }

    async Task onAnimation()
    {
        bool isReverse = false;

        while (isAnimation)
        {
            if (!isReverse)
            {
                imgLogo.Height += 2;
                imgLogo.Width += 2;

                await Task.Delay(50);

                if (imgLogo.Height > 220 || imgLogo.Width > 220)
                {
                    imgLogo.Height = 220;
                    imgLogo.Width = 220;
                    isReverse = true;
                }
            }
            else if (isReverse)
            {
                imgLogo.Height -= 2;
                imgLogo.Width -= 2;

                await Task.Delay(50);

                if (imgLogo.Height < 200 || imgLogo.Width < 200)
                {
                    imgLogo.Height = 200;
                    imgLogo.Width = 200;
                    isReverse = false;
                }
            }
        }
    }

    async Task onLoading()
    {
        UserModel user = null;
        onAnimation();

        //Cargamos la configuracion
        SettingsManager.Load();

        if (string.IsNullOrEmpty(SettingsManager.Settings?.Token))
        {
            await AppManager.ToPage(new LoginMainView());
            isAnimation = false;
            return;
        }

        ApiManager.onSetToken(SettingsManager.Settings?.Token);

        user = await ApiManager.onAuth();

        Debug.WriteLine($"[AUTH] {JsonConvert.SerializeObject(user)}");

        if (user == null)
        {
            await AppManager.ToPage(new LoginMainView());
            isAnimation = false;
            return;
        }

        bool device_register = await SesionManager.onDevice();

        if(device_register)
        {
            Debug.WriteLine($"[Device] Se registro correctamente.");
        }

        SesionManager.onSetSesion(user, SettingsManager.Settings?.Token);

        await AppManager.ToPage(new MainViewControl());
        isAnimation = false;
    }


}