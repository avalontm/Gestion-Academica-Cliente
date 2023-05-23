using agac.Controls;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace agac.Views.ProfilePage;

public partial class ProfileMainView : PageControl
{
    public ProfileMainView()
    {
        InitializeComponent();
        DataContext = this;
    }
}