using agac.Controls;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace agac.Views.HomePage;

public partial class HomeMainView : PageControl
{
    public HomeMainView()
    {
        InitializeComponent();
        DataContext = this;

    }
}