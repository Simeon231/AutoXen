namespace AutoXen.Services.Data.Administration
{
    using System.Linq;

    using AutoMapper;
    using AutoXen.Data.Common.Repositories;
    using AutoXen.Data.Models;
    using AutoXen.Web.ViewModels.Administration.User;

    public class UsersService : IUsersService
    {
        private readonly IDeletableEntityRepository<ApplicationUser> usersRepository;
        private readonly IMapper mapper;

        public UsersService(
            IDeletableEntityRepository<ApplicationUser> usersRepository,
            IMapper mapper)
        {
            this.usersRepository = usersRepository;
            this.mapper = mapper;
        }

        public UserDetailsViewModel GetUser(string userId)
        {
            var dbUser = this.usersRepository.AllAsNoTracking().FirstOrDefault(x => x.Id == userId);
            var user = this.mapper.Map<UserDetailsViewModel>(dbUser);

            return user;
        }
    }
}
