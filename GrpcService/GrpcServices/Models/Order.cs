namespace GrpcServices.Models
{
    public class Order
    {
        [ForeignKey("BookId")]
        public int BookId { get; set; }
        public Book? Book { get; set; }
    }
}
