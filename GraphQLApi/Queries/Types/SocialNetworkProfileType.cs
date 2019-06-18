using GraphQL.Types;
using Shared.Entities;

namespace GraphQLApi.Queries.Types
{
    public class SocialNetworkProfileType : ObjectGraphType<SocialNetworkProfile>
    {
        public SocialNetworkProfileType()
        {
            Field(x => x.Id);
            Field<EnumerationGraphType<SocialNetworkType>>("type");
            Field(x => x.NickName);
            Field(x => x.Url);
            Field<AuthorType>("author");
        }
    }
}
