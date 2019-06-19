using System.Collections.Generic;

namespace Shared.Entities
{
    public class Author
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Bio { get; set; }
        public List<Post> Posts { get; set; }
        public List<SocialNetworkProfile> Socials { get; set; }
    }
}
