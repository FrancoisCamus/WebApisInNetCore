using Microsoft.AspNet.OData.Builder;
using Microsoft.AspNetCore.Mvc;
using Shared.Entities;

namespace ODataApi.Configurations
{
    public class AuthorsModelConfiguration : IModelConfiguration
    {
        public void Apply(ODataModelBuilder builder, ApiVersion apiVersion)
        {
            builder.EntitySet<Author>("Authors");
            builder.EntitySet<Post>("Posts");
            builder.EntitySet<SocialNetworkProfile>("SocialNetworkProfiles");
        }
    }
}
