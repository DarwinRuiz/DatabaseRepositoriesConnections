using DatabaseRepositoriesConnections.DataStuff.Models;
using Dapper;
using System.Data.SqlClient;

namespace DatabaseRepositoriesConnections.DataStuff.Repositories
{
    public class DapperRepository : IRepository
    {
        public int DeleteCustomer(string id)
        {
            using (SqlConnection connection = DatabaseConnection.GetSqlConnection())
            {
                string query = @"DELETE FROM Customer WHERE customerID = @customerId;";

                int resultDetelete = connection.Execute(query, new { customerId = id });

                return resultDetelete;
            }
        }

        public CustomerModel GetCustomerById(string id)
        {
            using (SqlConnection connection = DatabaseConnection.GetSqlConnection())
            {
                string query = @"SELECT CustomerID, CompanyName,
                        ContactName, ContactTitle,
                        Address, City, Region, PostalCode, Country, Phone, Fax
                        FROM Customers WHERE customerID = @customerId;
                    "
                ;

                CustomerModel customer = connection.QueryFirstOrDefault<CustomerModel>(query, new { customerId = id });
                return customer;
            }
        }

        public List<CustomerModel> GetCustomers()
        {
            using (SqlConnection connection = DatabaseConnection.GetSqlConnection())
            {
                string query = @"SELECT CustomerID, CompanyName,
                        ContactName, ContactTitle,
                        Address, City, Region, PostalCode, Country, Phone, Fax
                        FROM Customers;
                    ";
                List<CustomerModel> customer = connection.Query<CustomerModel>(query).ToList();
                return customer;
            }


        }

        public int InsertCustomer(CustomerModel customer)
        {
            using (SqlConnection connection = DatabaseConnection.GetSqlConnection())
            {
                string query = @"INSERT INTO Customers (CustomerID, CompanyName, ContactName, ContactTitle, Address, City, Region, PostalCode, Country, Phone, Fax) 
                                VALUES (@customerID, @companyName, @contactName, @contactTitle, @address, @city, @region, @postalCode, @country, @phone, @fax)"
                ;


                //Si los campos del modelo son iguales a los atributos de la clase se puede enviar la instancia del objeto directamente
                //int responseInsert = connection.Execute(query, customer);
                int responseInsert = connection.Execute(query, new
                {
                    customerID = customer.CustomerID,
                    companyName = customer.CompanyName,
                    contactName = customer.ContactName,
                    contactTitle = customer.ContactTitle,
                    address = customer.Address,
                    city = customer.City,
                    region = customer.Region,
                    postalCode = customer.PostalCode,
                    country = customer.Country,
                    phone = customer.Phone,
                    fax = customer.Fax
                });

                return responseInsert;
            }
        }

        public int UpdateCustomer(CustomerModel customer)
        {
            using (SqlConnection connection = DatabaseConnection.GetSqlConnection())
            {
                string query = @"UPDATE Customers SET 
                                CompanyName = @companyName, 
                                ContactName = @contactName, 
                                ContactTitle = @contactTitle, 
                                Address = @address, 
                                City = @city, 
                                Region = @region, 
                                PostalCode = @postalCode, 
                                Country = @country, 
                                Phone = @phone, 
                                Fax = @fax
                                WHERE CustomerID = @customerId";

                int responseUpdate = connection.Execute(query, customer);
                return responseUpdate;
            }
        }
    }
}
