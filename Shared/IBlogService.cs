using Shared.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Shared
{
    public interface IBlogService
    {
        List<Author> GetAllAuthors();
        Task<List<Author>> GetAllAuthorsAsync();
        Author GetAuthorById(int id);
        Task<Author> GetAuthorByIdAsync(int id);
        List<Post> GetPostsByAuthor(int id);
        Task<List<Post>> GetPostsByAuthorAsync(int id);
        List<SocialNetworkProfile> GetSocialNetworkProfilesByAuthor(int id);
        Task<List<SocialNetworkProfile>> GetSocialNetworkProfilesByAuthorAsync(int id);
        Task<Author> AddAuthorAsync(Author author);
    }
}
