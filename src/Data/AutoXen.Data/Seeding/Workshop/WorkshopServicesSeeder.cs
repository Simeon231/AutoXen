namespace AutoXen.Data.Seeding.Workshop
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using AutoXen.Data.Models.Workshop;
    using AutoXen.Services;

    internal class WorkshopServicesSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.WorkshopServices.Any())
            {
                return;
            }

            await this.SeedRandomWorkshopServicesAsync(dbContext);
        }

        private async Task SeedRandomWorkshopServicesAsync(ApplicationDbContext dbContext)
        {
            var worhshopsCount = dbContext.Workshops.Count();
            var servicesCount = dbContext.WServices.Count();

            for (int workshopId = 1; workshopId <= worhshopsCount; workshopId++)
            {
                var randomNumbers = RandomValues.RandomUniqueNumbers(servicesCount, servicesCount);

                foreach (var serviceId in randomNumbers)
                {
                    await dbContext.WorkshopServices.AddAsync(new WorkshopService()
                    {
                        ServiceId = serviceId,
                        WorkshopId = workshopId,
                        Price = RandomValues.RandomPrice(),
                    });
                }
            }
        }
    }
}
