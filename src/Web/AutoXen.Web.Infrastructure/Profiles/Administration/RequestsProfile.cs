namespace AutoXen.Web.Infrastructure.Profiles.Administration
{
    using AutoMapper;
    using AutoXen.Data.Models.CarWash;
    using AutoXen.Data.Models.Workshop;
    using AutoXen.Web.ViewModels.Administration.Common;
    using AutoXen.Web.ViewModels.Administration.Requests;

    public class RequestsProfile : Profile
    {
        public RequestsProfile()
        {
            this.CreateMap<WorkshopRequest, RequestViewModel>()
                .ForMember(x => x.RequestName, y => y.MapFrom(x => x.ToString()))
                .ReverseMap();

            this.CreateMap<WorkshopRequest, AdminRequestInformationViewModel>()
                .ReverseMap();

            this.CreateMap<CarWashRequest, RequestViewModel>()
                .ForMember(x => x.RequestName, y => y.MapFrom(x => x.ToString()))
                .ReverseMap();

            this.CreateMap<CarWashRequest, AdminRequestInformationViewModel>()
                .ReverseMap();

            this.CreateMap<RequestsViewModel, FilterViewModel>()
                .ReverseMap();
        }
    }
}
