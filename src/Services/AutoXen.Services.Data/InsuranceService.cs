namespace AutoXen.Services.Data
{
    using System.Collections.Generic;

    using AutoXen.Data.Common.Repositories;
    using AutoXen.Data.Models.Insurance;
    using AutoXen.Web.ViewModels.Insurance;

    // TODO Implement methods
    public class InsuranceService : IInsuranceService
    {
        private readonly IDeletableEntityRepository<InsuranceRequest> insuranceRequestRepository;
        private readonly IRepository<Insurer> insurerRepository;
        private readonly IRepository<Insurance> insuranceRepository;
        private readonly IRepository<InsurerInsurances> insurerInsurancesRepository;

        public InsuranceService(
            IDeletableEntityRepository<InsuranceRequest> insuranceRequestRepository,
            IRepository<Insurer> insurerRepository,
            IRepository<Insurance> insuranceRepository,
            IRepository<InsurerInsurances> insurerInsurancesRepository)
        {
            this.insuranceRequestRepository = insuranceRequestRepository;
            this.insurerRepository = insurerRepository;
            this.insuranceRepository = insuranceRepository;
            this.insurerInsurancesRepository = insurerInsurancesRepository;
        }

        public void AddInsuranceRequestAsync(InsuranceRequestViewModel model)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<InsuranceViewModel> GetInsurance()
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<InsurerViewModel> GetInsurers()
        {
            throw new System.NotImplementedException();
        }
    }
}
