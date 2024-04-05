using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace CodeWF.Views.Shell
{
    public class Shell : UserControl
    {
        public Shell()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}