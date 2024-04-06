﻿using CodeWF.Generators.Abstractions;

namespace CodeWF.Generators.Generators;

internal class AutoInterfaceAttributeGenerator : StaticFileGenerator
{
    private const string AttributeText =
        """
        // <auto-generated />
        #nullable enable
        using System;

        namespace CodeWF;

        [AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = false)]
        sealed class AutoInterfaceAttribute : Attribute
        {
        	public AutoInterfaceAttribute()
        	{
        	}
        }
        """;

    public override IEnumerable<(string FileName, string Source)> Generate()
    {
        yield return ("AutoInterface.g.cs", AttributeText);
    }
}