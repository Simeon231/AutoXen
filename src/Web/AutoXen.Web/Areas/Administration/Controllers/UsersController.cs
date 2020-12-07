namespace AutoXen.Web.Areas.Administration.Controllers
{
    using AutoXen.Services.Data.Administration;
    using Microsoft.AspNetCore.Mvc;

    public class UsersController : AdministrationController
    {
        private readonly IUsersService usersService;

        public UsersController(IUsersService usersService)
        {
            this.usersService = usersService;
        }

        public IActionResult Profile(string userId)
        {
            var model = this.usersService.GetUser(userId);

            return this.View(model);
        }
    }
}
