using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace CodeWF;

public partial class Dashboard : UserControl
{
    public Dashboard()
    {
        InitializeComponent();
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }
}