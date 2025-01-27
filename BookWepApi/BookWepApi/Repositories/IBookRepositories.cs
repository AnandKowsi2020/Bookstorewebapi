using BookWepApi.Models;

namespace BookWepApi.Repositories
{
    public interface IBookRepositories
    {
       
            Task<IEnumerable<Book>> GetBooksSortedByPublisherAsync();
            Task<IEnumerable<Book>> GetBooksSortedByAuthorAsync();
            Task<decimal> GetTotalPriceAsync();
            Task AddBooksAsync(IEnumerable<Book> books);
        
    }
}
