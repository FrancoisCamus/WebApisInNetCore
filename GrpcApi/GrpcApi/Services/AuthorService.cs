using System.Threading;
using System.Threading.Tasks;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using GrpcApi.Mappers;
using Shared;

namespace GrpcApi.Services
{
    public class AuthorService : global::AuthorService.AuthorServiceBase
    {

        private readonly IBlogService blogService;

        public AuthorService(IBlogService blogService)
        {
            this.blogService = blogService;
        }


        public override async Task GetAll(Empty request, IServerStreamWriter<Author> responseStream, ServerCallContext context)
        {
            var authors = await this.blogService.GetAllAuthorsAsync();
            foreach (var author in authors)
            {
                await responseStream.WriteAsync(EntityToDtoMapper.MapAuthor(author));
                Thread.Sleep(5000);

            }
        }
  
        public override async Task<Author> GetAuthorById(Int32Value request, ServerCallContext context)
        {
            return EntityToDtoMapper.MapAuthor(await this.blogService.GetAuthorByIdAsync(request.Value));
        }

        public override async Task GetPostsByAuthor(Int32Value request, IServerStreamWriter<Post> responseStream, ServerCallContext context)
        {
            var posts = await this.blogService.GetPostsByAuthorAsync(request.Value);
            foreach (var post in posts)
                await responseStream.WriteAsync(EntityToDtoMapper.MapPost(post));
        }

        public override async Task GetSocialsByAuthor(Int32Value request, IServerStreamWriter<SocialNetworkProfile> responseStream, ServerCallContext context)
        {
            var socials = await this.blogService.GetSocialNetworkProfilesByAuthorAsync(request.Value);
            foreach (var social in socials)
                await responseStream.WriteAsync(EntityToDtoMapper.MapSocialNetwork(social));
        }

        public override async Task<Author> AddAuthor(Author request, ServerCallContext context)
        {
            var author = await this.blogService.AddAuthorAsync(DtoToEntityMapper.MapAuthor(request));
            return EntityToDtoMapper.MapAuthor(author);
         }
    }
}

