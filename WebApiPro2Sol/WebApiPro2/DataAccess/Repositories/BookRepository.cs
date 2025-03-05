using Microsoft.EntityFrameworkCore;
using WebApiPro2.DataAccess.IRepositories;
using WebApiPro2.DBContext;
using WebApiPro2.Models;

namespace WebApiPro2.DataAccess.Repositories
{
    public class BookRepository : IBookingRepository
    {
        public ProjectDB2Context dB2Context;
        public BookRepository(ProjectDB2Context _dB2Context)
        {
            dB2Context = _dB2Context;
        }
        public async Task<int> DeleteBooking(int BookId)
        {
            var Book = await dB2Context.Bookings.FindAsync(BookId);
            dB2Context.Bookings.Remove(Book);
            return await dB2Context.SaveChangesAsync();
        }

        public async Task<List<Booking>> GetAllBookings()
        {
            return await dB2Context.Bookings.ToListAsync();
        }

        public async Task<List<Booking>> GetBookingByCustomerId(int CustId)
        {
            return await dB2Context.Bookings.Where(x=>x.CustomerId == CustId).ToListAsync();
        }

        public async Task<Booking> GetBookingById(int BookId)
        {
            return await dB2Context.Bookings.FindAsync(BookId);
        }

        public async Task<List<Booking>> GetBookingBystatus(string Status)
        {
            return await dB2Context.Bookings.Where(x=>x.Status == Status).ToListAsync();
        }

        public async Task<int> InsertBooking(Booking Book)
        {
           await dB2Context.Bookings.AddAsync(Book);
            return await dB2Context.SaveChangesAsync();
        }

        public async Task<int> UpdateBooking(Booking Book)
        {
            dB2Context.Bookings.Update(Book); 
            return await dB2Context.SaveChangesAsync();
        }
    }
}
