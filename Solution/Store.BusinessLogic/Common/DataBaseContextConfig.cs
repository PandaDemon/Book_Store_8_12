using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Store.BusinessLogic.Services;
using Store.BusinessLogic.Services.Interfaces;
using Store.DataAccess.Entities;
using Store.DataAccess.Initialization;
using Store.DataAccess.Repositories.DrapperRepositories;
using Store.DataAccess.Repositories.Interfaces;
using System;

namespace Store.BusinessLogic.Common
{
    public static class DataBaseContextConfig
    {
        public static void InjectDataBase(this IServiceCollection services, IConfiguration Сonfiguration)
        {
            services.AddTransient<DataBaseInitialization>();
            services.AddTransient<IAuthor, DapperAuthorRepository>();
            services.AddTransient<IPrintingEdition, DapperPrintingEditionRepository>();
            services.AddTransient<IAuthorInPrintingEdition, DapperAuthorInPrintingEditionRepository>();

            services.AddTransient<IAuthorService, AuthorService>();
            services.AddTransient<IPrintingEditionService, PrintingEditionService>();
            services.AddTransient<IPrintStoreService, PrintStoreService>();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IPrintStoreService, PrintStoreService>();
        }
        public static async void UseDataBase(this IApplicationBuilder app, IServiceProvider serviceProvider)
        {
            DataBaseContext dataBaseContext = serviceProvider.GetRequiredService<DataBaseContext>();

            DataBaseInitialization dataBaseInitialization = serviceProvider.GetRequiredService<DataBaseInitialization>();

            var userManager = serviceProvider.GetRequiredService<UserManager<User>>();
            var rolesManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();

            await DataBaseInitialization.InitializeAsync(
                userManager, rolesManager);

            dataBaseInitialization.Initialize(dataBaseContext);
        }
    }
}
