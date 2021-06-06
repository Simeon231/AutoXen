namespace AutoXen.Web.Controllers
{
    using System.Collections.Generic;

    using AutoXen.Services.Data;
    using AutoXen.Web.ViewModels.Insurance;
    using Microsoft.AspNetCore.Mvc;

    [ApiController]
    [Route("api/[controller]")]
    public class InsurerInsuranceController : ControllerBase
    {
        private readonly IInsuranceService insuranceService;

        public InsurerInsuranceController(IInsuranceService insuranceService)
        {
            this.insuranceService = insuranceService;
        }

        [HttpGet("{id}")]
        public IEnumerable<InsuranceViewModel> Get(int id)
        {
            return this.insuranceService.GetInsurancesByInsurerId(id);
        }
    }
}
