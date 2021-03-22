namespace AutoXen.Web.Infrastructure.Profiles
{
    using AutoMapper;
    using AutoXen.Data.Models.Car;
    using AutoXen.Web.ViewModels.Cars;

    public class CarProfile : Profile
    {
        public CarProfile()
        {
            this.CreateMap<Car, CarViewModel>()
                .ReverseMap();

            this.CreateMap<Car, DetailedCarInputModel>()
                .ForMember(x => x.CarExtrasIds, opt => opt.Ignore());

            this.CreateMap<Car, DetailedCarViewModel>()
                .ReverseMap();

            this.CreateMap<DetailedCarInputModel, Car>()
                .ForMember(x => x.CarExtras, opt => opt.Ignore())
                .ForMember(x => x.Id, opt => opt.Ignore());
        }
    }
}
