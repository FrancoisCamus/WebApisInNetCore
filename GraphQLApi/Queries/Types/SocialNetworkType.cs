using GraphQL.Types;
using GraphQLApi.Entities;

namespace GraphQLApi.Queries.Types
{
    public class SocialNetworkType : ObjectGraphType<SocialNetwork>
    {
        public SocialNetworkType()
        {
            Field(x => x.NickName);
            Field<EnumerationGraphType<SNType>>("type");
            Field(x => x.Url);
            Field<AuthorType>("author");
        }
    }
}
