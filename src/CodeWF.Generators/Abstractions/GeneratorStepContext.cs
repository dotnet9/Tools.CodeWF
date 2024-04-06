using Microsoft.CodeAnalysis;

namespace CodeWF.Generators.Abstractions;

internal record GeneratorStepContext(GeneratorExecutionContext Context, Compilation Compilation);