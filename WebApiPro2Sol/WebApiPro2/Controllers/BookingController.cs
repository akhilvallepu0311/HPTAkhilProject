using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiPro2.DataAccess.IRepositories;
using WebApiPro2.Models;

namespace WebApiPro2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        public IBookingRepository empRef2;
        public BookingController(IBookingRepository _empRef2)
        {
            empRef2 = _empRef2;
        }


        [HttpPost]
        [Route("InsertBooking")]
        public async Task<IActionResult> InsertBooking(Booking Book)
        {
            try
            {
                var count = await empRef2.InsertBooking(Book);
                if (count > 0)
                {
                    return Ok(count + ":Record Inserted...!");
                }
                else
                {
                    return BadRequest("Records are not Available...!");
                }
            }
            catch (Exception ex)
            {
                return BadRequest("Sorry for Inconvinences..!\n We will Solve this Soon...!\n" + ex.Message);
            }
        }

        [HttpGet]
        [Route("AllBooking")]
        public async Task<IActionResult> AllBooking()
        {
            try
            {
                var BookList = await empRef2 .GetAllBookings();
                if(BookList.Count > 0)
                {
                    return Ok(BookList);
                }
                else
                {
                    return BadRequest("Records are not available..!");
                }
            }
            catch (Exception ex)
            {
                return BadRequest("Sorry for Inconvinences..!\n We will Solve this Soon...!\n" + ex.Message);
            }
        }

        [HttpPut]
        [Route("UpdateBooking")]
        public async Task<IActionResult> UpdateBooking(Booking Book)
        {
            try
            {
                var count  = await empRef2.UpdateBooking(Book);
                if(count > 0)
                {
                    return Ok (count + " : Record Updated..!");
                }
                else
                {
                    return BadRequest("Record Not Updated..!");
                }
            }
            catch (Exception ex)
            {
                return BadRequest("Sorry for Inconvinences..!\n We will Solve this Soon...!\n" + ex.Message);
            }
        }

        [HttpDelete]
        [Route("DeleteOrder")]
        public async Task<IActionResult>DeleteOrder(int Book)
        {
            try
            {
                var count = await empRef2.DeleteBooking(Book);
                if(count > 0)
                {
                    return Ok(count + ": Records Deleted..!");
                }
                else
                {
                    return BadRequest("Record is not Deleted..!");
                }
            }
            catch (Exception ex)
            {
                return BadRequest("Sorry for Inconvinences..!\n We will Solve this Soon...!\n" + ex.Message);
            }
        }

        [HttpGet]
        [Route("BookingById")]
        public async Task<IActionResult>BookingById(int BookId)
        {
            try
            {
                var Book = await empRef2.GetBookingById(BookId);
                if(Book != null)
                {
                    return Ok (Book);
                }
                else
                {
                    return BadRequest("Records are not available..!");
                }
            }
            catch (Exception ex)
            {
                return BadRequest("Sorry for Inconvinences..!\n We will Solve this Soon...!\n" + ex.Message);
            }
        }

        [HttpGet]
        [Route("OrderByStatus")]
        public async Task<IActionResult>BookingByStatus(string Status)
        {
            try
            {
                var BookList = await empRef2.GetBookingBystatus(Status);
                if(BookList.Count > 0)
                {
                    return Ok(BookList);
                }
                else
                {
                    return BadRequest("Records are not available..!");
                }
            }
            catch (Exception ex)
            {
                return BadRequest("Sorry for Inconvinences..!\n We will Solve this Soon...!\n" + ex.Message);
            }
        }

        [HttpGet]
        [Route("BookingByCustId")]
        public async Task<IActionResult>BookingByCustId(int CustId)
        {
            try
            {
                var Custs = await empRef2.GetBookingByCustomerId(CustId);
                if (Custs.Count > 0)
                {
                    return Ok((Custs));
                }
                else
                {
                    return BadRequest("Records are not Available..!");
                }
            }
            catch (Exception ex)
            {
                return BadRequest("Sorry for Inconvinences..!\n We will Solve this Soon...!\n" + ex.Message);
            }
        }


    }
}
