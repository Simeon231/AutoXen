namespace AutoXen.Web.Infrastructure.Profiles
{
    using AutoMapper;
    using AutoXen.Data.Models.CarWash;
    using AutoXen.Data.Models.Insurance;
    using AutoXen.Data.Models.Workshop;
    using AutoXen.Web.ViewModels.Common.RequestInformation;
    using AutoXen.Web.ViewModels.Requests;

    public class RequestsProfile : Profile
    {
        public RequestsProfile()
        {
            this.CreateMap<CarWashRequest, RequestViewModel>()
                .ForMember(x => x.RequestName, y => y.MapFrom(x => x.ToString()))
                .ReverseMap();

            this.CreateMap<CarWashRequest, PickUpRequestInformationViewModel>()
                .ReverseMap();

            this.CreateMap<WorkshopRequest, RequestViewModel>()
                .ForMember(x => x.RequestName, y => y.MapFrom(x => x.ToString()))
                .ReverseMap();

            this.CreateMap<WorkshopRequest, PickUpRequestInformationViewModel>()
                .ReverseMap();

            this.CreateMap<InsuranceRequest, InsuranceRequestInformationViewModel>()
                .ReverseMap();

            this.CreateMap<InsuranceRequest, RequestViewModel>()
                .ForMember(x => x.RequestName, y => y.MapFrom(x => x.ToString()))
                .ReverseMap();

            this.CreateMap<RequestsViewModel, UserFilterViewModel>()
                .ReverseMap();
        }
    }
}
