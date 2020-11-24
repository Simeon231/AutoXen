namespace AutoXen.Data.Seeding.Workshop
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using AutoXen.Data.Models.Workshop;

    public class WorkshopSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Workshops.Any())
            {
                return;
            }

            await dbContext.Workshops.AddAsync(new Workshop()
            {
                Name = "Fix thy Car",
                Address = "Blagoevgrad, Simitli, 963 Sydney Curve",
            });

            await dbContext.Workshops.AddAsync(new Workshop()
            {
                Name = "Super Quick Fix",
                Address = "Plovdiv, Brezovo, Rozovets, 105 Goodwin Knoll",
            });

            await dbContext.Workshops.AddAsync(new Workshop()
            {
                Name = "Next-Gen Automotive",
                Address = "Sofia, Samokov, 9329 Reinger Forest",
            });

            await dbContext.Workshops.AddAsync(new Workshop()
            {
                Name = "Allen’s Automobiles",
                Address = "Sofia, Ihtiman, 39, 801",
            });

            await dbContext.Workshops.AddAsync(new Workshop()
            {
                Name = "Car Surgeons",
                Address = "Dobrich, Dobrichka, Medovo, 58, 21072",
            });

            await dbContext.Workshops.AddAsync(new Workshop()
            {
                Name = "Fine Crew",
                Address = "Pazardzhik, Lesichovo, Pamidovo, 6855 Sigurd Shores",
            });

            await dbContext.Workshops.AddAsync(new Workshop()
            {
                Name = "Gold Crown",
                Address = "Montana, 26, bul. Parta",
            });

            await dbContext.Workshops.AddAsync(new Workshop()
            {
                Name = "Midas International",
                Address = "Pernik, Tran, Miloslavtsi, 9966 Zaria Shore",
            });
        }
    }
}
