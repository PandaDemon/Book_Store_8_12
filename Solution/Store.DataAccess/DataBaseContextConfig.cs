
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PrintStore.DataAccess.Initialization;
using System;

namespace PrintStore.DataAccess
{

    public static class DataBaseContextConfig
    {
        public static void InjectDataBase(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<DbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            services.AddTransient<DbInitializer>();
        }
        public static void UseDataBase(this IApplicationBuilder app, IServiceProvider serviceProvider)
        {

            DbContext applicationDbContext = serviceProvider.GetRequiredService<DbContext>();
            applicationDbContext.Database.Migrate();

            DbInitializer applicationDbInitializer = serviceProvider.GetRequiredService<DbInitializer>();
            //applicationDbInitializer.Initialize().Wait();
        }
        

    }

        
        }
    

  