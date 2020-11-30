namespace AutoXen.Data.Models.Workshop
{
    using System.ComponentModel.DataAnnotations;

    // TODO change the name to WorkshopWService and change the name of Service to WService
    public class WorkshopService
    {
        public int Id { get; set; }

        public double Price { get; set; }

        public int WorkshopId { get; set; }

        public Workshop Workshop { get; set; }

        public int ServiceId { get; set; }

        public WService Service { get; set; }
    }
}
