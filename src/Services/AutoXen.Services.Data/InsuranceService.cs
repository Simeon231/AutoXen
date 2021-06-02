namespace AutoXen.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using AutoMapper;
    using AutoXen.Common;
    using AutoXen.Data.Common.Repositories;
    using AutoXen.Data.Models.Insurance;
    using AutoXen.Services.Exceptions;
    using AutoXen.Web.ViewModels.Common;
    using AutoXen.Web.ViewModels.Insurance;
    using Microsoft.EntityFrameworkCore;

    public class InsuranceService : IInsuranceService
    {
        private readonly IDeletableEntityRepository<InsuranceRequest> insuranceRequestRepository;
        private readonly IRepository<Insurer> insurerRepository;
        private readonly IRepository<Insurance> insuranceRepository;
        private readonly IRepository<InsurerInsurance> insurerInsurancesRepository;
        private readonly IRepository<InsuranceRequestInsurerInsurance> insuranceRequestInsurerInsuranceRepositort;
        private readonly ICarService carService;
        private readonly IMessageService messageService;
        private readonly IMapper mapper;

        public InsuranceService(
            IDeletableEntityRepository<InsuranceRequest> insuranceRequestRepository,
            IRepository<Insurer> insurerRepository,
            IRepository<Insurance> insuranceRepository,
            IRepository<InsurerInsurance> insurerInsurancesRepository,
            IRepository<InsuranceRequestInsurerInsurance> insuranceRequestInsurerInsuranceRepositort,
            ICarService carService,
            IMessageService messageService,
            IMapper mapper)
        {
            this.insuranceRequestRepository = insuranceRequestRepository;
            this.insurerRepository = insurerRepository;
            this.insuranceRepository = insuranceRepository;
            this.insurerInsurancesRepository = insurerInsurancesRepository;
            this.insuranceRequestInsurerInsuranceRepositort = insuranceRequestInsurerInsuranceRepositort;
            this.carService = carService;
            this.messageService = messageService;
            this.mapper = mapper;
        }

        public async Task AddInsuranceRequestAsync(InsuranceRequestViewModel model, string userId)
        {
            this.carService.CheckUserHaveACar(userId, model.CarId);

            var dbRequest = this.mapper.Map<InsuranceRequest>(model);
            dbRequest.UserId = userId;
            await this.insuranceRequestRepository.AddAsync(dbRequest);

            foreach (var insurerInsuranceId in model.InsurerInsuranceIds)
            {
                var insurerInsurances = new InsuranceRequestInsurerInsurance()
                {
                    InsuranceRequestId = dbRequest.Id,
                    InsurerInsuranceId = insurerInsuranceId,
                };
                await this.insuranceRequestInsurerInsuranceRepositort.AddAsync(insurerInsurances);
            }

            await this.insuranceRequestRepository.SaveChangesAsync();
            await this.insuranceRequestInsurerInsuranceRepositort.SaveChangesAsync();

            if (model.Message != null)
            {
                var message = new MessageViewModel()
                {
                    IsAdmin = false,
                    RequestId = dbRequest.Id,
                    Text = model.Message,
                };

                await this.messageService.AddMessageAsync(message);
            }
        }

        public InsuranceRequestDetailsViewModel GetInsuranceRequestDetails(string userId, string requestId, bool isAdmin = false)
        {
            var dbRequest = this.insuranceRequestRepository
                .AllWithDeleted()
                .Include(x => x.Car)
                .Include(x => x.InsuranceRequestsInsurerInsurances)
                .ThenInclude(x => x.InsurerInsurance)
                .FirstOrDefault(x => x.Id == requestId && (x.UserId == userId || isAdmin));

            if (dbRequest == null)
            {
                throw new UnauthorizedRequestAccessException(GlobalConstants.Insurance);
            }

            var insurerInsurances = this.insuranceRequestInsurerInsuranceRepositort
                .AllAsNoTracking()
                .Where(x => x.InsuranceRequestId == dbRequest.Id)
                .Include(x => x.InsurerInsurance)
                .ThenInclude(x => x.Insurance)
                .Include(x => x.InsurerInsurance)
                .ThenInclude(x => x.Insurer)
                .Select(x =>
                new
                {
                    InsuranceName = x.InsurerInsurance.Insurance.Name,
                    InsurerName = x.InsurerInsurance.Insurer.Name,
                    Price = x.InsurerInsurance.Price,
                })
                .ToList();

            var request = this.mapper.Map<InsuranceRequestDetailsViewModel>(dbRequest);
            request.InsurerName = insurerInsurances[0].InsurerName;
            request.InsurerInsurances = insurerInsurances.Select(x => new InsuranceViewModel
            {
                InsuranceName = x.InsuranceName,
                Price = x.Price,
            });

            request.Messages = this.messageService.GetAllByRequestId(requestId);

            return request;
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

        public IQueryable<InsuranceRequest> GetAllRequestsByUserId(string userId)
        {
            return this.insuranceRequestRepository
                .AllWithDeleted()
                .Include(x => x.Car)
                .Where(x => x.UserId == userId);
        }
    }
}
