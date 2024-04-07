using System.Collections.ObjectModel;

namespace CodeWF.ViewModels.Navbar.NavItems;

public class ToolMenuItem
{
    public ToolType Group { get; set; }
    public int Level { get; set; }
    public string? Header { get; set; }
    public string? Description { get; set; }
    public string? ViewName { get; set; }
    public ToolStatus Status { get; set; }
    public string? Icon { get; set; }
    public bool IsSeparator { get; set; }

    public ObservableCollection<ToolMenuItem> Children { get; set; } = new();

    public override string ToString()
    {
        return $"{Header}";
    }
}