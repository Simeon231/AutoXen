namespace AutoXen.Web.Infrastructure.Profiles
{
    using AutoMapper;
    using AutoXen.Data.Models.CarWash;
    using AutoXen.Web.ViewModels.Administration.CarWash;
    using AutoXen.Web.ViewModels.CarWash;

    public class CarWashProfile : Profile
    {
        public CarWashProfile()
        {
            this.CreateMap<CarWashRequest, CarWashRequestViewModel>()
                .ReverseMap();

            this.CreateMap<CarWashRequest, CarWashRequestDetailsViewModel>()
                .ForMember(x => x.RequestInformation, scr => scr.MapFrom(dest => dest))
                .ReverseMap();

            this.CreateMap<CarWashRequest, AdminCarWashDetailsViewModel>()
                .ForMember(x => x.RequestInformation, scr => scr.MapFrom(dest => dest))
                .ReverseMap();
        }
    }
}
