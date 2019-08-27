using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Store.BusinessLogic.Services;
using Store.BusinessLogic.Services.Implementations;
using Store.BusinessLogic.Services.Interfaces;
using Store.DataAccess.Initialization;

namespace Store.Presentation
{
    public class Startup
    {
        private IConfigurationRoot _confString;

        public Startup(IHostingEnvironment hostEnv)
        {
            _confString = new ConfigurationBuilder().SetBasePath(hostEnv.ContentRootPath).AddJsonFile("appsettings.json").Build();
        }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }



        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddDbContext<DataBaseContext>(options => options.UseSqlServer(_confString.GetConnectionString("DefaultConnection")));
            services.AddTransient<DataBaseContext>();

            services.AddTransient<IAuthor, EFAuthorRepository>();
            services.AddTransient<IPrintingEdition, EFPrintingEditionRepository>();
            services.AddTransient<ICategory, EFCategoryRepository>();
            services.AddScoped<DataManager>();

            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });


            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Account}/{action=Register}/{id?}");
            });


            //////
            using (var scope = app.ApplicationServices.CreateScope())
            {
                //DataBaseContext content = scope.ServiceProvider.GetRequiredService<DataBaseContext>();
                //DataBaseInitialization.Initialize(content);

                DataBaseContext applicationDataBaseContext = scope.ServiceProvider.GetRequiredService<DataBaseContext>();
                applicationDataBaseContext.Database.Migrate();

                //DataBaseInitialization applicationDataBaseInitializer = scope.ServiceProvider.GetRequiredService<DataBaseInitialization>();
                DataBaseInitialization.Initialize(applicationDataBaseContext);
            }


        }

    }
}
