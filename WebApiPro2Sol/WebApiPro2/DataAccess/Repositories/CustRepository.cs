using Microsoft.EntityFrameworkCore;
using WebApiPro2.DataAccess.IRepositories;
using WebApiPro2.DBContext;
using WebApiPro2.Models;

namespace WebApiPro2.DataAccess.Repositories
{
    public class CustRepository : ICustRepository
    {
        public ProjectDB2Context dB2Context;
        public CustRepository(ProjectDB2Context _dB2Context)
        {
            dB2Context = _dB2Context;
        }

        public async Task<List<Customer>> AllCustomer()
        {
            return await dB2Context.Customers.ToListAsync();
        }

        public async Task<int> DeleteAllCustomers()
        {
            var CustList= await dB2Context.Customers.ToListAsync();
            dB2Context.Customers.RemoveRange(CustList);
            return await dB2Context.SaveChangesAsync();
        }

        public async Task<int> DeleteCustomerById(int CustId)
        {
            var Cust = await dB2Context.Customers.FindAsync(CustId);
            dB2Context.Customers.Remove(Cust);
            return await dB2Context.SaveChangesAsync();
        }

        public async Task<List<Customer>> GetCustomerByAddress(string Address)
        {
            return await dB2Context.Customers.Where(x=>x.Address == Address).ToListAsync();
        }

        public async Task<Customer> GetCustomerById(int Id)
        {
            return await dB2Context.Customers.FindAsync(Id);
        }

        public async Task<int>InsertCustomer(Customer Cust)
        {
           await dB2Context.Customers.AddAsync(Cust);
            return await dB2Context.SaveChangesAsync();    
        }

        public async Task<int> UpdateCustomer(Customer Cust)
        {
            dB2Context.Customers.Update(Cust);
            return await dB2Context.SaveChangesAsync() ;
        }
    }
}
