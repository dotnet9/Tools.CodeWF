﻿using System.ComponentModel;

namespace CodeWF.ViewModels.Navbar.NavItems;

public enum ToolStatus
{
    [Description("计划中")] Planned,
    [Description("开发中")] Developing,
    [Description("开发完成")] Complete
}