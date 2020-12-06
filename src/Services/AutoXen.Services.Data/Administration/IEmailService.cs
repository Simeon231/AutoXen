namespace AutoXen.Services.Data.Administration
{
    using System.Threading.Tasks;

    using AutoXen.Web.ViewModels.Administration.Email;

    public interface IEmailService
    {
        public Task SendAsync(EmailViewModel model);
    }
}
