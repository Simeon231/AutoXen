namespace AutoXen.Web.Infrastructure.Profiles.Administration
{
    using AutoMapper;
    using AutoXen.Data.Models.CarWash;
    using AutoXen.Data.Models.Insurance;
    using AutoXen.Data.Models.Workshop;
    using AutoXen.Web.ViewModels.Administration.Requests;
    using AutoXen.Web.ViewModels.Common.RequestInformation;

    public class RequestsProfile : Profile
    {
        public RequestsProfile()
        {
            this.CreateMap<WorkshopRequest, RequestViewModel>()
                .ForMember(x => x.RequestName, y => y.MapFrom(x => x.ToString()))
                .ForMember(x => x.Finished, y => y.MapFrom(x => x.FinishedOn != null))
                .ReverseMap();

            this.CreateMap<WorkshopRequest, PickUpRequestInformationViewModel>()
                .ReverseMap();

            this.CreateMap<CarWashRequest, RequestViewModel>()
                .ForMember(x => x.RequestName, y => y.MapFrom(x => x.ToString()))
                .ForMember(x => x.Finished, y => y.MapFrom(x => x.FinishedOn != null))
                .ReverseMap();

            this.CreateMap<CarWashRequest, PickUpRequestInformationViewModel>()
                .ReverseMap();

            this.CreateMap<RequestsViewModel, AdminFilterViewModel>()
                .ReverseMap();

            this.CreateMap<InsuranceRequest, InsuranceRequestInformationViewModel>()
                .ReverseMap();

            this.CreateMap<InsuranceRequest, RequestViewModel>()
                .ForMember(x => x.RequestName, y => y.MapFrom(x => x.ToString()))
                .ForMember(x => x.Finished, y => y.MapFrom(x => x.FinishedOn != null))
                .ReverseMap();
        }
    }
}
