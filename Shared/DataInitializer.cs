using Shared.Entities;
using System;
using System.Collections.Generic;

namespace Shared
{
    public class DataInitializer : IDataInitializer
    {
        public List<Author> Authors { get; } = new List<Author>();
        public List<Post> Posts { get; } = new List<Post>();
        public List<SocialNetworkProfile> SocialNetworkProfiles { get; } = new List<SocialNetworkProfile>();

        public DataInitializer()
        {
            var DinoEsposito = new Author
            {
                Id = 1,
                Name = "Dino Esposito",
                Bio = "Dino Esposito has authored more than 20 books and 1,000 articles in ..."
            };

            var LanceTalbert = new Author
            {
                Id = 2,
                Name = "Lance Talbert",
                Bio = "Lance Talbert is a budding game developer that has been learning to program since ..."
            };

            Authors.Add(DinoEsposito);
            Authors.Add(LanceTalbert);

            var comment1 = new Comment
            {
                Id = 1,
                Commenter = "Bob",
                Description = "Bla bla bla"
            };

            var FormsInVanilla = new Post
            {
                Id = 1,
                Title = "Building Better HTML Forms in Vanilla-JS",
                Description = "Creating forms is one of the most basic skills for a web developer...",
                Date = DateTime.Today,
                Url = "https://www.red-gate.com/simple-talk/dotnet/net-development/building-better-html-forms-in-vanilla-js/",
                Author = DinoEsposito,
                Rating = 5,
                Categories = new string[] { ".NET Development" },
                Comments = new List<Comment> { comment1 }
            };

            var comment2 = new Comment
            {
                Id = 2,
                Commenter = "Fred",
                Description = "Bla bla bla"
            };

            var VoiceCommands = new Post
            {
                Id = 2,
                Title = "Voice Commands in Unity",
                Description = "Today, we use voice in many ways. We can order groceries...",
                Date = DateTime.Today,
                Url = "https://www.red-gate.com/simple-talk/dotnet/c-programming/voice-commands-in-unity/",
                Author = LanceTalbert,
                Rating = 4,
                Categories = new string[] { "C# programming" },
                Comments = new List<Comment> { comment2 }
            };

            Posts.Add(FormsInVanilla);
            Posts.Add(VoiceCommands);

            var sn1 = new SocialNetworkProfile()
            {
                Id = 1,
                Type = SocialNetworkType.Instagram,
                Author = DinoEsposito,
                NickName = "@dino",
                Url = "https://#"
            };

            var sn2 = new SocialNetworkProfile()
            {
                Id = 2,
                Type = SocialNetworkType.Twitter,
                Author = DinoEsposito,
                NickName = "@dino",
                Url = "https://#"
            };
            SocialNetworkProfiles.Add(sn1);
            SocialNetworkProfiles.Add(sn2);
        }
    }
}
