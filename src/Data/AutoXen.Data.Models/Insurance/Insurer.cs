namespace AutoXen.Data.Models.Insurance
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using AutoXen.Data.Common.Models;

    public class Insurer : BaseDeletableModel<int>
    {
        public Insurer()
        {
            this.InsurerInsurances = new HashSet<InsurerInsurances>();
        }

        [Required]
        public string Name { get; set; }

        public ICollection<InsurerInsurances> InsurerInsurances { get; set; }
    }
}
