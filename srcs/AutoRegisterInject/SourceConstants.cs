﻿namespace AutoRegisterInject;

sealed class SourceConstants
{
   #region fields

   internal const string GenerateClassSource = """
                                               // <auto-generated>
                                               //     Automatically generated by AutoRegisterInject.
                                               //     Changes made to this file may be lost and may cause undesirable behaviour.
                                               // </auto-generated>
                                               using Microsoft.Extensions.DependencyInjection;
                                               using Microsoft.Extensions.DependencyInjection.Extensions;
                                               public static class AutoRegisterInjectServiceCollectionExtension
                                               {
                                                   public static Microsoft.Extensions.DependencyInjection.IServiceCollection AutoRegisterFrom{0}(this Microsoft.Extensions.DependencyInjection.IServiceCollection serviceCollection)
                                                   {
                                                       return AutoRegister(serviceCollection);
                                                   }
                                               
                                                   internal static Microsoft.Extensions.DependencyInjection.IServiceCollection AutoRegister(this Microsoft.Extensions.DependencyInjection.IServiceCollection serviceCollection)
                                                   {
                                                       {1}
                                                       return serviceCollection;
                                                   }
                                               }
                                               """;

   internal static readonly string GenerateHostedServiceSource              = "serviceCollection.AddHostedService<{0}>();";
   internal static readonly string GenerateKeyedScopedInterfaceSource       = """serviceCollection.AddKeyedScoped<{0}, {1}>("{2}");""";
   internal static readonly string GenerateKeyedScopedSource                = """serviceCollection.AddKeyedScoped<{0}>("{1}");""";
   internal static readonly string GenerateKeyedSingletonInterfaceSource    = """serviceCollection.AddKeyedSingleton<{0}, {1}>("{2}");""";
   internal static readonly string GenerateKeyedSingletonSource             = """serviceCollection.AddKeyedSingleton<{0}>("{1}");""";
   internal static readonly string GenerateKeyedTransientInterfaceSource    = """serviceCollection.AddKeyedTransient<{0}, {1}>("{2}");""";
   internal static readonly string GenerateKeyedTransientSource             = """serviceCollection.AddKeyedTransient<{0}>("{1}");""";
   internal static readonly string GenerateScopedInterfaceSource            = "serviceCollection.AddScoped<{0}, {1}>();";
   internal static readonly string GenerateScopedSource                     = "serviceCollection.AddScoped<{0}>();";
   internal static readonly string GenerateSingletonInterfaceSource         = "serviceCollection.AddSingleton<{0}, {1}>();";
   internal static readonly string GenerateSingletonSource                  = "serviceCollection.AddSingleton<{0}>();";
   internal static readonly string GenerateTransientInterfaceSource         = "serviceCollection.AddTransient<{0}, {1}>();";
   internal static readonly string GenerateTransientSource                  = "serviceCollection.AddTransient<{0}>();";
   internal static readonly string GenerateTryKeyedScopedInterfaceSource    = """serviceCollection.TryAddKeyedScoped<{0}, {1}>("{2}");""";
   internal static readonly string GenerateTryKeyedScopedSource             = """serviceCollection.TryAddKeyedScoped<{0}>("{1}");""";
   internal static readonly string GenerateTryKeyedSingletonInterfaceSource = """serviceCollection.TryAddKeyedSingleton<{0}, {1}>("{2}");""";
   internal static readonly string GenerateTryKeyedSingletonSource          = """serviceCollection.TryAddKeyedSingleton<{0}>("{1}");""";
   internal static readonly string GenerateTryKeyedTransientInterfaceSource = """serviceCollection.TryAddKeyedTransient<{0}, {1}>("{2}");""";
   internal static readonly string GenerateTryKeyedTransientSource          = """serviceCollection.TryAddKeyedTransient<{0}>("{1}");""";
   internal static readonly string GenerateTryScopedInterfaceSource         = "serviceCollection.TryAddScoped<{0}, {1}>();";
   internal static readonly string GenerateTryScopedSource                  = "serviceCollection.TryAddScoped<{0}>();";
   internal static readonly string GenerateTrySingletonInterfaceSource      = "serviceCollection.TryAddSingleton<{0}, {1}>();";
   internal static readonly string GenerateTrySingletonSource               = "serviceCollection.TryAddSingleton<{0}>();";
   internal static readonly string GenerateTryTransientInterfaceSource      = "serviceCollection.TryAddTransient<{0}, {1}>();";
   internal static readonly string GenerateTryTransientSource               = "serviceCollection.TryAddTransient<{0}>();";

   #endregion
}