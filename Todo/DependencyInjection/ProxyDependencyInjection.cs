using Microsoft.Extensions.DependencyInjection;
using Todo.Proxies;

namespace Todo.DependencyInjection
{
    public static class ProxyDependencyInjection
    {
        public static IServiceCollection AddCustomProxies(this IServiceCollection services)
        {
            services.AddHttpClient<IGravatarProxy, GravatarProxy>();

            return services
                .AddScoped<IGravatarProxy, GravatarProxy>();
        }
    }
}
