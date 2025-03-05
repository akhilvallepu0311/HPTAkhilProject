using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApiPro2.Models
{
    [Table("Booking")]
    public class Booking
    {
        [Key]
        public int BookingId { get; set; }
        public Decimal? Amount{ get; set; }
        public string Status  { get; set; }

        [ForeignKey("Customer")]
        public int CustomerId { get; set; }
        public Customer? Customer { get; set; }
    }
}
