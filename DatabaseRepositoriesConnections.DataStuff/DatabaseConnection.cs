using System.Data.SqlClient;

namespace DatabaseRepositoriesConnections.DataStuff
{
    public class DatabaseConnection
    {

        public static SqlConnection GetSqlConnection()
        {
            SqlConnectionStringBuilder sqlConnectionStringBuilder = new SqlConnectionStringBuilder();
            sqlConnectionStringBuilder.DataSource = "localhost,1400";
            sqlConnectionStringBuilder.TrustServerCertificate = false;
            sqlConnectionStringBuilder.IntegratedSecurity = false;
            sqlConnectionStringBuilder.InitialCatalog = "Northwind";
            sqlConnectionStringBuilder.UserID = "sa";
            sqlConnectionStringBuilder.Password = "Dorm2024#";

            //Other parameters accept
            //@"Data Source=localhost,1400; Initial Catalog=Northwind; Integrated Security=false;User ID=sa;Password=Dorm2024#;TrustServerCertificate=false;"
            SqlConnection sqlConnection = new SqlConnection(sqlConnectionStringBuilder.ConnectionString);

            sqlConnection.Open();
            return sqlConnection;
        }
    }
}
