using OrderService.Modules.Common.Ports;

namespace OrderService.Modules.Common;

public static class ModuleExtensions
{
    private static readonly List<IModule> registeredModules = new();

    public static IServiceCollection RegisterModules(this IServiceCollection services,
        IConfiguration configuration,
        bool isProduction)
    {
        var modules = DiscoverModules();
        foreach (var module in modules)
        {
            module.RegisterModule(services, configuration, isProduction);
            registeredModules.Add(module);
        }

        return services;
    }

    public static WebApplication MapEndpoints(this WebApplication app)
    {
        foreach (var module in registeredModules)
        {
            module.MapEndpoints(app);
        }

        return app;
    }

    private static IEnumerable<IModule> DiscoverModules()
    {
        return typeof(IModule).Assembly
            .GetTypes()
            .Where(x => x.IsClass && x.IsAssignableTo(typeof(IModule)))
            .Select(Activator.CreateInstance)
            .Cast<IModule>();
    }
}