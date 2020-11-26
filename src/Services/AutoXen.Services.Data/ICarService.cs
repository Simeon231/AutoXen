namespace AutoXen.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using AutoXen.Web.ViewModels;

    public interface ICarService
    {
        public Task AddCarAsync(string userId, DetailedCarWithoutIdViewModel model);

        public IEnumerable<CarViewModel> AllCars(string userId);

        public IEnumerable<ExtraViewModel> GetAllExtras();

        public DetailedCarWithoutIdViewModel GetCarDetails(string carId);

        public List<string> GetAllFuelTypes();

        public List<string> GetAllTransmissionTypes();

        public Task ChangeCarDetailsAsync(DetailedCarWithIdViewModel model);

        public Task Delete(string carId);
    }
}
