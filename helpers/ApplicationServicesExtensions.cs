using Implementations;
using interfaces;
using Microsoft.EntityFrameworkCore;
using pfSOA.data;

namespace helpers;

    public static class ApplicationServicesExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration config)
        {

          var serverVersion = new MariaDbServerVersion(new Version(8, 0, 34));
          var connectionString = config.GetConnectionString("SQLConnection");
          services.AddDbContext<DataContext>(
            dbContextOptions => dbContextOptions
                .UseMySql(connectionString, serverVersion)
                // The following three options help with debugging, but should
                // be changed or removed for production.
                .LogTo(Console.WriteLine, LogLevel.Information)
                //.EnableSensitiveDataLogging()
                //.EnableDetailedErrors()
        );
                    
          services.AddScoped<IPhoto, Photo>();
          services.AddScoped<DataContext>();
           
           
            return services;
        }
    }
