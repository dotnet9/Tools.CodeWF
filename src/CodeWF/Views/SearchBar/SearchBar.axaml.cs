using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace CodeWF.Views.SearchBar;

public partial class SearchBar : UserControl
{
    public SearchBar()
    {
        InitializeComponent();
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }
}