using GrpcServices.Models;
using GrpcServices.Repository;

namespace GrpcServices.Services
{
    public class GrpcService : Greeter.GreeterBase
    {
        private IBookRepo bookRepo;
        public GrpcService(IBookRepo bookRepo)
        {
            bookRepo = bookRepo;
        }
        public Task<BookList> GetAllBooks(Something something, ServerCallContext context)
        {
            var books = bookRepo.GetAllBooks();
            var tempBooksList = books.Select(b =>
            new BookReply
            {
                Title = b.Title,
                Author = b.Author,
                Class = b.Class,
                Price = b.Price,
            }).ToList();

            var bookList = new BookList();
            bookList.BookReply.AddRange(tempBooksList);

            return bookList;
        }
        public Task<BookResponse> BuyBook(BuyBookRequest buyBookRequest, ServerCallContext context)
        {
            var isSuccess = bookRepo.BuyBook(new BuyBook
            {
                BookId = buyBookRequest.BookId,
            });

            return new BookResponse { IsSuccess = isSuccess };
        }

        public Task<BookResponse> ReturnBook(ReturnBookRequest returnBookRequest, ServerCallContext context)
        {
            var isSuccess = bookRepo.ReturnBook(returnBookRequest.BookId);
            return new BookResponse { IsSuccess = isSuccess };
        }

        
    }
}