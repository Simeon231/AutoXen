namespace AutoXen.Data.Models.RoadsideAssistance
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class RoadsideAssistanceRequest
    {
        public RoadsideAssistanceRequest()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public string Id { get; set; }

        [Required]
        public string BaseRequestId { get; set; }

        public BaseRequest BaseRequest { get; set; }

        [Required]
        public string Address { get; set; }

        public int RoadsideAssistanceProvinceId { get; set; }

        public RoadsideAssistanceProvince RoadsideAssistanceProvince { get; set; }
    }
}
