using GraphQL.Types;
using Shared.Entities;

namespace GraphQLApi.GraphQl.Types.Outputs
{
    public class PostType : ObjectGraphType<Post>
    {
        public PostType()
        {
            Field(x => x.Id);
            Field(x => x.Title);
            Field(x => x.Description);
            Field(x => x.Date);
            Field(x => x.Url);
            Field<AuthorType>("author");
            Field(x => x.Categories, nullable: true);
            Field(x => x.Rating);
            Field<ListGraphType<CommentType>>("comments");
        }
    }
}
