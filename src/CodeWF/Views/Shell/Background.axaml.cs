using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace CodeWF.Views.Shell;

public class Background : UserControl
{
    public Background()
    {
        InitializeComponent();
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }
}