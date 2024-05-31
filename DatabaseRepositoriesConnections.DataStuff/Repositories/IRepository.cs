using DatabaseRepositoriesConnections.DataStuff.Models;

namespace DatabaseRepositoriesConnections.DataStuff.Repositories
{
    public interface IRepository
    {
        List<CustomerModel> GetCustomers();
        CustomerModel GetCustomerById(string id);
        int InsertCustomer(CustomerModel customer);
        int UpdateCustomer(CustomerModel customer);
        int DeleteCustomer(string id);
    }
}