using Microsoft.EntityFrameworkCore;
using Shared.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Shared
{
    public class BlogService
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

        public Author GetAuthorById(int id)
        {
            return _context.Authors
                .Include(p => p.Posts)
                .Include(p => p.Socials)
                .Where(author => author.Id == id)
                .FirstOrDefault();
        }

        public List<Post> GetPostsByAuthor(int id)
        {
            return _context.Posts
                .Include(p => p.Comments)
                .Where(post => post.Author.Id == id)
                .ToList();
        }

        public List<SocialNetworkProfile> GetSocialNetworkProfilesByAuthor(int id)
        {
            return _context.SocialNetworkProfiles
                .Where(sn => sn.Author.Id == id)
                .ToList();
        }
    }
}
