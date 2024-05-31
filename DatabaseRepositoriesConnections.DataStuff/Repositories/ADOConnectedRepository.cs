using DatabaseRepositoriesConnections.DataStuff.Models;
using System.Data.SqlClient;
using System.Diagnostics;

namespace DatabaseRepositoriesConnections.DataStuff.Repositories
{
    public class ADOConnectedRepository : IRepository
    {
        public int DeleteCustomer(string id)
        {
            using (SqlConnection connection = DatabaseConnection.GetSqlConnection())
            {
                string query = @"DELETE FROM Customer WHERE customerID = @customerId;";
                SqlCommand sqlCommand = new SqlCommand(query, connection);
                sqlCommand.Parameters.AddWithValue("CustomerID", id);
                int resultDetelete = sqlCommand.ExecuteNonQuery();

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
                    ";

                using (SqlCommand sqlCommand = new SqlCommand(query, connection))
                {

                    sqlCommand.Parameters.AddWithValue("customerID", id);
                    SqlDataReader reader = sqlCommand.ExecuteReader();
                    CustomerModel model = new CustomerModel();
                    if (reader.Read())
                    {
                        model = this.ReadFromDataReader(reader);
                    }

                    return model;
                }
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

                SqlCommand sqlCommand = new SqlCommand(query, connection);
                SqlDataReader reader = sqlCommand.ExecuteReader();

                Debug.WriteLine("Connection Opened");

                List<CustomerModel> customers = new List<CustomerModel>();

                while (reader.Read())
                {
                    CustomerModel customer = this.ReadFromDataReader(reader);
                    customers.Add(customer);
                }

                return customers;
            }
        }

        public int InsertCustomer(CustomerModel customer)
        {
            using (SqlConnection connection = DatabaseConnection.GetSqlConnection())
            {
                string query = @"INSERT INTO Customers (CustomerID, CompanyName, ContactName, ContactTitle, Address, City, Region, PostalCode, Country, Phone, Fax) 
                                VALUES (@customerID, @companyName, @contactName, @contactTitle, @address, @city, @region, @postalCode, @country, @phone, @fax)";

                SqlCommand sqlCommand = new SqlCommand(query, connection);
                sqlCommand.Parameters.AddWithValue("@customerID", customer.CustomerID);
                sqlCommand.Parameters.AddWithValue("@companyName", customer.CompanyName);
                sqlCommand.Parameters.AddWithValue("@contactName", customer.ContactName);
                sqlCommand.Parameters.AddWithValue("@contactTitle", customer.ContactTitle);
                sqlCommand.Parameters.AddWithValue("@address", customer.Address);
                sqlCommand.Parameters.AddWithValue("@city", customer.City);
                sqlCommand.Parameters.AddWithValue("@region", customer.Region);
                sqlCommand.Parameters.AddWithValue("@postalCode", customer.PostalCode);
                sqlCommand.Parameters.AddWithValue("@country", customer.Country);
                sqlCommand.Parameters.AddWithValue("@phone", customer.Phone);
                sqlCommand.Parameters.AddWithValue("@fax", customer.Phone);

                int responseInsert = sqlCommand.ExecuteNonQuery();
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

                SqlCommand sqlCommand = new SqlCommand(query, connection);
                sqlCommand.Parameters.AddWithValue("@companyName", customer.CompanyName);
                sqlCommand.Parameters.AddWithValue("@contactName", customer.ContactName);
                sqlCommand.Parameters.AddWithValue("@contactTitle", customer.ContactTitle);
                sqlCommand.Parameters.AddWithValue("@address", customer.Address);
                sqlCommand.Parameters.AddWithValue("@city", customer.City);
                sqlCommand.Parameters.AddWithValue("@region", customer.Region);
                sqlCommand.Parameters.AddWithValue("@postalCode", customer.PostalCode);
                sqlCommand.Parameters.AddWithValue("@country", customer.Country);
                sqlCommand.Parameters.AddWithValue("@phone", customer.Phone);
                sqlCommand.Parameters.AddWithValue("@fax", customer.Phone);
                sqlCommand.Parameters.AddWithValue("@customerId", customer.CustomerID);

                int responseUpdate = sqlCommand.ExecuteNonQuery();
                return responseUpdate;
            }
        }



        private CustomerModel ReadFromDataReader(SqlDataReader reader)
        {
            CustomerModel customer = new CustomerModel();

            customer.CustomerID = (string)reader["CustomerID"];
            customer.CompanyName = (string)reader["CompanyName"];
            customer.ContactName = reader["ContactName"] == DBNull.Value ? "" : (string)reader["ContactName"];
            customer.ContactTitle = reader["ContactTitle"] == DBNull.Value ? "" : (string)reader["ContactTitle"];
            customer.Address = reader["Address"] == DBNull.Value ? "" : (string)reader["Address"];
            customer.City = reader["City"] == DBNull.Value ? "" : (string)reader["City"];
            customer.Region = reader["Region"] == DBNull.Value ? "" : (string)reader["Region"];
            customer.PostalCode = reader["PostalCode"] == DBNull.Value ? "" : (string)reader["PostalCode"];
            customer.Country = reader["Country"] == DBNull.Value ? "" : (string)reader["Country"];
            customer.Phone = reader["Phone"] == DBNull.Value ? "" : (string)reader["Phone"];
            customer.Fax = reader["Fax"] == DBNull.Value ? "" : (string)reader["Fax"];

            return customer;
        }
    }
}
