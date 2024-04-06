namespace CodeWF.ViewModels.SearchBar.SearchItems;

public interface IActionableItem : ISearchItem
{
    Func<Task> Activate { get; }
}