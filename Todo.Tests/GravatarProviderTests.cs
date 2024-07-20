using Microsoft.Extensions.Caching.Memory;
using Moq;
using Todo.Configurations;
using Todo.Models.Gravatar;
using Todo.Providers;
using Todo.Proxies;
using Xunit;

namespace Todo.Tests
{
    public class GravatarProviderTests
    {
        private const string EmailMD5Hash = "123";
        private const string AvatarUrl = "www.avatar.url";
        private const string DisplayName = "This is the display name";
        
        private readonly GravatarProfile _gravatarProfile = new GravatarProfile()
        {
            AvatarUrl = AvatarUrl,
            DisplayName = DisplayName
        };
        private readonly Mock<IGravatarProxy> _mockIGravatarProxy;
        private readonly IMemoryCache _memoryCache;
        private readonly GravatarConfigurations _gravatarConfigurations;
        private readonly IGravatarProvider _sut;

        public GravatarProviderTests()
        {
            _mockIGravatarProxy = new Mock<IGravatarProxy>();
            _mockIGravatarProxy
                .Setup(p => p.GetGravatarProfileAsync(EmailMD5Hash))
                .ReturnsAsync(_gravatarProfile);

            _gravatarConfigurations = new GravatarConfigurations() { CacheTtl = "01:00:00" };

            _memoryCache = new MemoryCache(new MemoryCacheOptions());

            _sut = new GravatarProvider(_mockIGravatarProxy.Object, _memoryCache, _gravatarConfigurations);
        }

        [Fact]
        public void GetGravatarProfileAsync_SubsequentCallsForSameEmail_CallsProxyOnce_AndUsesCacheTwice()
        {
            _sut.GetGravatarProfileAsync(EmailMD5Hash);
            _sut.GetGravatarProfileAsync(EmailMD5Hash);
            _sut.GetGravatarProfileAsync(EmailMD5Hash);

            _mockIGravatarProxy.Verify(p => p.GetGravatarProfileAsync(EmailMD5Hash), Times.Once());
        }
    }
}