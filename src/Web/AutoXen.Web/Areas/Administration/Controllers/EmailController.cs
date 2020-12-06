namespace AutoXen.Web.Areas.Administration.Controllers
{
    using System.Security.Claims;
    using System.Threading.Tasks;

    using AutoXen.Services.Data.Administration;
    using AutoXen.Web.ViewModels.Administration.Email;
    using Microsoft.AspNetCore.Mvc;

    public class EmailController : AdministrationController
    {
        private readonly IEmailService emailService;

        public EmailController(IEmailService emailService)
        {
            this.emailService = emailService;
        }

        public IActionResult Send(string requestName, string id)
        {
            var model = new EmailViewModel()
            {
                RequestId = id,
                RequestName = requestName,
            };

            return this.View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Send(EmailViewModel input)
        {
            input.AdminId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);

            await this.emailService.SendAsync(input);

            return this.RedirectToAction("Index", "Requests");
        }
    }
}
