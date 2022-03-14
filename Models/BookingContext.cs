using Microsoft.EntityFrameworkCore;
namespace TBS.Models
{
    public class BookingContext : DbContext
    {
        public BookingContext(DbContextOptions<BookingContext> options)
           : base(options)
        {
        }

        public DbSet<TaxiBooking> Bookings { get; set; } = null!;
    }
}
