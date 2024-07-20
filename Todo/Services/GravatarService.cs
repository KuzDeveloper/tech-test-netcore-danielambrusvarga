using System;
using System.Threading.Tasks;
using Todo.Exceptions;
using Todo.Helpers;
using Todo.Models.Gravatar;
using Todo.Providers;

namespace Todo.Services
{
    public class GravatarService : IGravatarService
    {
        private readonly IGravatarProvider _gravatarProvider;

        public GravatarService(IGravatarProvider gravatarProvider)
        {
            _gravatarProvider = gravatarProvider;
        }

        public async Task<GravatarProfile> GetGravatarProfileAsync(string emailAddress)
        {
            string emailAddressMD5Hash = MD5HashHelper.GetHash(emailAddress);

            try
            {
                GravatarProfile gravatarProfile = await _gravatarProvider.GetGravatarProfileAsync(emailAddressMD5Hash);

                if (gravatarProfile == null || string.IsNullOrWhiteSpace(gravatarProfile.DisplayName))
                {
                    gravatarProfile = CreateEmptyGravatarProfile(emailAddress);
                }

                return gravatarProfile;
            }
            catch (Exception ex)
            {
                if (ex is GravatarClientException)
                {
                    return CreateEmptyGravatarProfile(emailAddress);
                }

                throw;
            }
        }

        private static GravatarProfile CreateEmptyGravatarProfile(string emailAddress)
        {
            return new GravatarProfile()
            {
                AvatarUrl = null,
                DisplayName = emailAddress
            };
        }
    }
}
