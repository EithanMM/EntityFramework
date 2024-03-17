using Store.Data;

namespace EntityFramework;

public static class ServiceDependencies
{
    public static void Register(IServiceCollection services, IConfiguration configuration)
    {
        ArgumentNullException.ThrowIfNull(configuration);
        services.Configure<RouteOptions>(options =>
        {
            options.LowercaseUrls = true;
        });

        services.AddControllers();
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();

        services.AddAutoMapper(config =>
        {
            config.AddProfile(new DataMapperProfile());
        });
    }
}
