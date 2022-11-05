using GrpcServices.Models;

namespace GrpcServices.Context
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }
        public DbSet<Book>? Books { get; set; }
        public DbSet<Order>? Orders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            Seed(modelBuilder);
            base.OnModelCreating(modelBuilder);
        }
        private void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Order>()
                .HasKey(x => new {x.BookId });

            modelBuilder
                .Entity<Order>()
                .HasOne(a => a.Book)
                .WithMany(b => b.Orders)
                .HasForeignKey(c => c.BookId);

            modelBuilder.Entity<Book>().HasData(
                new Book
                {
                    Id = 1,
                    Author = "Author1",
                    Price = 234,
                    Class = "Test",
                    Title = "Test Book",
                },
                new Book
                {
                    Id = 2,
                    Author = "Author2",
                    Price = 432,
                    Class = "System integration",
                    Title = "System integration Book",
                },

                new Book
                {
                    Id = 3,
                    Author = "Author3",
                    Price = 345,
                    Class = "Development of large systems",
                    Title = "Development of large systems Book",
                });
        }
    }
}