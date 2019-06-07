using GraphQL.Types;
using GraphQLApi.Entities;

namespace GraphQLApi.Queries.Types
{
    public class CommentType : ObjectGraphType<Comment>
    {
        public CommentType()
        {
            Field(x => x.Count);
            Field(x => x.Description);
            Field(x => x.Url);
        }
    }
}
