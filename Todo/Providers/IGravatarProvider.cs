using System.Threading.Tasks;
using Todo.Models.Gravatar;

namespace Todo.Providers
{
    public interface IGravatarProvider
    {
        Task<GravatarProfile> GetGravatarProfileAsync(string emailAddressMD5Hash);
    }
}
