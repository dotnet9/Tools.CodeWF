﻿using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Text;
using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodeWF.Generators;

[Generator]
public class StaticViewLocatorGenerator : ISourceGenerator
{
    private const string StaticViewLocatorAttributeDisplayString = "CodeWF.StaticViewLocatorAttribute";

    private const string ViewModelSuffix = "ViewModel";

    private const string ViewSuffix = "View";

    private const string AttributeText =
        """
		// <auto-generated />
		using System;

		namespace CodeWF;

		[AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = false)]
		public sealed class StaticViewLocatorAttribute : Attribute
		{
		}
		""";

    public void Initialize(GeneratorInitializationContext context)
    {
        // System.Diagnostics.Debugger.Launch();
        context.RegisterForPostInitialization((i) => i.AddSource("StaticViewLocatorAttribute.cs", SourceText.From(AttributeText, Encoding.UTF8)));

        context.RegisterForSyntaxNotifications(() => new SyntaxReceiver());
    }

    public void Execute(GeneratorExecutionContext context)
    {
        if (context.SyntaxContextReceiver is not SyntaxReceiver receiver)
        {
            return;
        }

        var attributeSymbol = context.Compilation.GetTypeByMetadataName(StaticViewLocatorAttributeDisplayString);
        if (attributeSymbol is null)
        {
            return;
        }

        foreach (var namedTypeSymbol in receiver.NamedTypeSymbolLocators)
        {
            var namedTypeSymbolViewModels = receiver.NamedTypeSymbolViewModels.ToList();
            namedTypeSymbolViewModels.Sort((x, y) => x.ToDisplayString().CompareTo(y.ToDisplayString()));

            var classSource = ProcessClass(context.Compilation, namedTypeSymbol, namedTypeSymbolViewModels);
            if (classSource is not null)
            {
                context.AddSource($"{namedTypeSymbol.Name}_StaticViewLocator.cs", SourceText.From(classSource, Encoding.UTF8));
            }
        }
    }

    private static string? ProcessClass(Compilation compilation, ISymbol namedTypeSymbolLocator, List<ISymbol> namedTypeSymbolViewModels)
    {
        if (!namedTypeSymbolLocator.ContainingSymbol.Equals(namedTypeSymbolLocator.ContainingNamespace, SymbolEqualityComparer.Default))
        {
            return null;
        }

        string namespaceNameLocator = namedTypeSymbolLocator.ContainingNamespace.ToDisplayString();

        var format = new SymbolDisplayFormat(
            typeQualificationStyle: SymbolDisplayTypeQualificationStyle.NameAndContainingTypes,
            genericsOptions: SymbolDisplayGenericsOptions.IncludeTypeParameters | SymbolDisplayGenericsOptions.IncludeTypeConstraints | SymbolDisplayGenericsOptions.IncludeVariance);

        string classNameLocator = namedTypeSymbolLocator.ToDisplayString(format);

        var source = new StringBuilder(
            $$"""
			// <auto-generated />
			#nullable enable
			using System;
			using System.Collections.Generic;
			using Avalonia.Controls;

			namespace {{namespaceNameLocator}};

			public partial class {{classNameLocator}}
			{
			""");

        source.Append(
            """

				private static Dictionary<Type, Func<Control>> s_views = new()
				{

			""");

        var userControlViewSymbol = compilation.GetTypeByMetadataName("Avalonia.Controls.UserControl");

        foreach (var namedTypeSymbolViewModel in namedTypeSymbolViewModels)
        {
            string namespaceNameViewModel = namedTypeSymbolViewModel.ContainingNamespace.ToDisplayString();
            string classNameViewModel = $"{namespaceNameViewModel}.{namedTypeSymbolViewModel.ToDisplayString(format)}";
            string classNameView = classNameViewModel.Replace(ViewModelSuffix, ViewSuffix);

            var classNameViewSymbol = compilation.GetTypeByMetadataName(classNameView);
            if (classNameViewSymbol is null || classNameViewSymbol.BaseType?.Equals(userControlViewSymbol, SymbolEqualityComparer.Default) != true)
            {
                source.AppendLine(
                    $$"""
							[typeof({{classNameViewModel}})] = () => new TextBlock() { Text = {{("\"Not Found: " + classNameView + "\"")}} },
					""");
            }
            else
            {
                source.AppendLine(
                    $$"""
							[typeof({{classNameViewModel}})] = () => new {{classNameView}}(),
					""");
            }
        }

        source.Append(
            """
				};
			}
			""");

        return source.ToString();
    }

    private class SyntaxReceiver : ISyntaxContextReceiver
    {
        public List<ISymbol> NamedTypeSymbolLocators { get; } = new();

        public List<ISymbol> NamedTypeSymbolViewModels { get; } = new();

        public void OnVisitSyntaxNode(GeneratorSyntaxContext context)
        {
            if (context.Node is ClassDeclarationSyntax classDeclarationSyntax)
            {
                var namedTypeSymbol = context.SemanticModel.GetDeclaredSymbol(classDeclarationSyntax);
                if (namedTypeSymbol is null)
                {
                    return;
                }

                var attributes = namedTypeSymbol.GetAttributes();
                if (attributes.Any(ad => ad?.AttributeClass?.ToDisplayString() == StaticViewLocatorAttributeDisplayString))
                {
                    NamedTypeSymbolLocators.Add(namedTypeSymbol);
                }
                else if (namedTypeSymbol.Name.EndsWith(ViewModelSuffix))
                {
                    if (!namedTypeSymbol.IsAbstract)
                    {
                        NamedTypeSymbolViewModels.Add(namedTypeSymbol);
                    }
                }
            }
        }
    }
}
