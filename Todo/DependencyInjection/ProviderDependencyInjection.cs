using Microsoft.Extensions.DependencyInjection;
using Todo.Providers;

namespace Todo.DependencyInjection
{
    public static class ProviderDependencyInjection
    {
        public static IServiceCollection AddCustomProviders(this IServiceCollection services)
        {
            return services
                .AddScoped<IGravatarProvider, GravatarProvider>();
        }
    }
}
