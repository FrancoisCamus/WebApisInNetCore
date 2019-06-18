using System.Collections.Generic;

namespace ClassicRestApi.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string ISBN { get; set; }
        public string Title { get; set; }
        public IEnumerable<Author> Authors { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public string Language { get; set; }
        public Publisher Publisher { get; set; }
        public IEnumerable<Review> Reviews { get; set; }
    }
}
