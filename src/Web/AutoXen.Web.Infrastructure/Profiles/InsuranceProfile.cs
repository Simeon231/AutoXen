﻿namespace AutoXen.Web.Infrastructure.Profiles
{
    using AutoMapper;
    using AutoXen.Data.Models.Insurance;
    using AutoXen.Web.ViewModels.Insurance;

    public class InsuranceProfile : Profile
    {
        public InsuranceProfile()
        {
            this.CreateMap<InsurerInsurances, InsurerInsuranceViewModel>()
                .ReverseMap();

            this.CreateMap<Insurer, InsurerViewModel>()
                .ReverseMap();

            this.CreateMap<InsuranceRequest, InsuranceRequestViewModel>()
                .ReverseMap();
        }
    }
}
