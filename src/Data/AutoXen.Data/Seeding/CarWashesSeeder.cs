namespace AutoXen.Data.Seeding
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using AutoXen.Data.Models.CarWash;

    public class CarWashesSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.CarWashes.Any())
            {
                return;
            }

            await dbContext.CarWashes.AddAsync(new CarWash() { Name = "Bubble Time" });
            await dbContext.CarWashes.AddAsync(new CarWash() { Name = "Wash Factory" });
            await dbContext.CarWashes.AddAsync(new CarWash() { Name = "Happy Car Wash" });
            await dbContext.CarWashes.AddAsync(new CarWash() { Name = "Blue Wave" });
            await dbContext.CarWashes.AddAsync(new CarWash() { Name = "AutoSpa" });
            await dbContext.CarWashes.AddAsync(new CarWash() { Name = "Auto Shine" });
            await dbContext.CarWashes.AddAsync(new CarWash() { Name = "Waterway Gas & Wash" });
        }
    }
}
