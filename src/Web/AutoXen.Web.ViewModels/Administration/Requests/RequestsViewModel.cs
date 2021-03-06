﻿namespace AutoXen.Web.ViewModels.Administration.Requests
{
    using System.Collections.Generic;

    public class RequestsViewModel : AdminFilterViewModel
    {
        public RequestsViewModel()
        {
            this.Requests = new List<RequestViewModel>();
        }

        public List<RequestViewModel> Requests { get; set; }
    }
}
