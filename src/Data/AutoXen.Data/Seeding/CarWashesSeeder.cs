namespace AutoXen.Data.Seeding
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using AutoXen.Data.Models.CarWash;
    using AutoXen.Services;

    internal class CarWashesSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.CarWashes.Any())
            {
                return;
            }

            await dbContext.CarWashes.AddAsync(new CarWash()
            {
                Name = "Bubble Time", 
                Price = RandomValues.RandomPrice(),
            });
            await dbContext.CarWashes.AddAsync(new CarWash()
            {
                Name = "Wash Factory",
                Price = RandomValues.RandomPrice(),
            });
            await dbContext.CarWashes.AddAsync(new CarWash()
            {
                Name = "Happy Car Wash",
                Price = RandomValues.RandomPrice(),
            });
            await dbContext.CarWashes.AddAsync(new CarWash()
            {
                Name = "Blue Wave",
                Price = RandomValues.RandomPrice(),
            });
            await dbContext.CarWashes.AddAsync(new CarWash()
            {
                Name = "AutoSpa",
                Price = RandomValues.RandomPrice(),
            });
            await dbContext.CarWashes.AddAsync(new CarWash()
            {
                Name = "Auto Shine",
                Price = RandomValues.RandomPrice(),
            });
            await dbContext.CarWashes.AddAsync(new CarWash()
            {
                Name = "Waterway Gas & Wash",
                Price = RandomValues.RandomPrice(),
            });
        }
    }
}
