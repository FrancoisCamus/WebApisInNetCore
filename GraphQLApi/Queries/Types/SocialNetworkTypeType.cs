using GraphQL.Types;
using Shared.Entities;

namespace GraphQLApi.Queries.Types
{
    public class SocialNetworkTypeType : EnumerationGraphType<SocialNetworkType>
    {
        public SocialNetworkTypeType()
        {
            Name = "SocialNetworkTypeType";
        }
    }
}
