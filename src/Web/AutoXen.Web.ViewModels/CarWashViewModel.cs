namespace AutoXen.Web.ViewModels
{
    using AutoXen.Data.Models.CarWash;
    using AutoXen.Services.Mapping;

    public class CarWashViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public double Price { get; set; }
    }
}
