namespace AutoXen.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using AutoXen.Web.ViewModels.Cars;

    public interface ICarService
    {
        public Task AddCarAsync(string userId, DetailedCarViewModel model);

        public IEnumerable<CarViewModel> AllCars(string userId);

        public IEnumerable<ExtraViewModel> GetAllExtras();

        public DetailedCarViewModel GetCarDetails(string carId, string userId);

        public List<string> GetAllFuelTypes();

        public List<string> GetAllTransmissionTypes();

        public Task ChangeCarDetailsAsync(DetailedCarViewModel model, string userId);

        public Task Delete(string carId, string userId);

        /// <summary>
        /// <exception>Throws InvalidCarException.</exception>
        /// </summary>
        public void CheckUserHasCar(string userId, string carId);
    }
}
