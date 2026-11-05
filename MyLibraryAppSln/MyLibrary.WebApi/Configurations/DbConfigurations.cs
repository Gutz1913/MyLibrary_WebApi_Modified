using Microsoft.EntityFrameworkCore;
using MyLibrary.WebApi.Models;

namespace MyVaccine.WebApi.Configurations;

public static class DbConfigurations
{
    public static IServiceCollection SetDatabaseConfiguration(this IServiceCollection services, IConfiguration configuration)
    {
        //var connectionString = Environment.GetEnvironmentVariable(MyVaccineLiterals.CONNECTION_STRING);
        //var connectionString = "Server=localhost;Database=MyVaccineAppDb;User Id=sa;Password=abc123;TrustServerCertificate=True;";
        services.AddDbContext<MyLibraryAppDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
        return services;
    }
}