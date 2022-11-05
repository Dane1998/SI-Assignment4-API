using GrpcServices.Context;
using GrpcServices.Models;

namespace GrpcServices.Repository
{
    public interface IBookRepo
    {
        Task<List<Book>> GetAllBooks();
        Task<bool> BuyBook(BuyBook BuyBook);
        Task<bool> ReturnBook(int bookId);
    }

    public class BookRepo : IBookRepo
    {
        private DatabaseContext DBcontext;

        public BookRepo(DatabaseContext dbApplicationContext)
        {
            DBcontext = dbApplicationContext;
        }
        public Task<List<Book>> GetAllBooks()
        {
            return DBcontext.Books.ToList();
        }

        public Task<bool> BuyBook(BuyBook BuyBook)
        {
            var book = DBcontext.Books(BuyBook.BookId);
            var newOrder = new Order
            {
                BookId = BuyBook.BookId,
                StudentId = BuyBook.StudentId
            };
            return true;
        }

        public Task<bool> ReturnBook(int bookId)
        {
            var book = DBcontext.Books(bookId);
            return true;      
        }
    }
}