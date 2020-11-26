namespace AutoXen.Web.Profiles
{
    using AutoMapper;
    using AutoXen.Data.Models.Workshop;
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

            this.CreateMap<WService, ServiceModel>()
                .ReverseMap();
        }
    }
}
