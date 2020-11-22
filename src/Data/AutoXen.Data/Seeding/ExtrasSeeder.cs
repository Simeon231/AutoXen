namespace AutoXen.Data.Seeding
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using AutoXen.Data.Models.Car;

    internal class ExtrasSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Extras.Any())
            {
                return;
            }

            await dbContext.Extras.AddAsync(new Extra() { Name = "2/3 Doors" });
            await dbContext.Extras.AddAsync(new Extra() { Name = "4/5 Doors" });
            await dbContext.Extras.AddAsync(new Extra() { Name = "4x4" });
            await dbContext.Extras.AddAsync(new Extra() { Name = "Airbag" });
            await dbContext.Extras.AddAsync(new Extra() { Name = "Electric windows" });
            await dbContext.Extras.AddAsync(new Extra() { Name = "Metallic" });
            await dbContext.Extras.AddAsync(new Extra() { Name = "Leather interior" });
            await dbContext.Extras.AddAsync(new Extra() { Name = "Gas system" });
            await dbContext.Extras.AddAsync(new Extra() { Name = "Аir conditioning" });
            await dbContext.Extras.AddAsync(new Extra() { Name = "Climatronic" });
            await dbContext.Extras.AddAsync(new Extra() { Name = "Аuto pilot" });
            await dbContext.Extras.AddAsync(new Extra() { Name = "Parktronic" });
            await dbContext.Extras.AddAsync(new Extra() { Name = "Мethane system" });
            await dbContext.Extras.AddAsync(new Extra() { Name = "Navigation" });
            await dbContext.Extras.AddAsync(new Extra() { Name = "Еlectric mirrors" });
        }
    }
}
