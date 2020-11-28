namespace AutoXen.Web.Infrastructure.Profiles
{
    using AutoMapper;
    using AutoXen.Data.Models.CarWash;
    using AutoXen.Data.Models.Workshop;
    using AutoXen.Web.ViewModels.Requests;

    public class RequestsProfile : Profile
    {
        public RequestsProfile()
        {
            this.CreateMap<CarWashRequest, RequestViewModel>()
                .ForMember(x => x.RequestName, y => y.MapFrom(x => x.ToString()))
                .ReverseMap();

            this.CreateMap<WorkshopRequest, RequestViewModel>()
                .ForMember(x => x.RequestName, y => y.MapFrom(x => x.ToString()))
                .ReverseMap();
        }
    }
}
