namespace AutoXen.Web.Infrastructure.Profiles.Administration
{
    using AutoMapper;
    using AutoXen.Data.Models;
    using AutoXen.Web.ViewModels.Administration.User;

    public class UserProfile : Profile
    {
        public UserProfile()
        {
            this.CreateMap<ApplicationUser, UserDetailsViewModel>()
                .ReverseMap();
        }
    }
}
