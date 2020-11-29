namespace AutoXen.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using AutoXen.Data.Models.Car;
    using AutoXen.Web.ViewModels;

    public interface ICarService
    {
        public Task AddCarAsync(string userId, DetailedCarWithIdViewModel model);

        public IEnumerable<CarViewModel> AllCars(string userId);

        public IEnumerable<ExtraViewModel> GetAllExtras();

        public DetailedCarWithIdViewModel GetCarDetails(string carId, string userId);

        public List<string> GetAllFuelTypes();

        public List<string> GetAllTransmissionTypes();

        public Task ChangeCarDetailsAsync(DetailedCarWithIdViewModel model, string userId);

        public Task Delete(string carId, string userId);

        /// <summary>
        /// <exception>Throws InvalidCarException.</exception>
        /// </summary>
        public void CheckUserHasCar(string userId, string carId);
    }
}
