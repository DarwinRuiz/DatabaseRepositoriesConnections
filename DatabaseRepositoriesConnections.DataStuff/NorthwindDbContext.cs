using DatabaseRepositoriesConnections.DataStuff.Models;
using Microsoft.EntityFrameworkCore;

namespace DatabaseRepositoriesConnections.DataStuff
{
    public class NorthwindDbContext: DbContext
    {
        public DbSet<CustomerModel> Customer { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder.UseSqlServer(@"Data Source=localhost,1400; Initial Catalog=NorthwindEF; Integrated Security=false;User ID=sa;Password=Dorm2024#;TrustServerCertificate=true;"));
        }
    }
}
