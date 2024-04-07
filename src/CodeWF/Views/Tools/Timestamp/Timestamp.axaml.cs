using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace CodeWF;

public partial class Timestamp : UserControl
{
    public Timestamp()
    {
        InitializeComponent();
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }
}