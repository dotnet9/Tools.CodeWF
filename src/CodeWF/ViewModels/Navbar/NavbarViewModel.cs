﻿using CodeWF.Extensions;
using CodeWF.ViewModels.Navbar.NavItems;
using CodeWF.ViewModels.SearchBar.Patterns;
using CodeWF.ViewModels.SearchBar.SearchItems;
using CodeWF.ViewModels.SearchBar;
using DynamicData;
using System.Collections.ObjectModel;

namespace CodeWF.ViewModels.Navbar;

public class NavbarViewModel : ViewModelBase
{
    public IEnumerable<ToolMenuItem> MenuItems { get; } = new List<ToolMenuItem>()
    {
        new ToolMenuItem()
        {
            Group = ToolType.Home,
            Level = 0,
            Header = "首页",
            Description =
                "这是一个基于Avalonia UI + Prism框架打造的模块化跨平台工具平台，汇聚了众多开发实用小工具，目前已开发或即将开发的如编码解码、数据加密等，轻量且强大，开箱即用，助力开发者提升工作效率。",
            ViewName = nameof(Dashboard),
            Icon =
                "M217.6 659.2c0-19.2-6.4-38.4-19.2-51.2s-32-25.6-51.2-25.6c-19.2 0-38.4 12.8-51.2 25.6-12.8 12.8-25.6 32-25.6 51.2 0 19.2 6.4 38.4 19.2 51.2s32 19.2 51.2 19.2c19.2 0 38.4-6.4 51.2-19.2s25.6-32 25.6-51.2z m108.8-256c0-19.2-6.4-38.4-19.2-51.2s-32-25.6-51.2-25.6c-19.2 0-38.4 6.4-51.2 19.2s-19.2 38.4-19.2 57.6c0 19.2 6.4 38.4 19.2 51.2 12.8 12.8 32 19.2 51.2 19.2 19.2 0 38.4-6.4 51.2-19.2s19.2-32 19.2-51.2zM576 678.4l57.6-217.6c0-12.8 0-19.2-6.4-25.6-6.4-12.8-12.8-19.2-19.2-19.2H576c-6.4 6.4-12.8 12.8-12.8 25.6l-57.6 217.6c-25.6 0-44.8 12.8-64 25.6-19.2 12.8-32 32-38.4 57.6-6.4 32-6.4 57.6 12.8 83.2 12.8 25.6 38.4 44.8 64 51.2s57.6 6.4 83.2-12.8c25.6-12.8 44.8-38.4 51.2-64 6.4-25.6 6.4-44.8-6.4-64 0-25.6-12.8-44.8-32-57.6z m377.6-19.2c0-19.2-6.4-38.4-19.2-51.2-12.8-12.8-32-19.2-51.2-19.2-19.2 0-38.4 6.4-51.2 19.2-12.8 12.8-19.2 32-19.2 51.2 0 19.2 6.4 38.4 19.2 51.2 12.8 12.8 32 19.2 51.2 19.2 19.2 0 38.4-6.4 51.2-19.2 6.4-12.8 19.2-32 19.2-51.2zM582.4 294.4c0-19.2-6.4-38.4-19.2-51.2-12.8-19.2-32-25.6-51.2-25.6-19.2 0-38.4 6.4-51.2 19.2-12.8 19.2-19.2 38.4-19.2 57.6 0 19.2 6.4 38.4 19.2 51.2 12.8 12.8 32 19.2 51.2 19.2 19.2 0 38.4-6.4 51.2-19.2 12.8-12.8 19.2-32 19.2-51.2z m256 108.8c0-19.2-6.4-38.4-19.2-51.2-12.8-12.8-32-19.2-51.2-19.2-19.2 0-38.4 6.4-51.2 19.2-12.8 12.8-19.2 32-19.2 51.2 0 19.2 6.4 38.4 19.2 51.2 12.8 12.8 32 19.2 51.2 19.2 19.2 0 38.4-6.4 51.2-19.2 12.8-12.8 19.2-32 19.2-51.2z m185.6 256c0 102.4-25.6 192-83.2 275.2-6.4 12.8-19.2 19.2-32 19.2H108.8c-12.8 0-25.6-6.4-32-19.2C25.6 851.2 0 755.2 0 659.2c0-70.4 12.8-134.4 38.4-198.4s64-115.2 108.8-166.4 102.4-83.2 166.4-108.8 128-38.4 198.4-38.4 134.4 12.8 198.4 38.4 115.2 64 166.4 108.8c44.8 44.8 83.2 102.4 108.8 166.4 25.6 64 38.4 128 38.4 198.4z",
            Status = ToolStatus.Complete
        },
        new ToolMenuItem()
        {
            Group = ToolType.Developer,
            Level = 0,
            Header = ToolType.Developer.Description(),
            Description = "",
            Icon = IconHelper.Developer,
            Children = new ObservableCollection<ToolMenuItem>()
            {
                new ToolMenuItem()
                {
                    Group = ToolType.Developer,
                    Level = 1,
                    Header = ToolInfo.TimestampName,
                    Description = ToolInfo.TimestampTitle,
                    ViewName = nameof(Timestamp),
                    Icon = IconHelper.Timestamp,
                    Status = ToolStatus.Developing
                }
            }
        }
    };
}