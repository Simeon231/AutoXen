namespace AutoXen.Web.Infrastructure.Profiles
{
    using AutoMapper;
    using AutoXen.Data.Models.CarWash;
    using AutoXen.Web.ViewModels.CarWash;

    public class CarWashRequestProfile : Profile
    {
        public CarWashRequestProfile()
        {
            this.CreateMap<CarWashRequest, CarWashRequestViewModel>()
                .ReverseMap();
        }
    }
}
