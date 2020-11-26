namespace AutoXen.Data.Models.Workshop
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using AutoXen.Data.Common.Models;

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
