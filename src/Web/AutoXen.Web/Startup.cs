namespace AutoXen.Web
{
    using System.Reflection;

    using AutoMapper;
    using AutoXen.Data;
    using AutoXen.Data.Common;
    using AutoXen.Data.Common.Repositories;
    using AutoXen.Data.Models;
    using AutoXen.Data.Repositories;
    using AutoXen.Data.Seeding;
    using AutoXen.Services.Data;
    using AutoXen.Services.Data.Administration;
    using AutoXen.Services.Mapping;
    using AutoXen.Services.Messaging;
    using AutoXen.Web.Hubs;
    using AutoXen.Web.Infrastructure.ModelBinders;
    using AutoXen.Web.Infrastructure.Profiles;
    using AutoXen.Web.ViewModels;

    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;

    public class Startup
    {
        private readonly IConfiguration configuration;

        public Startup(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(
                options => options.UseSqlServer(this.configuration.GetConnectionString("DefaultConnection")));

            services.AddDefaultIdentity<ApplicationUser>(IdentityOptionsProvider.GetIdentityOptions)
                .AddRoles<ApplicationRole>().AddEntityFrameworkStores<ApplicationDbContext>();

            services.Configure<CookiePolicyOptions>(
                options =>
                    {
                        options.CheckConsentNeeded = context => true;
                        options.MinimumSameSitePolicy = SameSiteMode.None;
                    });

            services.AddSignalR();
            services.AddControllersWithViews(
                options =>
                    {
                        options.Filters.Add(new AutoValidateAntiforgeryTokenAttribute());
                        options.ModelBinderProviders.Insert(0, new TrimModelBinderProvider());
                    }).AddRazorRuntimeCompilation();
            services.AddRazorPages();

            services.AddApplicationInsightsTelemetry();

            services.AddSingleton(this.configuration);

            services.AddAutoMapper(typeof(CarProfile));

            // Data repositories
            services.AddScoped(typeof(IDeletableEntityRepository<>), typeof(EfDeletableEntityRepository<>));
            services.AddScoped(typeof(IRepository<>), typeof(EfRepository<>));
            services.AddScoped<IDbQueryRunner, DbQueryRunner>();

            // Application services
            services.AddTransient<IEmailSender>(x => new SendGridEmailSender(this.configuration["SendGrid:ApiKey"]));
            services.AddTransient<ICarService, CarService>();
            services.AddTransient<ICarWashService, CarWashService>();
            services.AddTransient<IRequestsService, RequestsService>();
            services.AddTransient<IWorkshopService, AutoXen.Services.Data.WorkshopService>();
            services.AddTransient<IRequestsAdminService, RequestsAdminService>();
            services.AddTransient<IEmailService, EmailService>();
            services.AddTransient<IUsersService, UsersService>();
            services.AddTransient<IMessageService, MessageService>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // needed for Services.Mapping (custom mapping from the template)
            // AutoMapperConfig.RegisterMappings(typeof(ErrorViewModel).GetTypeInfo().Assembly);

            // Seed data on application startup
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                var dbContext = serviceScope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
                dbContext.Database.Migrate();
                new ApplicationDbContextSeeder().SeedAsync(dbContext, serviceScope.ServiceProvider).GetAwaiter().GetResult();
            }

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.Use(async (context, next) =>
            {
                await next();
                if (context.Response.StatusCode == 404)
                {
                    context.Request.Path = "/Home/Error404";
                    await next();
                }
            });

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(
                endpoints =>
                {
                    endpoints.MapHub<ChatHub>("/chat");
                    endpoints.MapControllerRoute("areaRoute", "{area:exists}/{controller=Home}/{action=Index}/{id?}");
                    endpoints.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");
                    endpoints.MapRazorPages();
                });
        }
    }
}
