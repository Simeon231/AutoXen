namespace AutoXen.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using AutoXen.Web.ViewModels.Cars;

    public interface ICarService
    {
        public Task AddCarAsync(string userId, DetailedCarInputModel model);

        public IEnumerable<CarViewModel> GetAllCarsByUserId(string userId);

        public IEnumerable<ExtraViewModel> GetAllExtras();

        public DetailedCarViewModel GetCarDetails(string carId, string userId);

        public List<string> GetAllFuelTypes();

        public List<string> GetAllTransmissionTypes();

        public Task ChangeCarDetailsAsync(DetailedCarInputModel model, string userId);

        public Task DeleteCarAsync(string carId, string userId);

        /// <summary>
        /// <exception>Throws InvalidCarException.</exception>
        /// </summary>
        public void CheckUserHaveACar(string userId, string carId);
    }
}
