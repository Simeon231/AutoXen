namespace AutoXen.Services.Data.Administration
{
    using System.Text;
    using System.Threading.Tasks;

    using AutoXen.Common;
    using AutoXen.Services.Messaging;
    using AutoXen.Web.ViewModels.Administration.Email;

    public class EmailService : IEmailService
    {
        private readonly IEmailSender emailSender;
        private readonly IWorkshopService workshopService;
        private readonly string email = "s.auto.xen@gmail.com";

        public EmailService(
            IEmailSender emailSender,
            IWorkshopService workshopService)
        {
            this.emailSender = emailSender;
            this.workshopService = workshopService;
        }

        public async Task SendAsync(EmailViewModel model)
        {
            var workshopRequest = this.workshopService.GetWorkshopRequestDetails(null, model.RequestId, true);

            var html = new StringBuilder();
            html.AppendLine($"<h1>{model.RequestName}</h1>");
            html.AppendLine($"{model.Message}");
            html.AppendLine($"<ul>");
            html.AppendLine($"<li>task 1</li>");
            html.AppendLine($"<li>task 2</li>");
            html.AppendLine($"</ul>");
            await this.emailSender.SendEmailAsync(this.email, GlobalConstants.SystemName, model.Receiver, model.Subject, html.ToString());
        }

        private void AppendUl(StringBuilder html)
        {

        }
    }
}
