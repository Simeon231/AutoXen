﻿namespace AutoXen.Web.Areas.Administration.Controllers
{
    using System;
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

        public IActionResult Index(FilterViewModel model)
        {
            if (model.PageNumber <= 0)
            {
                model.PageNumber = 1;
            }

            var wash = model.CarWashes;
            model = this.requestsService.GetAllRequests(model.PageNumber);
            model.CarWashes = wash;

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
