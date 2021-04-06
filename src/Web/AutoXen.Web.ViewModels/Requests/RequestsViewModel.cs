namespace AutoXen.Web.ViewModels.Requests
{
    using System.Collections.Generic;

    public class RequestsViewModel : UserFilterViewModel
    {
        public List<RequestViewModel> Requests { get; set; }
    }
}
