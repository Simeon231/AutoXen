namespace AutoXen.Web.ViewModels
{
    using AutoXen.Data.Models.Car;
    using AutoXen.Services.Mapping;

    public class ExtraViewModel : IMapFrom<Extra>
    {
        public string Name { get; set; }

        public int Id { get; set; }
    }
}
