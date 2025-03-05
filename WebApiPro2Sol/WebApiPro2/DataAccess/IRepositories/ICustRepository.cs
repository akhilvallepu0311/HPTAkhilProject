using WebApiPro2.Models;

namespace WebApiPro2.DataAccess.IRepositories
{
    public interface ICustRepository
    {
        Task<int> InsertCustomer(Customer Cust);
        Task<List<Customer>>AllCustomer();
        Task<Customer>GetCustomerById(int Id);
        Task<List<Customer>>GetCustomerByAddress(string Address);
        Task<int> UpdateCustomer(Customer Cust);
        Task<int> DeleteCustomerById(int CustId);
        Task<int>DeleteAllCustomers();
    }
}
