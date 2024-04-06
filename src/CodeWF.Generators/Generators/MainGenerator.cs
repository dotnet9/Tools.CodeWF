using CodeWF.Generators.Abstractions;
using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodeWF.Generators.Generators;

[Generator]
internal class MainGenerator : CombinedGenerator
{
    public MainGenerator()
    {
        AddStaticFileGenerator<AutoInterfaceAttributeGenerator>();
        AddStaticFileGenerator<AutoNotifyAttributeGenerator>();
        Add<AutoNotifyGenerator>();
        Add<AutoInterfaceGenerator>();
        Add<UiContextConstructorGenerator>();
        Add<FluentNavigationGenerator>();
    }
}