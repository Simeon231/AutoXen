namespace AutoXen.Web.ViewModels.Requests
{
    using System.Collections.Generic;

    public class RequestsViewModel : FilterViewModel
    {
        public List<RequestViewModel> Requests { get; set; }
    }
}
