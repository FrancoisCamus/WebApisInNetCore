using GraphQL.Types;
using Shared.Entities;

namespace GraphQLApi.Queries.Types
{
    public class AuthorType : ObjectGraphType<Author>
    {
        public AuthorType()
        {
            Field(x => x.Id).Description("Id of an author");
            Field(x => x.Name).Description("Name of an author");
            Field(x => x.Bio).Description("Bio description of an author");
        }
    }
}
