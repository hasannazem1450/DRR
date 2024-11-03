using System;
using System.Linq;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace DRR.Framework.Contracts.Extensions;

public static class ConfigureReflectionExtension
{
    private static bool IsSameInterface(this Type type, Type handlerInterface)
    {
        var list = type.GetInterfaces();

        var result = list.Any(i => i.Name == handlerInterface.Name);

        return result;
    }

    private static Type GetSameInterface(Type[] types, Type handlerInterface)
    {
        var result = types.First();

        return result;
    }

    public static void AddInterfacesWithAssemblyReference(Assembly assembly, IServiceCollection serviceCollection, Type handlerInterface)
    {
        var implementations = assembly.GetTypes().Where(t => t.IsSameInterface(handlerInterface) && !t.IsInterface);

        foreach (var implementation in implementations)
        {
            var serviceType = GetSameInterface(implementation.GetInterfaces(), handlerInterface);

            serviceCollection.AddScoped(serviceType, implementation);
        }
    }

    public static void AddSingletonInterfacesWithAssemblyReference(Assembly assembly, IServiceCollection serviceCollection, Type handlerInterface)
    {
        var implementations = assembly.GetTypes().Where(t => t.IsSameInterface(handlerInterface) && !t.IsInterface);

        foreach (var implementation in implementations)
        {
            var serviceType = GetSameInterface(implementation.GetInterfaces(), handlerInterface);

            serviceCollection.AddSingleton(serviceType, implementation);
        }
    }

}