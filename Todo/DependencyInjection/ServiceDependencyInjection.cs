using Microsoft.Extensions.DependencyInjection;
using Todo.Services;

namespace Todo.DependencyInjection
{
    public static class ServiceDependencyInjection
    {
        public static IServiceCollection AddCustomServices(this IServiceCollection services)
        {
            return services
                .AddScoped<IGravatarService, GravatarService>();
        }
    }
}
