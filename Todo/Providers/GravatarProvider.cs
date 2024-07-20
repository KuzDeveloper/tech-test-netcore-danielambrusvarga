using Microsoft.Extensions.Caching.Memory;
using System;
using System.Threading.Tasks;
using Todo.Configurations;
using Todo.Constants;
using Todo.Models.Gravatar;
using Todo.Proxies;

namespace Todo.Providers
{
    public class GravatarProvider : IGravatarProvider
    {
        private readonly IGravatarProxy _gravatarProxy;
        private readonly IMemoryCache _memoryCache;
        private readonly GravatarConfigurations _gravatarConfigurations;

        public GravatarProvider(IGravatarProxy gravatarProxy,
            IMemoryCache memoryCache,
            GravatarConfigurations gravatarConfigurations)
        {
            _gravatarProxy = gravatarProxy;
            _memoryCache = memoryCache;
            _gravatarConfigurations = gravatarConfigurations;
        }

        public async Task<GravatarProfile> GetGravatarProfileAsync(string emailAddressMD5Hash)
        {
            return await _memoryCache.GetOrCreateAsync(
                CacheKeys.GravatarGetProfileCacheKey,
                async cacheEntry =>
                {
                    cacheEntry.SlidingExpiration = TimeSpan.Parse(_gravatarConfigurations.CacheTtl);

                    var gravatarProfile = new GravatarProfile();

                    try
                    {
                        gravatarProfile = await _gravatarProxy.GetGravatarProfileAsync(emailAddressMD5Hash);
                    }
                    catch 
                    {
                    }

                    return gravatarProfile;
                });
        }
    }
}
