﻿namespace AutoXen.Web.ViewModels.Common
{
    using System;
    using System.Collections.Generic;

    public class PagingViewModel
    {
        public int PageNumber { get; set; }

        public bool HasPreviousPage => this.PageNumber > 1;

        public int PreviousPageNumber => this.PageNumber - 1;

        public bool HasNextPage => this.PageNumber < this.PagesCount;

        public int NextPageNumber => this.PageNumber + 1;

        public int PagesCount => (int)Math.Ceiling((double)this.RequestsCount / this.ItemsPerPage);

        public int RequestsCount { get; set; }

        public int ItemsPerPage { get; set; }

        public IDictionary<string, string> Routes { get; set; }
    }
}
