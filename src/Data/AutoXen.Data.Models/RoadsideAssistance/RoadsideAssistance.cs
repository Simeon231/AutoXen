namespace AutoXen.Data.Models.RoadsideAssistance
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using AutoXen.Data.Common.Models;

    public class RoadsideAssistance : BaseDeletableModel<int>
    {
        public RoadsideAssistance()
        {
            this.RoadsideAssistanceServices = new HashSet<RoadsideAssistanceService>();
        }

        [Required]
        public string Name { get; set; }

        public bool AllowedMoreThan3_5T { get; set; }

        public ICollection<RoadsideAssistanceService> RoadsideAssistanceServices { get; set; }
    }
}
