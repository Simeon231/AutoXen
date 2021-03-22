namespace AutoXen.Data.Models.Workshop
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using AutoXen.Data.Common.Models;

    // TODO Change the name of the class. For example: IndependentService
    public class WService : BaseModel<int>
    {
        public WService()
        {
            this.WorkshopServices = new HashSet<WorkshopService>();
        }

        [Required]
        public string Name { get; set; }

        public ICollection<WorkshopService> WorkshopServices { get; set; }
    }
}
