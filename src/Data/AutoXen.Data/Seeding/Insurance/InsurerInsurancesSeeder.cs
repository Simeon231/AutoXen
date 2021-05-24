namespace AutoXen.Data.Seeding.Insurance
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using AutoXen.Data.Models.Insurance;
    using AutoXen.Services;

    public class InsurerInsurancesSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.InsurerInsurances.Any())
            {
                return;
            }

            var insurerIds = dbContext.Insurers.Select(x => x.Id).ToList();
            var insuranceIds = dbContext.Insurances.Select(x => x.Id).ToList();

            foreach (var insurerId in insurerIds)
            {
                foreach (var insuranceId in insuranceIds)
                {
                    await dbContext.InsurerInsurances.AddAsync(new InsurerInsurances()
                    {
                        InsurerId = insurerId,
                        InsuranceId = insuranceId,
                        Price = RandomValues.RandomPrice(200),
                    });
                }
            }
        }
    }
}
