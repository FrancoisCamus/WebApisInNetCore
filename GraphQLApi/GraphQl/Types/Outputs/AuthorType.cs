using GraphQL.Types;
using Shared;
using Shared.Entities;

namespace GraphQLApi.GraphQl.Types.Outputs
{
    public class AuthorType : ObjectGraphType<Author>
    {
        public AuthorType(IBlogService blogService)
        {
            Field(x => x.Id).Description("Id of an author");
            Field(x => x.Name).Description("Name of an author");
            Field(x => x.Bio).Description("Bio description of an author");

            Field<ListGraphType<PostType>>(
                name: "posts",
                arguments: new QueryArguments(new QueryArgument<IntGraphType> { Name = "id" }),
                resolve: context =>
                {
                    return blogService.GetPostsByAuthor(context.Source.Id);
                }
            );

            Field<ListGraphType<SocialNetworkProfileType>>(
                name: "socials",
                arguments: new QueryArguments(new QueryArgument<IntGraphType> { Name = "id" }),
                resolve: context =>
                {
                    return blogService.GetSocialNetworkProfilesByAuthor(context.Source.Id);
                }
            );
        }
    }
}
