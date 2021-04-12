namespace AutoXen.Data.Seeding.Insurance
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    public class InsuranceSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Insurances.Any())
            {
                return;
            }

            await dbContext.Insurances.AddAsync(new Models.Insurance.Insurance()
            {
                Name = "Casco",
            });

            await dbContext.Insurances.AddAsync(new Models.Insurance.Insurance()
            {
                Name = "Third Party Liability",
            });

            await dbContext.Insurances.AddAsync(new Models.Insurance.Insurance()
            {
                Name = "Accident in places",
            });

            await dbContext.Insurances.AddAsync(new Models.Insurance.Insurance()
            {
                Name = "Car assistance for Bulgaria",
            });

            await dbContext.Insurances.AddAsync(new Models.Insurance.Insurance()
            {
                Name = "Car assistance for Europe",
            });

            await dbContext.Insurances.AddAsync(new Models.Insurance.Insurance()
            {
                Name = "Insurance of passengers in public transport",
            });
        }
    }
}
