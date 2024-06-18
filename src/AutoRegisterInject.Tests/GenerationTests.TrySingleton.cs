using Xunit;

namespace AutoRegisterInject.Tests;

public partial class GenerationTests
{
    [Fact]
    public async Task ShouldRegisterTrySingleton()
    {
        const string INPUT = @"[TryRegisterSingleton]
public class Foo { }";

        const string EXPECTED = @"// <auto-generated>
//     Automatically generated by AutoRegisterInject.
//     Changes made to this file may be lost and may cause undesirable behaviour.
// </auto-generated>
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

/// <summary>
/// AutoRegisterInject service collection extensions  
/// </summary>
public static class AutoRegisterInjectServiceCollectionExtension
{
    /// <summary>
    /// Adds all types registered with AutoRegisterInject attributes to the given
    /// service collection from the named assembly
    /// </summary>
    /// <param name=""serviceCollection"">Service collection to register types with</param>
    /// <returns>Service collection with registered types</returns>
    public static Microsoft.Extensions.DependencyInjection.IServiceCollection AutoRegisterFromTestProject(this Microsoft.Extensions.DependencyInjection.IServiceCollection serviceCollection)
    {
        return AutoRegister(serviceCollection);
    }

    /// <summary>
    /// Adds all types registered with AutoRegisterInject attributes to the given
    /// service collection
    /// </summary>
    /// <param name=""serviceCollection"">Service collection to register types with</param>
    /// <returns>Service collection with registered types</returns>
    internal static Microsoft.Extensions.DependencyInjection.IServiceCollection AutoRegister(this Microsoft.Extensions.DependencyInjection.IServiceCollection serviceCollection)
    {
        serviceCollection.TryAddSingleton<Foo>();
        return serviceCollection;
    }
}";

        await RunGenerator(INPUT, EXPECTED);
    }

    [Fact]
    public async Task ShouldRegisterTrySingletonFromInterface()
    {
        const string INPUT = @"[TryRegisterSingleton]
public class Foo : IFoo { }
public interface IFoo { }
";

        const string EXPECTED = @"// <auto-generated>
//     Automatically generated by AutoRegisterInject.
//     Changes made to this file may be lost and may cause undesirable behaviour.
// </auto-generated>
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

/// <summary>
/// AutoRegisterInject service collection extensions  
/// </summary>
public static class AutoRegisterInjectServiceCollectionExtension
{
    /// <summary>
    /// Adds all types registered with AutoRegisterInject attributes to the given
    /// service collection from the named assembly
    /// </summary>
    /// <param name=""serviceCollection"">Service collection to register types with</param>
    /// <returns>Service collection with registered types</returns>
    public static Microsoft.Extensions.DependencyInjection.IServiceCollection AutoRegisterFromTestProject(this Microsoft.Extensions.DependencyInjection.IServiceCollection serviceCollection)
    {
        return AutoRegister(serviceCollection);
    }

    /// <summary>
    /// Adds all types registered with AutoRegisterInject attributes to the given
    /// service collection
    /// </summary>
    /// <param name=""serviceCollection"">Service collection to register types with</param>
    /// <returns>Service collection with registered types</returns>
    internal static Microsoft.Extensions.DependencyInjection.IServiceCollection AutoRegister(this Microsoft.Extensions.DependencyInjection.IServiceCollection serviceCollection)
    {
        serviceCollection.TryAddSingleton<IFoo, Foo>();
        return serviceCollection;
    }
}";

        await RunGenerator(INPUT, EXPECTED);
    }
}