namespace AutoXen.Services.Data.Administration
{
    using AutoXen.Web.ViewModels.Administration.User;

    public interface IUsersService
    {
        public UserDetailsViewModel GetUser(string userId);
    }
}
