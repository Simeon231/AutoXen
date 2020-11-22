namespace AutoXen.Web.ViewModels
{
    using AutoXen.Data.Models.Car;
    using AutoXen.Services.Mapping;

    public class DetailedCarWithIdViewModel : DetailedCarWithoutIdViewModel, IMapFrom<Car>
    {
        public string Id { get; set; }
    }
}
