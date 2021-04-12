namespace AutoXen.Services.Data
{
    using System.Collections.Generic;

    using AutoXen.Web.ViewModels.Insurance;

    public interface IInsuranceService
    {
        void AddInsuranceRequestAsync(InsuranceRequestViewModel model);

        IEnumerable<InsurerViewModel> GetInsurers();

        IEnumerable<InsuranceViewModel> GetInsurancesByInsurerId(int id);
    }
}
