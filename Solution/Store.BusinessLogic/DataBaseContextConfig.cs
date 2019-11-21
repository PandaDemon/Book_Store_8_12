using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PrintStore.BusinessLogic.Helpers;
using PrintStore.BusinessLogic.Helpers.Interface;
using PrintStore.BusinessLogic.Services;
using PrintStore.BusinessLogic.Services.Interfaces;
using PrintStore.DataAccess.Entities;
using PrintStore.DataAccess.Initialization;
using PrintStore.DataAccess.Repositories.ConnectionStringProvider;
using PrintStore.DataAccess.Repositories.EFRepositories;
using PrintStore.DataAccess.Repositories.Interfaces;
using Store.DataAccess.Initialization;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Threading.Tasks;

namespace PrintStore.DataAccess
{

    public static class DataBaseContextConfig
    {
        public static void InjectDataBase(this IServiceCollection services, IConfiguration Сonfiguration)
        {
           //services.AddSingleton<IConnectionStringProvider, ConnectionStringProvider>();

            //services.AddIdentity<ApplicationUser, IdentityRole>(opts =>
            //{
            //    opts.Password.RequiredLength = 4;
            //    opts.Password.RequireNonAlphanumeric = false;
            //    opts.Password.RequireLowercase = false;
            //    opts.Password.RequireUppercase = false;
            //    opts.Password.RequireDigit = false;
            //})
            //    .AddEntityFrameworkStores<DataBaseContext>()
            //    .AddDefaultTokenProviders();

            services.AddScoped<RoleManager<IdentityRole>>();
            services.AddScoped<UserManager<ApplicationUser>>();
            services.AddTransient<DbInitializer>();
            services.AddTransient<JwtSecurityTokenHandler>();
            services.AddTransient<IJwtHelper, JwtHelper>();

            services.AddTransient<IPrintingEditionRepository, PrintingEditionRepository>();
            services.AddTransient<IAuthorRepository, AuthorRepository>();
            services.AddTransient<IAuthorInPrintingEditionRepository, AuthorInPrintingEditionRepository>();
            services.AddTransient<ICurrencyRepository, CurrencyRepository>();
            services.AddTransient<IOrderRepository, OrderRepository>();
            services.AddTransient<IPaymentRepository, PaymentRepository>();
            services.AddTransient<IPrintingEditionsInOrdersRepository, PrintingEditionsInOrdersRepository>();

            services.AddTransient<IAuthorRepository, Repositories.DapperRepositories.AuthorDapperRepository>();
            services.AddTransient<IAuthorInPrintingEditionRepository, Repositories.DapperRepositories.AuthorInPrintingEditionRepository>();
            services.AddTransient<ICurrencyRepository, Repositories.DapperRepositories.CurrencyRepository>();
            services.AddTransient<IOrderRepository, Repositories.DapperRepositories.OrderRepository>();
            services.AddTransient<IPaymentRepository, Repositories.DapperRepositories.PaymentRepository>();
            services.AddTransient<IPrintingEditionRepository, Repositories.DapperRepositories.PrintingEditionRepository>();

            services.AddTransient<IAuthorService, AuthorService>();
            services.AddTransient<IAdminService, AdminService>();
            services.AddTransient<IPrintingEditionService, PrintingEditionService>();
            services.AddTransient<IPrintStoreService, PrintStoreService>();
            services.AddTransient<IApplicationUserService, ApplicationUserService>();
            services.AddTransient<IOrderService, OrderService>();
            services.AddTransient<ICurrencyConverter, CurrencyConverter>();
        }

        public static async void UseDataBase(this IApplicationBuilder application, IServiceProvider serviceProvider)
        {
            DataBaseContext dataBaseContext = serviceProvider.GetRequiredService<DataBaseContext>();

            DbInitializer dataBaseInitialization = serviceProvider.GetRequiredService<DbInitializer>();

            var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();
            var rolesManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();

            await DbInitializer.InitializeAsync(userManager, rolesManager, dataBaseContext);

            //dataBaseInitialization.Initialize(dataBaseContext);
        }
    }
}


