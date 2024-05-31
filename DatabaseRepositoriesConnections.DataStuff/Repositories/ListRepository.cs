using DatabaseRepositoriesConnections.DataStuff.Models;

namespace DatabaseRepositoriesConnections.DataStuff.Repositories
{
    public class ListRepository : IRepository
    {
        List<CustomerModel> allCustomers;
        public ListRepository()
        {
            allCustomers = new List<CustomerModel>()
            {
                new()
                {
                    CustomerID = "ALFKI",
                    CompanyName = "Alfreds Futterkiste",
                    ContactName = "Maria Anders",
                    ContactTitle = "Sales Representative",
                    Address = "Obere Str. 57",
                    City = "Berlin",
                    Region = null,
                    PostalCode = "12209",
                    Country = "Germany",
                    Phone = "030-0074321",
                    Fax = "030-0076545"
                },
                new()
                {
                    CustomerID = "ANATR",
                    CompanyName = "Ana Trujillo Emparedados y helados",
                    ContactName = "Ana Trujillo",
                    ContactTitle = "Owner",
                    Address = "Avda. de la Constitución 2222",
                    City = "México D.F.",
                    Region = null,
                    PostalCode = "05021",
                    Country = "Mexico",
                    Phone = "(5) 555-4729",
                    Fax = "(5) 555-3745"
                },
                new()
                {
                    CustomerID = "ANTON",
                    CompanyName = "Antonio Moreno Taquería",
                    ContactName = "Antonio Moreno",
                    ContactTitle = "Owner",
                    Address = "Mataderos 2312",
                    City = "México D.F.",
                    Region = null,
                    PostalCode = "05023",
                    Country = "Mexico",
                    Phone = "(5) 555-3932",
                    Fax = null
                },
                new()
                {
                    CustomerID = "AROUT",
                    CompanyName = "Around the Horn",
                    ContactName = "Thomas Hardy",
                    ContactTitle = "Sales Representative",
                    Address = "120 Hanover Sq.",
                    City = "London",
                    Region = null,
                    PostalCode = "WA1 1DP",
                    Country = "UK",
                    Phone = "(171) 555-7788",
                    Fax = "(171) 555-6750"
                },
                new()
                {
                    CustomerID = "BERGS",
                    CompanyName = "Berglunds snabbköp",
                    ContactName = "Christina Berglund",
                    ContactTitle = "Order Administrator",
                    Address = "Berguvsvägen 8",
                    City = "Luleå",
                    Region = null,
                    PostalCode = "S-958 22",
                    Country = "Sweden",
                    Phone = "0921-12 34 65",
                    Fax = "0921-12 34 67"
                },
            };            
        }
        public int DeleteCustomer(string id)
        {
            int deleted = allCustomers.RemoveAll(c => c.CustomerID == id);
            return deleted;
        }

        public CustomerModel GetCustomerById(string id)
        {
            var customer = allCustomers.FirstOrDefault(c => c.CustomerID == id);
            return customer;
        }

        public List<CustomerModel> GetCustomers()
        {
            return allCustomers;
        }

        public int InsertCustomer(CustomerModel customer)
        {
            allCustomers.Add(customer);
            return 1;
        }

        public int UpdateCustomer(CustomerModel customer)
        {
            var original = GetCustomerById(customer.CustomerID);
            if (original != null)
            {
                original.CompanyName = customer.CompanyName;
                original.ContactName = customer.ContactName;
                original.ContactTitle = customer.ContactTitle;
                original.Address = customer.Address;
                original.City = customer.City;
                original.Region = customer.Region;
                original.PostalCode = customer.PostalCode;
                original.Country = customer.Country;
                original.Phone = customer.Phone;
                original.Fax = customer.Fax;
                return 1;
            }
            else
            {
                return 0;
            }
        }
    }
}
