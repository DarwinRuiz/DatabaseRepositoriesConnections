using DatabaseRepositoriesConnections.DataStuff.DataSets;
using DatabaseRepositoriesConnections.DataStuff.DataSets.CustomerDSTableAdapters;
using DatabaseRepositoriesConnections.DataStuff.Models;

namespace DatabaseRepositoriesConnections.DataStuff.Repositories
{
    public class ADODisconnectedRepository : IRepository
    {

        CustomersTableAdapter customersTableAdapter = new CustomersTableAdapter();

        public int DeleteCustomer(string id)
        {

            int deleted = this.customersTableAdapter.DeleteCustomerByID(id);

            return deleted;
        }

        public CustomerModel GetCustomerById(string id)
        {
            CustomerDS.CustomersDataTable customer = this.customersTableAdapter.GetDataByCustomerID(id);

            if (customer.Count == 0)
            {
                return null;
            }

            return this.ReadFromDataReader(customer[0]);
        }

        public List<CustomerModel> GetCustomers()
        {
            CustomerDS.CustomersDataTable customers = this.customersTableAdapter.GetData();
            List<CustomerModel> customerList = new List<CustomerModel>();

            foreach (CustomerDS.CustomersRow customer in customers)
            {
                customerList.Add(this.ReadFromDataReader(customer));
            }


            return customerList;
        }

        public int InsertCustomer(CustomerModel customer)
        {
            int inserted = this.customersTableAdapter.Insert(
                customer.CustomerID,
                customer.CompanyName,
                customer.ContactName,
                customer.ContactTitle,
                customer.Address,
                customer.City,
                customer.Region,
                customer.PostalCode,
                customer.Country,
                customer.Phone,
                customer.Fax);

            return inserted;
        }

        public int UpdateCustomer(CustomerModel customer)
        {
            int updated = this.customersTableAdapter.UpdateCustomerByID(
                customer.CompanyName,
                customer.ContactName,
                customer.ContactTitle,
                customer.Address,
                customer.City,
                customer.Region,
                customer.PostalCode,
                customer.Country,
                customer.Phone,
                customer.Fax,
                customer.CustomerID
                );

            return updated;
        }


        private CustomerModel ReadFromDataReader(CustomerDS.CustomersRow row)
        {
            CustomerModel customer = new CustomerModel();

            customer.CustomerID = !Convert.IsDBNull(row["CustomerID"]) ? row["CustomerID"].ToString() : null;
            customer.CompanyName = !Convert.IsDBNull(row["CompanyName"]) ? row["CompanyName"].ToString() : null;
            customer.ContactName = !Convert.IsDBNull(row["ContactName"]) ? row["ContactName"].ToString() : null;
            customer.ContactTitle = !Convert.IsDBNull(row["ContactTitle"]) ? row["ContactTitle"].ToString() : null;
            customer.Address = !Convert.IsDBNull(row["Address"]) ? row["Address"].ToString() : null;
            customer.City = !Convert.IsDBNull(row["City"]) ? row["City"].ToString() : null;
            customer.Region = !Convert.IsDBNull(row["Region"]) ? row["Region"].ToString() : null;
            customer.PostalCode = !Convert.IsDBNull(row["PostalCode"]) ? row["PostalCode"].ToString() : null;
            customer.Country = !Convert.IsDBNull(row["Country"]) ? row["Country"].ToString() : null;
            customer.Phone = !Convert.IsDBNull(row["Phone"]) ? row["Phone"].ToString() : null;
            customer.Fax = !Convert.IsDBNull(row["Fax"]) ? row["Fax"].ToString() : null;

            return customer;
        }
    }
}
