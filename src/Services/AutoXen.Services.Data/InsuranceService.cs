namespace AutoXen.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;

    using AutoMapper;
    using AutoXen.Data.Common.Repositories;
    using AutoXen.Data.Models.Insurance;
    using AutoXen.Web.ViewModels.Insurance;
    using Microsoft.EntityFrameworkCore;

    public class InsuranceService : IInsuranceService
    {
        private readonly IDeletableEntityRepository<InsuranceRequest> insuranceRequestRepository;
        private readonly IRepository<Insurer> insurerRepository;
        private readonly IRepository<Insurance> insuranceRepository;
        private readonly IRepository<InsurerInsurances> insurerInsurancesRepository;
        private readonly IMapper mapper;

        public InsuranceService(
            IDeletableEntityRepository<InsuranceRequest> insuranceRequestRepository,
            IRepository<Insurer> insurerRepository,
            IRepository<Insurance> insuranceRepository,
            IRepository<InsurerInsurances> insurerInsurancesRepository,
            IMapper mapper)
        {
            this.insuranceRequestRepository = insuranceRequestRepository;
            this.insurerRepository = insurerRepository;
            this.insuranceRepository = insuranceRepository;
            this.insurerInsurancesRepository = insurerInsurancesRepository;
            this.mapper = mapper;
        }

        // TODO implement
        public void AddInsuranceRequestAsync(InsuranceRequestViewModel model)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<InsurerInsuranceViewModel> GetInsurancesByInsurerId(int id)
        {
            var insurances = this.insurerInsurancesRepository
                .AllAsNoTracking()
                .Include(x => x.Insurance)
                .Where(x => x.InsurerId == id)
                .Select(x => this.mapper.Map<InsurerInsuranceViewModel>(x))
                .AsEnumerable();

            return insurances;
        }

        public IEnumerable<InsurerViewModel> GetInsurers()
        {
            var insurers = this.insurerRepository
                .AllAsNoTracking()
                .Select(x => this.mapper.Map<InsurerViewModel>(x))
                .AsEnumerable();

            return insurers;
        }
    }
}
