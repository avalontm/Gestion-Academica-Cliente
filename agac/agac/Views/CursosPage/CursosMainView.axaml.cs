using agac.Controls;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace agac.Views.CursosPage;

public partial class CursosMainView : PageControl
{
    public CursosMainView()
    {
        InitializeComponent();
        DataContext = this;
    }
}