using Microsoft.CodeAnalysis.Testing;
using System.Collections.Immutable;
using Xunit;

using GeneratorTest = Microsoft.CodeAnalysis.CSharp.Testing.CSharpSourceGeneratorTest<AutoRegisterInject.Tests.SourceGeneratorAdapter<AutoRegisterInject.Generator>, Microsoft.CodeAnalysis.Testing.Verifiers.XUnitVerifier>;

namespace AutoRegisterInject.Tests;

public partial class GenerationTests
{
    private static readonly ReferenceAssemblies Reference = ReferenceAssemblies
        .Net
        .Net60
        .AddPackages(ImmutableArray.Create(new PackageIdentity("Microsoft.Extensions.DependencyInjection", "8.0.0"),
            new PackageIdentity("Microsoft.Extensions.Hosting.Abstractions", "8.0.0")));

    internal const string ATTRIBUTE_SOURCE_OUTPUT = @"// <auto-generated>
//     Automatically generated by AutoRegisterInject.
//     Changes made to this file may be lost and may cause undesirable behaviour.
// </auto-generated>
[System.AttributeUsage(System.AttributeTargets.Class, Inherited = false, AllowMultiple = false)]
internal sealed class RegisterScopedAttribute : System.Attribute
{ 
    internal RegisterScopedAttribute(params System.Type[] onlyRegisterAs) { }
}

[System.AttributeUsage(System.AttributeTargets.Class, Inherited = false, AllowMultiple = false)]
internal sealed class RegisterKeyedScopedAttribute : System.Attribute
{ 
    internal RegisterKeyedScopedAttribute(string serviceKey, params System.Type[] onlyRegisterAs) { }
}

[System.AttributeUsage(System.AttributeTargets.Class, Inherited = false, AllowMultiple = false)]
internal sealed class TryRegisterScopedAttribute : System.Attribute
{ 
    internal TryRegisterScopedAttribute(params System.Type[] onlyRegisterAs) { }
}

[System.AttributeUsage(System.AttributeTargets.Class, Inherited = false, AllowMultiple = false)]
internal sealed class TryRegisterKeyedScopedAttribute : System.Attribute
{ 
    internal TryRegisterKeyedScopedAttribute(string serviceKey, params System.Type[] onlyRegisterAs) { }
}

[System.AttributeUsage(System.AttributeTargets.Class, Inherited = false, AllowMultiple = false)]
internal sealed class RegisterSingletonAttribute : System.Attribute
{ 
    internal RegisterSingletonAttribute(params System.Type[] onlyRegisterAs) { }
}

[System.AttributeUsage(System.AttributeTargets.Class, Inherited = false, AllowMultiple = false)]
internal sealed class RegisterKeyedSingletonAttribute : System.Attribute
{ 
    internal RegisterKeyedSingletonAttribute(string serviceKey, params System.Type[] onlyRegisterAs) { }
}

[System.AttributeUsage(System.AttributeTargets.Class, Inherited = false, AllowMultiple = false)]
internal sealed class TryRegisterSingletonAttribute : System.Attribute
{ 
    internal TryRegisterSingletonAttribute(params System.Type[] onlyRegisterAs) { }
}

[System.AttributeUsage(System.AttributeTargets.Class, Inherited = false, AllowMultiple = false)]
internal sealed class TryRegisterKeyedSingletonAttribute : System.Attribute
{ 
    internal TryRegisterKeyedSingletonAttribute(string serviceKey, params System.Type[] onlyRegisterAs) { }
}

[System.AttributeUsage(System.AttributeTargets.Class, Inherited = false, AllowMultiple = false)]
internal sealed class RegisterTransientAttribute : System.Attribute
{ 
    internal RegisterTransientAttribute(params System.Type[] onlyRegisterAs) { }
}

[System.AttributeUsage(System.AttributeTargets.Class, Inherited = false, AllowMultiple = false)]
internal sealed class RegisterKeyedTransientAttribute : System.Attribute
{ 
    internal RegisterKeyedTransientAttribute(string serviceKey, params System.Type[] onlyRegisterAs) { }
}

[System.AttributeUsage(System.AttributeTargets.Class, Inherited = false, AllowMultiple = false)]
internal sealed class TryRegisterTransientAttribute : System.Attribute
{ 
    internal TryRegisterTransientAttribute(params System.Type[] onlyRegisterAs) { }
}

[System.AttributeUsage(System.AttributeTargets.Class, Inherited = false, AllowMultiple = false)]
internal sealed class TryRegisterKeyedTransientAttribute : System.Attribute
{ 
    internal TryRegisterKeyedTransientAttribute(string serviceKey, params System.Type[] onlyRegisterAs) { }
}

[System.AttributeUsage(System.AttributeTargets.Class, Inherited = false, AllowMultiple = false)]
internal sealed class RegisterHostedServiceAttribute : System.Attribute { }";

    private static async Task RunGenerator(string sourceInput, string expectedSourceOutput)
    {
        await new GeneratorTest
        {
            ReferenceAssemblies = Reference,
            TestState =
            {
                Sources = { sourceInput },
                GeneratedSources =
                {
                    (typeof(SourceGeneratorAdapter<Generator>), "AutoRegisterInject.Attributes.g.cs", ATTRIBUTE_SOURCE_OUTPUT),
                    (typeof(SourceGeneratorAdapter<Generator>), "AutoRegisterInject.ServiceCollectionExtension.g.cs", expectedSourceOutput),
                },
            },
        }.RunAsync();
    }

    [Fact]
    public async Task ShouldGenerateAttributesAndServiceCollectionExtensions()
    {
        const string EXPECTED = @"// <auto-generated>
//     Automatically generated by AutoRegisterInject.
//     Changes made to this file may be lost and may cause undesirable behaviour.
// </auto-generated>
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
public static class AutoRegisterInjectServiceCollectionExtension
{
    public static Microsoft.Extensions.DependencyInjection.IServiceCollection AutoRegisterFromTestProject(this Microsoft.Extensions.DependencyInjection.IServiceCollection serviceCollection)
    {
        return AutoRegister(serviceCollection);
    }

    internal static Microsoft.Extensions.DependencyInjection.IServiceCollection AutoRegister(this Microsoft.Extensions.DependencyInjection.IServiceCollection serviceCollection)
    {
        
        return serviceCollection;
    }
}";

        await RunGenerator(string.Empty, EXPECTED);
    }
}