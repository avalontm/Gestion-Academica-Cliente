using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
namespace agac.Views.CameraPage;

public partial class CameraView : UserControl
{

    public CameraView()
    {
        InitializeComponent();
        DataContext = this;
    }

    void onLoadCamera()
    {

    }
}
