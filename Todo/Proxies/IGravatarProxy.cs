using System.Threading.Tasks;
using Todo.Models.Gravatar;

namespace Todo.Proxies
{
    public interface IGravatarProxy
    {
        Task<GravatarProfile> GetGravatarProfileAsync(string emailAddressMD5Hash);
    }
}
