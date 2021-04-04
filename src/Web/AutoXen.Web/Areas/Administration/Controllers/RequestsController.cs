namespace AutoXen.Web.Areas.Administration.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Security.Claims;
    using System.Threading.Tasks;

    using AutoXen.Services.Data;
    using AutoXen.Services.Data.Administration;
    using AutoXen.Web.ViewModels.Administration.Email;
    using AutoXen.Web.ViewModels.Administration.Requests;
    using Microsoft.AspNetCore.Mvc;

    public class RequestsController : AdministrationController
    {
        private readonly IRequestsAdminService requestsService;
        private readonly IWorkshopService workshopService;
        private readonly IEmailService emailService;

        public RequestsController(
            IRequestsAdminService requestsService,
            IWorkshopService workshopService,
            IEmailService emailService)
        {
            this.requestsService = requestsService;
            this.workshopService = workshopService;
            this.emailService = emailService;
        }

        public IActionResult Index(FilterViewModel input)
        {
            if (input.PageNumber <= 0)
            {
                input.PageNumber = 1;
            }

            var model = this.requestsService.GetAllRequests(input.PageNumber);

            model.Routes = new Dictionary<string, string>
            {
                [nameof(model.Accepted)] = input.Accepted.ToString(),
                [nameof(model.AcceptedByMe)] = input.AcceptedByMe.ToString(),
                [nameof(model.RoadsideAssistance)] = input.RoadsideAssistance.ToString(),
                [nameof(model.Insurances)] = input.Insurances.ToString(),
                [nameof(model.AnnualTechnicalInspections)] = input.AnnualTechnicalInspections.ToString(),
                [nameof(model.CarWashes)] = input.CarWashes.ToString(),
                [nameof(model.Workshops)] = input.Workshops.ToString(),
            };

            return this.View(model);
        }

        public async Task<IActionResult> AcceptRequest(AcceptViewModel input)
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            input.AdminId = userId;

            await this.requestsService.AcceptRequestAsync(input);

            return this.RedirectToAction(nameof(this.Index));
        }
    }
}
