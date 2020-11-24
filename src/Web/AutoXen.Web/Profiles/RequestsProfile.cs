namespace AutoXen.Web.Profiles
{
    using AutoMapper;
    using AutoXen.Data.Models.CarWash;
    using AutoXen.Web.ViewModels.Requests;

    public class RequestsProfile : Profile
    {
        public RequestsProfile()
        {
            this.CreateMap<CarWashRequest, RequestViewModel>()
                .ReverseMap();
        }
    }
}
