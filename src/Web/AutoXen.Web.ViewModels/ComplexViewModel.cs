namespace AutoXen.Web.ViewModels
{
    public class ComplexViewModel<TInputViewModel, TViewModel>
    {
        public TInputViewModel Input { get; set; }

        public TViewModel View { get; set; }
    }
}
