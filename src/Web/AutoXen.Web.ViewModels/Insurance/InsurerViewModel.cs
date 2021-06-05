namespace AutoXen.Web.ViewModels.Insurance
{
    using System.ComponentModel.DataAnnotations;

    public class InsurerViewModel
    {
        public int Id { get; set; }

        [Display(Name = "InsurerName")]
        public string Name { get; set; }
    }
}
