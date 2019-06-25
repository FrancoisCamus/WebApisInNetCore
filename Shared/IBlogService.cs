using Shared.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Shared
{
    public interface IBlogService
    {
        Task<List<Author>> GetAllAuthorsAsync();
        Task<Author> GetAuthorByIdAsync(int id);
        Task<List<Post>> GetPostsByAuthorAsync(int id);
        Task<List<SocialNetworkProfile>> GetSocialNetworkProfilesByAuthorAsync(int id);
        Task<Author> AddAuthorAsync(Author author);
    }
}
