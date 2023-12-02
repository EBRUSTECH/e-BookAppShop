using BookAppTask.Models;
using Microsoft.EntityFrameworkCore;

namespace BookAppTask.Data
{
    public class BookAppTaskDbContext : DbContext
    {
        public BookAppTaskDbContext(DbContextOptions<BookAppTaskDbContext> options) : base(options)
        {

        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}
