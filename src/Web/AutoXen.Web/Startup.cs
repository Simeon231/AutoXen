namespace AutoXen.Web
{
    using System.Globalization;

    using AutoXen.Data;
    using AutoXen.Data.Common;
    using AutoXen.Data.Common.Repositories;
    using AutoXen.Data.Models;
    using AutoXen.Data.Repositories;
    using AutoXen.Data.Seeding;
    using AutoXen.Services;
    using AutoXen.Services.Data;
    using AutoXen.Services.Data.Administration;
    using AutoXen.Services.Messaging;
    using AutoXen.Web.Hubs;
    using AutoXen.Web.Infrastructure.ModelBinders;
    using AutoXen.Web.Infrastructure.Profiles;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Localization;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Razor;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;
    using Microsoft.Extensions.Options;

    public class Startup
    {
        private readonly IConfiguration configuration;
        private readonly IWebHostEnvironment env;

        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            this.configuration = configuration;
            this.env = env;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(
                options => options.UseSqlServer(this.configuration.GetConnectionString("DefaultConnection")));

            services.AddDefaultIdentity<ApplicationUser>(IdentityOptionsProvider.GetIdentityOptions)
                .AddRoles<ApplicationRole>().AddEntityFrameworkStores<ApplicationDbContext>()
                .AddErrorDescriber<MultilanguageIdentityErrorDescriber>();

            services.AddDatabaseDeveloperPageExceptionFilter();

            services.Configure<CookiePolicyOptions>(
                options =>
                    {
                        options.CheckConsentNeeded = context => true;
                        options.MinimumSameSitePolicy = SameSiteMode.None;
                    });

            if (this.env.IsDevelopment())
            {
                services.AddSignalR();
            }
            else
            {
                services.AddSignalR().AddAzureSignalR(this.configuration["SignalR:ConnectionString"]);
            }

            services.AddLocalization(options => options.ResourcesPath = "Resources");

            services.AddMvc();

            services.AddControllersWithViews(
                options =>
                    {
                        options.Filters.Add(new AutoValidateAntiforgeryTokenAttribute());
                        options.ModelBinderProviders.Insert(0, new TrimModelBinderProvider());
                    })
                .AddRazorRuntimeCompilation();

            services.AddRazorPages()
                .AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix)
                .AddDataAnnotationsLocalization();

            services.AddApplicationInsightsTelemetry();

            services.AddSingleton(this.configuration);

            services.AddAutoMapper(typeof(CarProfile));

            services.AddSingleton<ErrorMessageTranslationService>();

            // Data repositories
            services.AddScoped(typeof(IDeletableEntityRepository<>), typeof(EfDeletableEntityRepository<>));
            services.AddScoped(typeof(IRepository<>), typeof(EfRepository<>));
            services.AddScoped<IDbQueryRunner, DbQueryRunner>();

            // Application services
            services.AddTransient<IEmailSender>(x => new SendGridEmailSender(this.configuration["SendGrid:ApiKey"]));
            services.AddTransient<ICarService, CarService>();
            services.AddTransient<IRequestsService, RequestsService>();
            services.AddTransient<ICarWashService, CarWashService>();
            services.AddTransient<IWorkshopService, AutoXen.Services.Data.WorkshopService>();
            services.AddTransient<IInsuranceService, InsuranceService>();
            services.AddTransient<IRequestsAdminService, RequestsAdminService>();
            services.AddTransient<IEmailService, EmailService>();
            services.AddTransient<IUsersService, UsersService>();
            services.AddTransient<IMessageService, MessageService>();

            services.Configure<RequestLocalizationOptions>(options =>
            {
                var supportedCultures = new CultureInfo[]
                {
                    new CultureInfo("en-US"),
                    new CultureInfo("bg"),
                };

                options.DefaultRequestCulture = new RequestCulture(culture: "en-US", uiCulture: "en-US");

                options.SupportedCultures = supportedCultures;

                options.SupportedUICultures = supportedCultures;

                options.RequestCultureProviders = new[] { new CookieRequestCultureProvider() };
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            var locOptions = app.ApplicationServices.GetService<IOptions<RequestLocalizationOptions>>();
            app.UseRequestLocalization(locOptions.Value);

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
                app.UseMigrationsEndPoint();
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
