using BookService.Models;

namespace BookService.Service
{
    public interface IBookService
    {
        public Task<List<Book>> GetAllBooks();
        public Task<bool> BuyBook(BuyBook buyBook);
        public Task<bool> ReturnBook(int bookId);
    }
    public class BookService : IBookService
    {
        public Task<List<Book>> GetAllBooks()
        {
            var channel = GrpcChannel.ForAddress("https://localhost:1234");
            var client = new Greeter.GreeterClient(channel);
            var books = client.GetAllBooks(new Empty());

            var bookList = books.Reply.Select(b =>
            new Book
            {
                Title = b.Title,
                Author = b.Author,
                Class = b.Class,
                Price = b.Price
            }).ToList();

            return bookList;
        }
        public Task<bool> BuyBook(BuyBook buyBook)
        {
            var channel = GrpcChannel.ForAddress("https://localhost:1234");
            var client = new Greeter.GreeterClient(channel);

            return client.BuyBook(
                new BuyBookRequest
                {
                    BookId = buyBook.BookId,
                }).IsSuccess;
        }

        public Task<bool> ReturnBook(int bookId)
        {
            var channel = GrpcChannel.ForAddress("https://localhost:1234");
            var client = new Greeter.GreeterClient(channel);

            return client.ReturnBook(
             new ReturnBookRequest
             {
                 BookId = bookId
             }).IsSuccess;
        }
    }
}