namespace Shared.Entities
{
    public class SocialNetworkProfile
    {
        public int Id { get; set; }
        public SocialNetworkType Type { get; set; }
        public string NickName { get; set; }
        public string Url { get; set; }
        public Author Author { get; set; }
    }
}
