using Scrutor;
using Store.Data;

namespace EntityFramework;
public static class ServiceConfiguration
{
    public static IServiceCollection ConfigureServices(this IServiceCollection services, IConfiguration configuration)
    {
        _ = configuration ?? throw new ArgumentNullException(nameof(configuration));

        services.Scan(scan => scan.FromCallingAssembly().ScanAssembly());

        DataDependencies.Register(services, configuration);
        return services;
    }

    private static void ScanAssembly(this IImplementationTypeSelector selector)
    {
        selector
            .AddClasses()
            .UsingRegistrationStrategy(RegistrationStrategy.Skip)
            .AsImplementedInterfaces()
            .WithTransientLifetime();
    }
}
