namespace AutoXen.Web.ViewModels.Administration.Dashboard
{
    using System.Collections.Generic;

    public class DashboardViewModel
    {
        public Dictionary<string, int> NotAcceptedRequests { get; set; }

        public Dictionary<string, int> AcceptedUnfinishedRequests { get; set; }
    }
}
