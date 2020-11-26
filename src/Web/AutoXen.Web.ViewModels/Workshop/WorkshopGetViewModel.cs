namespace AutoXen.Web.ViewModels.Workshop
{
    using System.Collections.Generic;

    public class WorkshopGetViewModel
    {
        public IEnumerable<CarViewModel> Cars { get; set; }

        public IEnumerable<WorkshopServiceViewModel> WorkshopsServices { get; set; }
    }
}
