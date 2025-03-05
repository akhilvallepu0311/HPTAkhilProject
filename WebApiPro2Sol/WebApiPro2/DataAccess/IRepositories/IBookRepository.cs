using WebApiPro2.Models;

namespace WebApiPro2.DataAccess.IRepositories
{
    public interface IBookingRepository
    {
        Task<int>InsertBooking(Booking Book);
        Task<List<Booking>>GetAllBookings();
        Task<Booking>GetBookingById(int BookId);
        Task<List<Booking>>GetBookingBystatus(string Status);
        Task<List<Booking>>GetBookingByCustomerId(int CustId);
        Task<int>UpdateBooking(Booking Book);
        Task<int>DeleteBooking(int BookId);
    }
}
