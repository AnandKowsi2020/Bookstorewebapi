using BookWepApi.Models;
using Microsoft.EntityFrameworkCore;

namespace BookWepApi.Data
{
    public class BooksDbContext:DbContext 
    {
        public BooksDbContext(DbContextOptions<BooksDbContext> options) : base(options) { }

        public DbSet<Book> Books { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Book>().HasKey(b => b.Id);
            modelBuilder.Entity<Book>().Property(b => b.Price).HasColumnType("decimal(18, 2)");
        }
    }
}
