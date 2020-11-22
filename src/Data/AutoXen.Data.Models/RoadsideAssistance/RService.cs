namespace AutoXen.Data.Models.RoadsideAssistance
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using AutoXen.Data.Common.Models;

    public class RService : BaseModel<int>
    {
        [Required]
        public string Name { get; set; }

        public ICollection<RoadsideAssistanceService> RoadsideAssistanceServices { get; set; }
    }
}
