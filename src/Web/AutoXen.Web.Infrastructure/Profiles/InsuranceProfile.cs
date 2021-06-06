namespace AutoXen.Web.Infrastructure.Profiles
{
    using AutoMapper;
    using AutoXen.Data.Models.Insurance;
    using AutoXen.Web.ViewModels.Administration.Insurance;
    using AutoXen.Web.ViewModels.Insurance;

    public class InsuranceProfile : Profile
    {
        public InsuranceProfile()
        {
            this.CreateMap<InsurerInsurance, InsuranceViewModel>()
                .ReverseMap();

            this.CreateMap<Insurer, InsurerViewModel>()
                .ReverseMap();

            this.CreateMap<InsuranceRequest, InsuranceRequestViewModel>()
                .ReverseMap();

            this.CreateMap<InsuranceRequest, InsuranceRequestDetailsViewModel>()
                .ForMember(src => src.RequestInformation, opt => opt.MapFrom(dest => dest))
                .ReverseMap();

            this.CreateMap<InsuranceRequest, AdminInsuranceRequestViewModel>()
                .ForMember(src => src.RequestInformation, opt => opt.MapFrom(dest => dest))
                .ReverseMap();
        }
    }
}
