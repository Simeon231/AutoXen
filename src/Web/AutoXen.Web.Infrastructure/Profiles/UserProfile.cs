namespace AutoXen.Web.Infrastructure.Profiles
{
    using AutoMapper;
    using AutoXen.Data.Models;
    using AutoXen.Web.ViewModels.User;

    public class UserProfile : Profile
    {
        public UserProfile()
        {
            this.CreateMap<ApplicationUser, UserViewModel>()
                .ReverseMap();
        }
    }
}
