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
    using AutoXen.Web.ViewModels.Administration.Insurance;
    using AutoXen.Web.ViewModels.Administration.Requests;
    using AutoXen.Web.ViewModels.Common;
    using AutoXen.Web.ViewModels.Insurance;
    using Microsoft.EntityFrameworkCore;

    public class InsuranceService : IInsuranceService
    {
        private readonly IDeletableEntityRepository<InsuranceRequest> insuranceRequestRepository;
        private readonly IRepository<Insurer> insurerRepository;
        private readonly IRepository<InsurerInsurance> insurerInsurancesRepository;
        private readonly IRepository<InsuranceRequestInsurance> insuranceRequestInsuranceRepository;
        private readonly ICarService carService;
        private readonly IMessageService messageService;
        private readonly IMapper mapper;

        public InsuranceService(
            IDeletableEntityRepository<InsuranceRequest> insuranceRequestRepository,
            IRepository<Insurer> insurerRepository,
            IRepository<InsurerInsurance> insurerInsurancesRepository,
            IRepository<InsuranceRequestInsurance> insuranceRequestInsuranceRepository,
            ICarService carService,
            IMessageService messageService,
            IMapper mapper)
        {
            this.insuranceRequestRepository = insuranceRequestRepository;
            this.insurerRepository = insurerRepository;
            this.insurerInsurancesRepository = insurerInsurancesRepository;
            this.insuranceRequestInsuranceRepository = insuranceRequestInsuranceRepository;
            this.carService = carService;
            this.messageService = messageService;
            this.mapper = mapper;
        }

        public async Task AddInsuranceRequestAsync(InsuranceRequestViewModel model, string userId)
        {
            this.carService.CheckUserHaveACar(userId, model.CarId);

            var dbRequest = this.mapper.Map<InsuranceRequest>(model);
            dbRequest.UserId = userId;

            foreach (var insuranceId in model.InsuranceIds)
            {
                var insuranceRequestInsurance = new InsuranceRequestInsurance()
                {
                    InsuranceRequestId = dbRequest.Id,
                    InsuranceId = insuranceId,
                };

                await this.insuranceRequestInsuranceRepository
                    .AddAsync(insuranceRequestInsurance);
            }

            await this.insuranceRequestRepository.AddAsync(dbRequest);
            await this.insuranceRequestRepository.SaveChangesAsync();
            await this.insuranceRequestInsuranceRepository.SaveChangesAsync();

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
                .Include(x => x.Insurer)
                .ThenInclude(x => x.InsurerInsurances)
                .ThenInclude(x => x.Insurance)
                .Include(x => x.InsuranceRequestsInsurances)
                .FirstOrDefault(x => x.Id == requestId && (x.UserId == userId || isAdmin));

            if (dbRequest == null)
            {
                throw new UnauthorizedRequestAccessException(GlobalConstants.Insurance);
            }

            var request = this.mapper.Map<InsuranceRequestDetailsViewModel>(dbRequest);
            request.Insurer = new InsurerViewModel()
            {
                Name = dbRequest.Insurer.Name,
                Id = dbRequest.Insurer.Id,
            };

            request.Insurances = dbRequest.Insurer.InsurerInsurances
                .Where(x => dbRequest.InsuranceRequestsInsurances.Any(y => y.InsuranceId == x.InsuranceId))
                .Select(x => new InsuranceViewModel()
                {
                    InsuranceId = x.InsuranceId,
                    InsuranceName = x.Insurance.Name,
                    Price = x.Price,
                })
                .ToList();

            request.Messages = this.messageService.GetAllByRequestId(requestId);

            return request;
        }

        public async Task SubmitRequestAsync(AdminInsuranceRequestViewModel model)
        {
            var dbRequest = this.insuranceRequestRepository
                .All()
                .Include(x => x.InsuranceRequestsInsurances)
                .ThenInclude(x => x.Insurance)
                .FirstOrDefault(x => x.Id == model.Id);

            dbRequest.InsuranceEnd = model.InsuranceEnd;
            dbRequest.InsuranceStart = model.InsuranceStart;
            dbRequest.NumberOfPayments = model.NumberOfPayments;
            dbRequest.FinishedOn = model.InsuranceRequestInformation.FinishedOn;
            dbRequest.InsurancesSent = model.InsuranceRequestInformation.InsurancesSent;
            dbRequest.InsurancesReceived = model.InsuranceRequestInformation.InsurancesReceived;

            await this.ChangeInsurerInsurancesAsync(model.Id, model.InsurerId, model.InsurerInsurancesIds);

            await this.insuranceRequestRepository.SaveChangesAsync();
        }

        public IEnumerable<InsuranceViewModel> GetInsurancesByInsurerId(int id)
        {
            var insurances = this.insurerInsurancesRepository
                .AllAsNoTracking()
                .Include(x => x.Insurance)
                .Where(x => x.InsurerId == id)
                .Select(x => this.mapper.Map<InsuranceViewModel>(x))
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

        public IQueryable<InsuranceRequest> GetAllRequests()
        {
            return this.insuranceRequestRepository
                .AllAsNoTracking()
                .Include(x => x.User);
        }

        public async Task AcceptAsync(AcceptViewModel model)
        {
            var request = this.insuranceRequestRepository
                .All()
                .FirstOrDefault(x => x.Id == model.Id);

            request.AcceptedById = model.AdminId;

            await this.insuranceRequestRepository.SaveChangesAsync();
        }

        private async Task ChangeInsurerInsurancesAsync(string requestId, int insurerId, IEnumerable<int> insurerInsurancesIds)
        {
            //var insuranceRequestInsurerInsuranceRepositort = this.insuranceRequestInsurerInsuranceRepository
            //    .All()
            //    .Where(x => x.InsuranceRequestId == requestId);


        }
    }
}
