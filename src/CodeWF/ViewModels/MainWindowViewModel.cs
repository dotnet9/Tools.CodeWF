using CodeWF.Common;

namespace CodeWF.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    public string Title => AppInfo.ToolName;
}