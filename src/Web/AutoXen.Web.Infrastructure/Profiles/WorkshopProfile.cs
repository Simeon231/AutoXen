namespace AutoXen.Web.Infrastructure.Profiles
{
    using AutoMapper;
    using AutoXen.Data.Models.Workshop;
    using AutoXen.Web.ViewModels.Administration.Workshop;
    using AutoXen.Web.ViewModels.Common;
    using AutoXen.Web.ViewModels.Workshop;

    public class WorkshopProfile : Profile
    {
        public WorkshopProfile()
        {
            this.CreateMap<WorkshopService, WorkshopServiceViewModel>()
                .ReverseMap();

            this.CreateMap<Workshop, WorkshopViewModel>()
                .ReverseMap();

            this.CreateMap<WorkshopService, ServiceWithPriceResponseModel>()
                .ReverseMap();

            this.CreateMap<WService, ServiceResponseModel>()
                .ReverseMap();

            this.CreateMap<WorkshopRequest, WorkshopRequestViewModel>()
                .ReverseMap();

            this.CreateMap<WorkshopRequest, WorkshopRequestDetailsViewModel>()
                .ReverseMap();

            this.CreateMap<WService, WServiceViewModel>()
                .ReverseMap();

            this.CreateMap<WorkshopRequest, WorkshopAdminViewModel>()
                .ReverseMap();
        }
    }
}
