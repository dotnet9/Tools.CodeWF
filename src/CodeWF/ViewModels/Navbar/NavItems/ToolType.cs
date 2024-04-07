using System.ComponentModel;

namespace CodeWF.ViewModels.Navbar.NavItems;

public enum ToolType
{
    [Description("Home")] Home,
    [Description("开发类")] Developer,
    [Description("网站开发")] Web,
    [Description("图片处理")] Image,
    [Description("测试")] Test,
    [Description("未分类")] Other
}