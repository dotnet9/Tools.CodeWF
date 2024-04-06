using System.Reactive;
using System.Windows.Input;

namespace CodeWF.ViewModels.SearchBar;

public partial class SearchBarViewModel : ViewModelBase
{
    [AutoNotify] private string _searchText = "";

    public IObservable<Unit> CommandActivated { get; }

    public ICommand ResetCommand { get; }

    public ICommand ActivateFirstItemCommand { get; set; }
}