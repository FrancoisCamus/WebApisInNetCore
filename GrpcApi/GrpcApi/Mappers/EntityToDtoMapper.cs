using Google.Protobuf.WellKnownTypes;
using System.Linq;

namespace GrpcApi.Mappers
{
    public class EntityToDtoMapper
    {
         public static Author MapAuthor(Shared.Entities.Author source)
        {
            var dest = new Author();
            dest.Id = source.Id;
            dest.Bio = source.Bio;
            dest.Name = source.Name;
            dest.Posts.AddRange(source.Posts?.Select(MapPost) ?? Enumerable.Empty<Post>());
            dest.SocialNetworks.AddRange(source.Socials?.Select(MapSocialNetwork) ?? Enumerable.Empty<SocialNetworkProfile>());
            return dest;
        }

        public static Post MapPost(Shared.Entities.Post source)
        {
            var dest = new Post();
            dest.Id = source.Id;
            dest.Title = source.Title;
            dest.Description = source.Description;
            dest.Date = Timestamp.FromDateTime(source.Date.ToUniversalTime());
            dest.Url = source.Url;
            dest.Rating = source.Rating;
            dest.Categories.AddRange(source.Categories ?? Enumerable.Empty<string>());
            dest.Comments.AddRange(source.Comments?.Select(MapComment) ?? Enumerable.Empty<Comment>());
            return dest;
        }

        public static Comment MapComment(Shared.Entities.Comment source)
        {
            var dest = new Comment();
            dest.Id = source.Id;
            dest.Commenter = source.Commenter;
            dest.Description = source.Description;
            return dest;
        }
        public static SocialNetworkProfile MapSocialNetwork(Shared.Entities.SocialNetworkProfile source)
        {
            var dest = new SocialNetworkProfile();
            dest.Id = source.Id;
            dest.NickName = source.NickName;
            dest.Url = source.Url;
            dest.Type = (SocialNetworkType)source.Type;
            return dest;
        }


    }
}
