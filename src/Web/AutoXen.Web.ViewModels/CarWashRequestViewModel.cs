namespace AutoXen.Web.ViewModels
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using AutoXen.Data.Models.CarWash;
    using AutoXen.Services.Mapping;

    public class CarWashRequestViewModel : IMapFrom<CarWashRequest>
    {
        public string CarId { get; set; }

        public string UserId { get; set; }

        public string CarWashId { get; set; }

        [Required]
        [Display(Name = "Pick up location")]
        [StringLength(150, MinimumLength = 3)]
        public string PickUpLocation { get; set; }

        [Display(Name = "Pick up fast as possible")]
        public bool PickUpFastAsPossible { get; set; }

        [Display(Name = "Auto Choose car wash")]
        public bool AdminChooseCarWash { get; set; }

        [Display(Name = "Pick up date")]
        public DateTime? PickUpTime { get; set; }

        // TODO:
        // public IEnumerable<string> Messages { get; set; }
    }
}
