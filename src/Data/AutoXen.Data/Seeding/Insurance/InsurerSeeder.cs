namespace AutoXen.Data.Seeding.Insurance
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using AutoXen.Data.Models.Insurance;

    public class InsurerSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Insurers.Any())
            {
                return;
            }

            await dbContext.Insurers.AddAsync(new Insurer()
            {
                Name = "Guardian Assurance",
            });

            await dbContext.Insurers.AddAsync(new Insurer()
            {
                Name = "Insured For Life",
            });

            await dbContext.Insurers.AddAsync(new Insurer()
            {
                Name = "Consuma",
            });

            await dbContext.Insurers.AddAsync(new Insurer()
            {
                Name = "Insurita",
            });

            await dbContext.Insurers.AddAsync(new Insurer()
            {
                Name = "Inoda",
            });

            await dbContext.Insurers.AddAsync(new Insurer()
            {
                Name = "Zen Insurance",
            });

            await dbContext.Insurers.AddAsync(new Insurer()
            {
                Name = "SecureFox",
            });
        }
    }
}
