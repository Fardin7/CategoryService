using CategoryService.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
namespace CategoryService
{
    public class DesignTimeDBContextFactory : IDesignTimeDbContextFactory<AppDBContext>
    {
        public AppDBContext CreateDbContext(string[] args)
        {
            var connectionString = "Data Source=.;Initial Catalog=Category;Integrated Security=True;User ID=sa,Password=fardin!";
            var builder = new DbContextOptionsBuilder<AppDBContext>();

            builder.UseSqlServer(connectionString);
            return new AppDBContext(builder.Options);
        }
    }
}
