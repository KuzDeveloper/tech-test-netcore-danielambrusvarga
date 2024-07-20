using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Todo.Configurations;

namespace Todo.DependencyInjection
{
    public static class ConfigurationDependencyInjection
    {
        public static IServiceCollection AddCustomConfigurations(this IServiceCollection services, IConfiguration configuration)
        {
            var gravatarConfigurations = new GravatarConfigurations();
            configuration.GetSection("GravatarConfigurations").Bind(gravatarConfigurations);

            return services.AddSingleton<GravatarConfigurations>(gravatarConfigurations);
        }
    }
}
