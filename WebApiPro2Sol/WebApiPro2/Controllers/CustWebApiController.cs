using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiPro2.DataAccess.IRepositories;
using WebApiPro2.Models;

namespace WebApiPro2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustWebApiController : ControllerBase
    {
        public ICustRepository deptRef2;
        public CustWebApiController(ICustRepository _deptRef2)
        {
            deptRef2 = _deptRef2;
        }

        [HttpPost]
        [Route("InsertCustomer")]
        public async Task<IActionResult>InsertCustomer(Customer Cust)
        {
            try
            {
                var count = await deptRef2.InsertCustomer(Cust);
                if (count > 0)
                {
                    return Ok(count+"Record Inserted");
                }
                else
                {
                    return BadRequest("Data Not Inserted...!");
                }

            }
            catch (Exception ex)
            {
                return BadRequest("Sorry for Inconvinences..!\n We will Solve this Soon...!\n"+ex.Message);
            }

        }

        [HttpGet]
        [Route("AllCustomers")]
        public async Task<IActionResult> AllCustomers()
        {
            try
            {
                var Custs = await deptRef2.AllCustomer();
                if(Custs.Count > 0)
                {
                    return Ok(Custs);
                }
                else
                {
                    return BadRequest("There is no data Available");
                }

            }
            catch (Exception ex)
            {
                return BadRequest("Sorry for Inconvinences..!\n We will Solve this Soon...!\n" + ex.Message);
            }

        }

        [HttpGet]
        [Route("CustomerById")]
        public async Task<IActionResult>CustomerById(int id)
        {
            try
            {
                var Cust = await deptRef2.GetCustomerById(id);
                if (Cust != null)
                {
                    return Ok(Cust);
                }
                else
                {
                    return NotFound("Customer with CustId:" + id + "is not Available");
                }
            }
            catch (Exception ex)
            {
                return BadRequest("Sorry for Inconvinences..!\n We will Solve this Soon...!\n" + ex.Message);
            }
        }
        [HttpPut]
        [Route("UpdateCustomer")]
        public async Task<IActionResult>UpdateCustomer(Customer Cust)
        {
            try
            {
                var count = await deptRef2.UpdateCustomer(Cust);
                if (count > 0)
                {
                    return Ok("Record Updated...!");
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
        [Route("DeleteCustomer")]
        public async Task<IActionResult>DeleteCustomer(int CustId)
        {
            try
            {
                var count = await deptRef2.DeleteCustomerById(CustId);
                if (count > 0)
                {
                    return Ok("Record Deleted");
                }
                else
                {
                    return BadRequest("Records Not Deleted..!");
                }
            }
            catch (Exception ex)
            {
                return BadRequest("Sorry for Inconvinences..!\n We will Solve this Soon...!\n" + ex.Message);
            }
        }

        [HttpDelete]
        [Route("DeleteAllCustomers")]
        public async Task<IActionResult> DeleteAllCustomers()
        {
            try
            {
                var count  = await deptRef2.DeleteAllCustomers();
                if(count > 0)
                {
                    return Ok("All Records Deleted..!");
                }
                else
                {
                    return NotFound("No Records Deleted..!");
                }
            }
            catch (Exception ex)
            {
                return BadRequest("Sorry for Inconvinences..!\n We will Solve this Soon...!\n" + ex.Message);
            }
        }

        [HttpGet]
        [Route("CustomerByAddress")]
        public async Task<IActionResult> CustomerByAddress(String Address)
        {
            try
            {
                var Custs = await deptRef2.GetCustomerByAddress(Address);
                if(Custs != null)
                {
                    return Ok(Custs);
                }
                else
                {
                    return NotFound("Customer With CustId: "+Address+"is not Available");
                }
            }
            catch (Exception ex)
            {
                return BadRequest("Sorry for Inconvinences..!\n We will Solve this Soon...!\n" + ex.Message);
            }
        }



    }
}
