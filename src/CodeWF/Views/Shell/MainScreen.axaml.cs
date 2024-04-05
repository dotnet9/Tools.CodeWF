using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace CodeWF.Views.Shell;

public partial class MainScreen : UserControl
{
    public MainScreen()
    {
        InitializeComponent();
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }
}