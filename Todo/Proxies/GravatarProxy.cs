using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using Todo.Configurations;
using Todo.Exceptions;
using Todo.Helpers;
using Todo.Models.Gravatar;

namespace Todo.Proxies
{
    public class GravatarProxy : IGravatarProxy
    {
        private readonly HttpClient _gravatarClient;
        private readonly GravatarConfigurations _gravatarConfiguration;

        public GravatarProxy(HttpClient gravatarClient, GravatarConfigurations gravatarConfiguration)
        {
            _gravatarClient = gravatarClient;
            _gravatarConfiguration = gravatarConfiguration;
        }

        public async Task<GravatarProfile> GetGravatarProfileAsync(string emailAddressMD5Hash)
        {
            string profile;
            HttpResponseMessage httpResponseMessage;

            try
            {
                httpResponseMessage = await _gravatarClient.GetAsync(
                    _gravatarConfiguration.BaseApiUrl + string.Format(_gravatarConfiguration.ProfileRouting, emailAddressMD5Hash));

                if (httpResponseMessage == null ||
                    !httpResponseMessage.IsSuccessStatusCode)
                {
                    throw new GravatarClientException($"Gravatar client call was not successful! {httpResponseMessage?.ReasonPhrase}");
                }
            }
            catch (Exception ex)
            {
                throw new GravatarClientException("Exception happened when calling the Gravatar client!", ex);
            }

            try
            {
                profile = await httpResponseMessage.Content?.ReadAsStringAsync();

                return JsonConvert.DeserializeObject<GravatarProfile>(profile);
            }
            catch (Exception ex)
            {
                throw new GravatarClientException("Exception happened when deserializing the Gravatar profile object!", ex);
            }
        }
    }
}
