namespace AutoXen.Profiles
{
    using AutoMapper;
    using AutoXen.Data.Models.Car;
    using AutoXen.Web.ViewModels;

    public class CarProfile : Profile
    {
        public CarProfile()
        {
            this.CreateMap<Car, CarViewModel>()
                .ReverseMap();

            this.CreateMap<DetailedCarWithoutIdViewModel, Car>()
                .ForMember(x => x.CarExtras, opt => opt.Ignore())
                .ReverseMap();

            this.CreateMap<DetailedCarWithIdViewModel, Car>()
                .ForMember(x => x.CarExtras, opt => opt.Ignore())
                .ReverseMap();
        }
    }
}
