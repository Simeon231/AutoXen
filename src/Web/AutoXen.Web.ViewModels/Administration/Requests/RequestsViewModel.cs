namespace AutoXen.Web.ViewModels.Administration.Requests
{
    using System.Collections.Generic;

    using AutoXen.Web.ViewModels.Common;

    public class RequestsViewModel : PagingViewModel
    {
        public RequestsViewModel()
        {
            this.Requests = new List<RequestViewModel>();
        }

        public List<RequestViewModel> Requests { get; set; }
    }
}
