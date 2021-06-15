namespace AutoXen.Web.Areas.Administration.Controllers
{
    using System.Security.Claims;
    using System.Threading.Tasks;

    using AutoXen.Services.Data.Administration;
    using AutoXen.Services.Exceptions;
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
                Id = id,
                RequestName = requestName,
            };

            return this.View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Send(EmailViewModel input)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(input);
            }

            try
            {
                input.AdminId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
                await this.emailService.SendAsync(input);
            }
            catch (InvalidRequestException exception)
            {
                this.ModelState.AddModelError("InvalidRequestException", exception.Message);

                return this.View(input);
            }

            return this.RedirectToAction("Index", "Requests");
        }
    }
}
