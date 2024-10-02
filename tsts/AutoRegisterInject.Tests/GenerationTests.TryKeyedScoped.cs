namespace AutoRegisterInject.Tests;

public partial class GenerationTests
{
   #region methods

   [Fact]
   public async Task ShouldTryRegisterKeyedScoped()
   {
      const string input = """
                           [TryRegisterKeyedScoped(serviceKey: "BazKey")]
                           public class Foo { }
                           """;

      const string expected = """
                              // <auto-generated>
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
                                      serviceCollection.TryAddKeyedScoped<Foo>("BazKey");
                                      return serviceCollection;
                                  }
                              }
                              """;

      await RunGeneratorAsync(input, expected);
   }

   [Fact]
   public async Task ShouldTryRegisterKeyedScopedFromInterface()
   {
      const string input = """
                           [TryRegisterKeyedScoped(serviceKey: "BazKey")]
                           public class Foo : IFoo { }
                           public interface IFoo { }

                           """;

      const string expected = """
                              // <auto-generated>
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
                                      serviceCollection.TryAddKeyedScoped<IFoo, Foo>("BazKey");
                                      return serviceCollection;
                                  }
                              }
                              """;

      await RunGeneratorAsync(input, expected);
   }

   #endregion
}