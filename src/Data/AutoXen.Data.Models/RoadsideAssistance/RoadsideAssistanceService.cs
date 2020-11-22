namespace AutoXen.Data.Models.RoadsideAssistance
{
    public class RoadsideAssistanceService
    {
        public int Id { get; set; }

        public int RoadsideAssistanceId { get; set; }

        public RoadsideAssistance RoadsideAssistance { get; set; }

        public int ServiceId { get; set; }

        public RService Service { get; set; }
    }
}
