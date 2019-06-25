using GraphQL.Types;
using Shared.Entities;

namespace GraphQLApi.GraphQl.Types.Outputs
{
    public class SocialNetworkProfileType : ObjectGraphType<SocialNetworkProfile>
    {
        public SocialNetworkProfileType()
        {
            Field(x => x.Id);
            Field<SocialNetworkTypeType>("type");
            Field(x => x.NickName);
            Field(x => x.Url);
            Field<AuthorType>("author");
        }
    }
}
