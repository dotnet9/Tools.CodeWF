﻿using CodeWF.Generators.Abstractions;

namespace CodeWF.Generators.Generators;

internal class AutoNotifyAttributeGenerator : StaticFileGenerator
{
    private const string AttributeText =
        """
        // <auto-generated />
        #nullable enable
        using System;

        namespace CodeWF;

        [AttributeUsage(AttributeTargets.Field, Inherited = false, AllowMultiple = false)]
        sealed class AutoNotifyAttribute : Attribute
        {
        	public AutoNotifyAttribute()
        	{
        	}
        
        	public string? PropertyName { get; set; }
        
        	public AccessModifier SetterModifier { get; set; } = AccessModifier.Public;
        }
        """;

    private const string ModifierText =
        """
        // <auto-generated />
        namespace CodeWF;

        public enum AccessModifier
        {
        	None = 0,
        	Public = 1,
        	Protected = 2,
        	Private = 3,
        	Internal = 4
        }
        """;

    public override IEnumerable<(string FileName, string Source)> Generate()
    {
        yield return ("AccessModifier.g.cs", ModifierText);
        yield return ("AutoNotifyAttribute.g.cs", AttributeText);
    }
}
