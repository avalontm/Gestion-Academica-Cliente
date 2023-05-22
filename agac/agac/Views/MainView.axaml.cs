using Avalonia.Controls;

namespace agac.Views
{
    public partial class MainView : UserControl
    {
        public static MainView? Instance { get; private set; }

        public MainView()
        {
            InitializeComponent();
            Instance = this;
            DataContext = this;
        }

        protected override void OnLoaded()
        {
            base.OnLoaded();
            ToPage(new LoadingView());
        }

        public void ToPage(UserControl control)
        {
            gridMain.Children.Clear();
            gridMain.Children.Add(control);
        }
    }
}