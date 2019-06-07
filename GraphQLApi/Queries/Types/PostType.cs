using GraphQL.Types;
using GraphQLApi.Entities;

namespace GraphQLApi.Queries.Types
{
    public class PostType : ObjectGraphType<Post>
    {
        public PostType()
        {
            Field(x => x.Id);
            Field(x => x.Title);
            Field(x => x.Url);
            Field(x => x.Date);
            Field(x => x.Description);
            Field<AuthorType>("author");
            Field<RatingType>("rating");
            Field<ListGraphType<CommentType>>("comments");
            Field(x => x.Categories, nullable: true);
        }
    }
}
