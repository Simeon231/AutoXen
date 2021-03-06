﻿namespace AutoXen.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using AutoXen.Data.Models.Insurance;
    using AutoXen.Web.ViewModels.Administration.Insurance;
    using AutoXen.Web.ViewModels.Administration.Requests;
    using AutoXen.Web.ViewModels.Insurance;

    public interface IInsuranceService
    {
        Task AddInsuranceRequestAsync(InsuranceRequestViewModel model, string userId, bool isAdmin);

        IEnumerable<InsurerViewModel> GetInsurers();

        IEnumerable<InsuranceViewModel> GetInsurancesByInsurerId(int id);

        IQueryable<InsuranceRequest> GetAllRequestsByUserId(string userId);

        public InsuranceRequestDetailsViewModel GetInsuranceRequestDetails(string userId, string requestId, bool isAdmin = false);

        public IQueryable<InsuranceRequest> GetAllRequests();

        public Task AcceptAsync(AcceptViewModel model);

        public Task SubmitRequestAsync(AdminInsuranceRequestViewModel model);
    }
}
