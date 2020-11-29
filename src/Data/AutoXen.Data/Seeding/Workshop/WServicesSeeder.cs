namespace AutoXen.Data.Seeding.Workshop
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using AutoXen.Data.Models.Workshop;

    internal class WServicesSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.WServices.Any())
            {
                return;
            }

            await dbContext.WServices.AddAsync(new WService()
            {
                Name = "Tire change",
            });

            await dbContext.WServices.AddAsync(new WService()
            {
                Name = "Oil change",
            });

            await dbContext.WServices.AddAsync(new WService()
            {
                Name = "Replacement steering gear",
            });

            await dbContext.WServices.AddAsync(new WService()
            {
                Name = "Water pump replacement",
            });

            await dbContext.WServices.AddAsync(new WService()
            {
                Name = "Changing the drive shaft",
            });

            await dbContext.WServices.AddAsync(new WService()
            {
                Name = "Deaeration",
            });

            await dbContext.WServices.AddAsync(new WService()
            {
                Name = "Replacing the headlight bulb",
            });

            await dbContext.WServices.AddAsync(new WService()
            {
                Name = "Wiper repair",
            });

            await dbContext.WServices.AddAsync(new WService()
            {
                Name = "Repair of electric glass",
            });

            await dbContext.WServices.AddAsync(new WService()
            {
                Name = "Brake disc replacement",
            });

            await dbContext.WServices.AddAsync(new WService()
            {
                Name = "Rear brake pads replacement",
            });
        }
    }
}
