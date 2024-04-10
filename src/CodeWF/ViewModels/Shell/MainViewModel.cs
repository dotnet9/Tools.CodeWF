using CodeWF.Common;

namespace CodeWF.ViewModels.Shell
{
    public class MainViewModel : ViewModelBase
    {
        public string Title => AppInfo.ToolName;
        public IObservable<bool> IsMainContentEnabled { get; }
    }
}