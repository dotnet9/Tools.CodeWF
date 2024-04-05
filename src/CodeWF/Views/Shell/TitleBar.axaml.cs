using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace CodeWF.Views.Shell;

public partial class TitleBar : UserControl
{
    public TitleBar()
    {
        InitializeComponent();
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }
}