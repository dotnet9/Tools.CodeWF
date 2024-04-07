using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using CodeWF.ViewModels.Navbar;

namespace CodeWF.Views.Navbar;

public partial class Navbar : UserControl
{
    private NavbarViewModel _viewModel;

    public NavbarViewModel ViewModel
    {
        get => _viewModel;
        set
        {
            _viewModel = value;
            this.DataContext = _viewModel;
        }
    }

    public Navbar()
    {
        if (!Design.IsDesignMode)
        {
            this.ViewModel = new NavbarViewModel();
        }

        InitializeComponent();
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }
}