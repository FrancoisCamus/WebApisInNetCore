using GraphQL.Types;
using Shared.Entities;

namespace GraphQLApi.GraphQl.Types.Outputs
{
    public class SocialNetworkTypeType : EnumerationGraphType<SocialNetworkType>
    {
        public SocialNetworkTypeType()
        {
            Name = "SocialNetworkTypeType";
        }
    }
}
