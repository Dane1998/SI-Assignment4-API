using BookService.Models;

namespace BookService.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class Controller : ControllerBase
    {
        private readonly IBookService bookService;
        public Controller(IBookService bookService)
        {
            bookService = bookService;
        }

        [HttpGet("")]
        public Task<List<Book>> GetAllBooks()
        {
            return bookService.GetAllBooks();
        }

        [HttpPost]
        public Task<bool> BuyBook(BuyBook buyBook)
        {
            return bookService.BuyBook(buyBook);
        }

        [HttpPut("{bookId}")]
        public Task<bool> ReturnBook(int bookId)
        {
            return bookService.ReturnBook(bookId);
        }
    }
}