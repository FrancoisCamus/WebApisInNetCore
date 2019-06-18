using Shared.Entities;
using System.Collections.Generic;

namespace Shared
{
    public interface IDataInitializer
    {
        List<Author> Authors { get; }
        List<Post> Posts { get; }
        List<SocialNetworkProfile> SocialNetworkProfiles { get; }
    }
}
