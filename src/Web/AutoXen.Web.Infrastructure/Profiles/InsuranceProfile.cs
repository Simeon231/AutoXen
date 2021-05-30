namespace AutoXen.Web.Infrastructure.Profiles
{
    using System.Linq;

    using AutoMapper;
    using AutoXen.Data.Models.Insurance;
    using AutoXen.Web.ViewModels.Insurance;

    public class InsuranceProfile : Profile
    {
        public InsuranceProfile()
        {
            this.CreateMap<InsurerInsurance, InsurerInsuranceViewModel>()
                .ReverseMap();

            this.CreateMap<Insurer, InsurerViewModel>()
                .ReverseMap();

            this.CreateMap<InsuranceRequest, InsuranceRequestViewModel>()
                .ReverseMap();

            this.CreateMap<InsuranceRequest, InsuranceRequestDetailsViewModel>()
                .ForMember(src => src.RequestInformation, opt => opt.MapFrom(dest => dest))
                .ForMember(src => src.InsurerInsurances, opt => opt.MapFrom(dest => dest.InsuranceRequestsInsurerInsurances.Select(x => x.InsurerInsurance)))
                .ReverseMap();
        }
    }
}
