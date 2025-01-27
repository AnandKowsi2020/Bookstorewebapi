using BookWepApi.Data;
using BookWepApi.Models;
using Microsoft.EntityFrameworkCore;

namespace BookWepApi.Repositories
{
    public class BookRepository : IBookRepositories
    {
        private readonly BooksDbContext _context;

        public BookRepository(BooksDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Book>> GetBooksSortedByPublisherAsync()
        {
            return await _context.Books
                .OrderBy(b => b.Publisher)
                .ThenBy(b => b.AuthorLastName)
                .ThenBy(b => b.AuthorFirstName)
                .ThenBy(b => b.Title)
                .ToListAsync();
        }

        public async Task<IEnumerable<Book>> GetBooksSortedByAuthorAsync()
        {
            return await _context.Books
                .OrderBy(b => b.AuthorLastName)
                .ThenBy(b => b.AuthorFirstName)
                .ThenBy(b => b.Title)
                .ToListAsync();
        }

        public async Task<decimal> GetTotalPriceAsync()
        {
            return await _context.Books.SumAsync(b => b.Price);
        }

        public async Task AddBooksAsync(IEnumerable<Book> books)
        {
            await _context.Books.AddRangeAsync(books);
            await _context.SaveChangesAsync();
        }
    }
}
