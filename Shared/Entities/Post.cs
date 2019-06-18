using System;
using System.Collections.Generic;

namespace Shared.Entities
{
    public class Post
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public string Url { get; set; }
        public Author Author { get; set; }
        public string[] Categories { get; set; }
        public int Rating { get; set; }
        public List<Comment> Comments { get; set; }
    }
}
