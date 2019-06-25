using GraphQL;
using GraphQL.Types;

namespace GraphQLApi.GraphQl
{
    public class BlogServiceSchema : Schema
    {
        public BlogServiceSchema(IDependencyResolver resolver) : base(resolver)
        {
            Query = resolver.Resolve<BlogServiceQuery>();
            Mutation = resolver.Resolve<BlogServiceMutation>();
        }
    }
}
