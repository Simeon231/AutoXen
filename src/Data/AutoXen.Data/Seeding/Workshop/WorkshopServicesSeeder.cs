namespace AutoXen.Data.Seeding.Workshop
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using AutoXen.Data.Models.Workshop;

    public class WorkshopServicesSeeder : ISeeder
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
                var randomNumbers = this.RandomNumbers(servicesCount);

                foreach (var serviceId in randomNumbers)
                {
                    await dbContext.WorkshopServices.AddAsync(new WorkshopService()
                    {
                        ServiceId = serviceId,
                        WorkshopId = workshopId,
                        Price = this.RandomPrice(),
                    });
                }
            }
        }

        private IEnumerable<int> RandomNumbers(int maxNumber)
        {
            var nums = new HashSet<int>();

            for (int i = 0; i < maxNumber; i++)
            {
                nums.Add(new Random().Next(1, maxNumber));
            }

            return nums;
        }

        private double RandomPrice()
        {
            var maxPrice = 100.0;

            return new Random().NextDouble() * maxPrice;
        }
    }
}
