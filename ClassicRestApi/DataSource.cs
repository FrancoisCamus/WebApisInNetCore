using ClassicRestApi.Models;
using System.Collections.Generic;

namespace ClassicRestApi
{
    public class DataSource
    {
        private static IList<Book> _books { get; set; }

        public static IList<Book> GetBooks()
        {
            if (_books != null)
            {
                return _books;
            }

            _books = new List<Book>();

            var book1 = new Book
            {
                Id = 1,
                ISBN = "978-0-321-87758-1",
                Title = "Essential C#5.0",
                Price = 59.99m,
            };
            _books.Add(book1);

            var book2 = new Book
            {
                Id = 2,
                ISBN = "063-6-920-02371-5",
                Title = "Enterprise Games",
                Price = 49.99m,
            };
            _books.Add(book2);

            return _books;
        }
    }
}
