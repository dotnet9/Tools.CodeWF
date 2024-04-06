using CodeWF.ViewModels.SearchBar.Patterns;
using CodeWF.ViewModels.SearchBar.SearchItems;
using DynamicData;
using DynamicData.Binding;
using ReactiveUI;
using System.Collections.ObjectModel;
using System.Reactive.Disposables;
using System.Reactive.Linq;

namespace CodeWF.ViewModels.SearchBar;

public class SearchItemGroup : IDisposable
{
    private readonly CompositeDisposable _disposables = new();
    private readonly ReadOnlyObservableCollection<ISearchItem> _items;

    public SearchItemGroup(string title, IObservable<IChangeSet<ISearchItem, ComposedKey>> changes)
    {
        Title = title;
        changes
            .Sort(SortExpressionComparer<ISearchItem>.Ascending(x => x.Priority))
            .Bind(out _items)
            .DisposeMany()
            .ObserveOn(RxApp.MainThreadScheduler)
            .Subscribe()
            .DisposeWith(_disposables);
    }

    public string Title { get; }

    public ReadOnlyObservableCollection<ISearchItem> Items => _items;

    public void Dispose()
    {
        _disposables.Dispose();
    }
}