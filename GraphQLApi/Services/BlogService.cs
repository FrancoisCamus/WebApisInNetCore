using Shared;
using Shared.Entities;
using System.Collections.Generic;
using System.Linq;

namespace GraphQLApi.Services
{
    public class BlogService
    {
        private readonly IDataInitializer _dataInitializer;

        public BlogService(IDataInitializer dataInitializer)
        {
            _dataInitializer = dataInitializer;
        }
        public List<Author> GetAllAuthors()
        {
            return _dataInitializer.Authors;
        }
        public Author GetAuthorById(int id)
        {
            return _dataInitializer.Authors.Where(author => author.Id == id).FirstOrDefault();
        }
        public List<Post> GetPostsByAuthor(int id)
        {
            return _dataInitializer.Posts.Where(post => post.Author.Id == id).ToList();
        }
        public List<SocialNetworkProfile> GetSocialNetworkProfilesByAuthor(int id)
        {
            return _dataInitializer.SocialNetworkProfiles.Where(sn => sn.Author.Id == id).ToList();
        }
    }
}
