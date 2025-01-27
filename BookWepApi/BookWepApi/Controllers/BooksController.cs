using BookWepApi.Models;
using BookWepApi.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace BookWepApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        //Dependency Injection to implementation of the repository 
        // Injected the controller
        private readonly IBookRepositories _repository;

        //Constructor 
        public BooksController(IBookRepositories repository)
        {
            _repository = repository;
        }

        [HttpGet("get-book-sorted-by-publisher")]
        public async Task<IActionResult> GetBooksSortedByPublisher()
        {
            var books = await _repository.GetBooksSortedByPublisherAsync();
            return Ok(books);
        }

        [HttpGet("get-book-sorted-by-author")]
        public async Task<IActionResult> GetBooksSortedByAuthor()
        {
            var books = await _repository.GetBooksSortedByAuthorAsync();
            return Ok(books);
        }

        [HttpGet("get-total-price")]
        public async Task<IActionResult> GetTotalPrice()
        {
            var totalPrice = await _repository.GetTotalPriceAsync();
            return Ok(totalPrice);
        }

        [HttpPost("batch-insert")]
        public async Task<IActionResult> BatchInsert([FromBody] IEnumerable<Book> books)
        {
            await _repository.AddBooksAsync(books);
            return Ok();
        }
    }
}
