using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApiPro2.Models
{
    [Table("Customer")]
    public class Customer
    {
        [Key]

        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string Email {  get; set; }
        public string Phone { get; set; }   
        public string Address { get; set; }
        public DateTime BookingDate { get; set; }
        public ICollection<Booking>? Bookings { get; set; }
    }
}
