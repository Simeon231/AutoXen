namespace AutoXen.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using AutoXen.Web.ViewModels.Insurance;

    public interface IInsuranceService
    {
        Task AddInsuranceRequestAsync(InsuranceRequestViewModel model, string userId);

        IEnumerable<InsurerViewModel> GetInsurers();

        IEnumerable<InsurerInsuranceViewModel> GetInsurancesByInsurerId(int id);
    }
}
