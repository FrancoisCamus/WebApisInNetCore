using Microsoft.EntityFrameworkCore;
using Shared.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shared
{
    public class BlogService : IBlogService
    {
        private readonly SharedDbContext _context;

        public BlogService(SharedDbContext context)
        {
            _context = context;
            _context.Populate();
        }

        public async Task<List<Author>> GetAllAuthorsAsync()
        {
            return await _context.Authors
                .Include(a => a.Posts)
                .Include(a => a.Socials)
                .ToListAsync();
        }

        public async Task<Author> GetAuthorByIdAsync(int id)
        {
            return await _context.Authors
                .Include(p => p.Posts)
                .Include(p => p.Socials)
                .Where(author => author.Id == id)
                .FirstOrDefaultAsync();
        }

        public async Task<List<Post>> GetPostsByAuthorAsync(int id)
        {
            return await _context.Posts
                .Include(p => p.Comments)
                .Where(post => post.Author.Id == id)
                .ToListAsync();
        }

        public async Task<List<SocialNetworkProfile>> GetSocialNetworkProfilesByAuthorAsync(int id)
        {
            return await _context.SocialNetworkProfiles
                .Where(sn => sn.Author.Id == id)
                .ToListAsync();
        }

        public async Task<Author> AddAuthorAsync(Author author)
        {
            await _context.Authors.AddAsync(author);
            await _context.SaveChangesAsync();

            return author;
        }
    }
}
