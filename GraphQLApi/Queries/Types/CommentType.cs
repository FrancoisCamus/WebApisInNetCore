using GraphQL.Types;
using Shared.Entities;

namespace GraphQLApi.Queries.Types
{
    public class CommentType : ObjectGraphType<Comment>
    {
        public CommentType()
        {
            Field(x => x.Id);
            Field(x => x.Commenter);
            Field(x => x.Description);
        }
    }
}
