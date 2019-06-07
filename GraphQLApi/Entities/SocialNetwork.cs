namespace GraphQLApi.Entities
{
    public class SocialNetwork
    {
        public SocialNetworkType Type { get; set; }
        public string NickName { get; set; }
        public string Url { get; set; }
        public Author Author { get; set; }
    }
}
