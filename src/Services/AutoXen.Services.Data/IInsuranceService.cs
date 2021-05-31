namespace AutoXen.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using AutoXen.Data.Models.Insurance;
    using AutoXen.Web.ViewModels.Insurance;

    public interface IInsuranceService
    {
        Task AddInsuranceRequestAsync(InsuranceRequestViewModel model, string userId);

        IEnumerable<InsurerViewModel> GetInsurers();

        IEnumerable<InsurerInsuranceViewModel> GetInsurancesByInsurerId(int id);

        IQueryable<InsuranceRequest> GetAllRequestsByUserId(string userId);

        public InsuranceRequestDetailsViewModel GetInsuranceRequestDetails(string userId, string requestId, bool isAdmin = false);
    }
}
