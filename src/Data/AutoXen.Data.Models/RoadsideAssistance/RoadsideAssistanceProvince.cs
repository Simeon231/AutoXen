namespace AutoXen.Data.Models.RoadsideAssistance
{
    using System.ComponentModel.DataAnnotations;

    public class RoadsideAssistanceProvince
    {
        public int Id { get; set; }

        [Required]
        public int RoadsideAssistanceId { get; set; }

        public RoadsideAssistance RoadsideAssistance { get; set; }

        [Required]
        public int ProvicneId { get; set; }

        public Province Province { get; set; }
    }
}
