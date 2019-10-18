﻿using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Store.BusinessLogic.Common.Interfaces;
using Store.BusinessLogic.Mapper;
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
            services.AddTransient<IAuthorRepository, AuthorDapperRepository>();
            services.AddTransient<IPrintingEditionRepository, PrintingEditionDapperRepository>();
            services.AddTransient<IAuthorInPrintingEditionRepository, AuthorInPrintingEditionDapperRepository>();
			services.AddTransient<IBaseRepository<PrintingEdition>, PrintingEditionDapperRepository>();

            services.AddTransient<IAuthorService, AuthorService>();
            services.AddTransient<IPrintingEditionService, PrintingEditionService>();
            services.AddTransient<IPrintStoreService, PrintStoreService>();
            services.AddTransient<IUserService, UserService>();

			services.AddTransient<IAccountService, AccountService>();
			services.AddTransient<IEmailSender, EmailSender>();

			IMapper mapper = new MapperConfiguration(config =>
            {
                config.AddProfile(new AuthorMapperProfile());
				config.AddProfile(new PrintingEditionMapperProfile());
				config.AddProfile(new UserMapperProfile());
			}).CreateMapper();

            services.AddSingleton(mapper);
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
