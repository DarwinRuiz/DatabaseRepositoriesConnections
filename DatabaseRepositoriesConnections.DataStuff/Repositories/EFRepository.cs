using DatabaseRepositoriesConnections.DataStuff.DataSets;
using DatabaseRepositoriesConnections.DataStuff.Models;

namespace DatabaseRepositoriesConnections.DataStuff.Repositories
{
    public class EFRepository : IRepository
    {

        private NorthwindDbContext _context = new NorthwindDbContext();

        public EFRepository()
        {
            this._context.Database.EnsureCreated();
            CustomerModel testCustomer = this._context.Customer.Find("ABCYX");
            if (testCustomer != null)
            {
                this._context.Customer.Remove(testCustomer);
                this._context.SaveChanges();
            }
        }

        public int DeleteCustomer(string id)
        {
            this._context.Customer.Remove(this.GetCustomerById(id));
            return this._context.SaveChanges();
        }

        public CustomerModel GetCustomerById(string id)
        {
            return this._context.Customer.FirstOrDefault(customer => customer.CustomerID == id);
        }

        public List<CustomerModel> GetCustomers()
        {
            return this._context.Customer.ToList();
        }

        public int InsertCustomer(CustomerModel customer)
        {
            this._context.Customer.Add(customer);
            return this._context.SaveChanges();
        }

        public int UpdateCustomer(CustomerModel customer)
        {
            this._context.Customer.Update(customer);
            return this._context.SaveChanges();
        }
    }
}
