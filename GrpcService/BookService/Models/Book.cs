
namespace BookService.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Author { get; set; }
        public string? Class { get; set; }
        public double Price { get; set; }

        public ICollection<Order>? Orders { get; set; }
    }
}