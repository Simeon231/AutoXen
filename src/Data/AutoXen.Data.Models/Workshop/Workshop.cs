namespace AutoXen.Data.Models.Workshop
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using AutoXen.Data.Common.Models;

    public class Workshop : BaseModel<int>
    {
        public Workshop()
        {
            this.WorkshopServices = new HashSet<WorkshopService>();
        }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Address { get; set; }

        public ICollection<WorkshopService> WorkshopServices { get; set; }
    }
}
