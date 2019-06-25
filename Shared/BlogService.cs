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

        public List<Author> GetAllAuthors()
        {
            return _context.Authors.ToList();
        }

        public async Task<List<Author>> GetAllAuthorsAsync()
        {
            return await _context.Authors
                .Include(a => a.Posts)
                .Include(a => a.Socials)
                .ToListAsync();
        }

        public Author GetAuthorById(int id)
        {
            return _context.Authors
                .Include(p => p.Posts)
                .Include(p => p.Socials)
                .Where(author => author.Id == id)
                .FirstOrDefault();
        }

        public async Task<Author> GetAuthorByIdAsync(int id)
        {
            return await _context.Authors
                .Include(p => p.Posts)
                .Include(p => p.Socials)
                .Where(author => author.Id == id)
                .FirstOrDefaultAsync();
        }

        public List<Post> GetPostsByAuthor(int id)
        {
            return _context.Posts
                .Include(p => p.Comments)
                .Where(post => post.Author.Id == id)
                .ToList();
        }

        public async Task<List<Post>> GetPostsByAuthorAsync(int id)
        {
            return await _context.Posts
                .Include(p => p.Comments)
                .Where(post => post.Author.Id == id)
                .ToListAsync();
        }

        public List<SocialNetworkProfile> GetSocialNetworkProfilesByAuthor(int id)
        {
            return _context.SocialNetworkProfiles
                .Where(sn => sn.Author.Id == id)
                .ToList();
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

        public Author AddAuthor(Author author)
        {
            _context.Authors.Add(author);
            _context.SaveChanges();

            return author;
        }
    }
}
