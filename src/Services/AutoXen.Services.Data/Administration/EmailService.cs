namespace AutoXen.Services.Data.Administration
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using AutoXen.Common;
    using AutoXen.Services.Messaging;
    using AutoXen.Web.ViewModels.Administration.Email;
    using AutoXen.Web.ViewModels.Common;

    public class EmailService : IEmailService
    {
        private readonly IEmailSender emailSender;
        private readonly IWorkshopService workshopService;
        private readonly IUsersService usersService;
        private readonly string email = "s.auto.xen@gmail.com";

        public EmailService(
            IEmailSender emailSender,
            IWorkshopService workshopService,
            IUsersService usersService)
        {
            this.emailSender = emailSender;
            this.workshopService = workshopService;
            this.usersService = usersService;
        }

        public async Task SendAsync(EmailViewModel model)
        {
            var html = new StringBuilder();

            switch (model.RequestName)
            {
                case GlobalConstants.Workshop: this.ToWorkshop(html, model);
                    break;
                case GlobalConstants.CarWash:
                    this.ToCarWash(html, model);
                    break;
            }

            await this.emailSender.SendEmailAsync(this.email, GlobalConstants.SystemName, model.Receiver, model.Subject, html.ToString());
        }

        private void ToCarWash(StringBuilder html, EmailViewModel model)
        {
            return;
        }

        private void ToWorkshop(StringBuilder html, EmailViewModel model)
        {
            var request = this.workshopService.GetWorkshopRequestDetails(string.Empty, model.Id, true);
            var user = this.usersService.GetUser(request.UserId);
            var workshopServices = this.workshopService.GetWorkshopServicesByRequestId(request.Id);

            this.AppendHeader(html, $"{model.RequestName} - {request.Workshop.Name}");
            this.AppendUser(html, request.UserId);
            this.AppendUl(html, "Car", request.Car.Brand, request.Car.Model, request.Car.RegistrationPlate);
            this.AppendPickUp(html, request);
            var services = workshopServices.Select(x => $"Name: {x.ServiceName}").ToList();
            services.Add($"Other services: {request.OtherServices}");
            this.AppendUl(html, "Services", services.ToArray());
            this.AppendMessage(html, model.Message);
            this.AppendFooter(html);
        }

        private void AppendHeader(StringBuilder html, string header)
        {
            html.AppendLine($"<h2>{header}</h2>");
            html.AppendLine($"<br>");
        }

        private void AppendUser(StringBuilder html, string userId)
        {
            var user = this.usersService.GetUser(userId);
            var userParams = new string[]
            {
                $"First name: {user.FirstName}",
                $"Middle name: {user.MiddleName}",
                $"Sur name: {user.SurName}",
                $"Phone number: {user.PhoneNumber}",
            };

            this.AppendUl(html, "User", userParams);
        }

        private void AppendPickUp(StringBuilder html, PickUpViewModel pickUp)
        {
            var pickUpParams = new string[]
            {
                $"Location: {pickUp.PickUpLocation}",
                $"Time: {pickUp.PickUpTime.ToString() ?? "fast as possible"}",
            };

            this.AppendUl(html, "Pick up", pickUpParams);
        }

        private void AppendUl(StringBuilder html, string ul, params string[] lis)
        {
            html.AppendLine($"<ul>{ul}");
            foreach (var li in lis)
            {
                this.AppendLi(html, li);
            }

            html.AppendLine($"</ul>");
            html.AppendLine($"<br>");
        }

        private void AppendLi(StringBuilder html, string li)
        {
            html.AppendLine($"<li>{li}</li>");
        }

        private void AppendMessage(StringBuilder html, string message)
        {
            html.AppendLine($"<label>{message}</label");
            html.AppendLine("<br>");
        }

        private void AppendFooter(StringBuilder html)
        {
            html.AppendLine("<br>");
            html.AppendLine("<h3>AutoXen</h3>");
        }
    }
}
