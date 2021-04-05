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
                // default values
                input.PageNumber = 1;
                input.Accepted = false;
                input.AcceptedByMe = true;
                input.Workshops = true;
                input.CarWashes = true;
                input.AnnualTechnicalInspections = true;
                input.RoadsideAssistance = true;
                input.Insurances = true;
            }

            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var model = this.requestsService.GetAllRequests(input, userId);

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
