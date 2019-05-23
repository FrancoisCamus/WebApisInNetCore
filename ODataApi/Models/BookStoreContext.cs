using Microsoft.EntityFrameworkCore;

namespace ODataApi.Models
{
    public class BookStoreContext : DbContext
    {
        public BookStoreContext(DbContextOptions<BookStoreContext> options)
          : base(options)
        {
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Press> Presses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Maps Address as complex type
            modelBuilder.Entity<Book>().OwnsOne(c => c.Location);
        }
    }
}
