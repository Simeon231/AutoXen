namespace AutoXen.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using AutoXen.Web.ViewModels.Common;

    public interface IMessageService
    {
        public List<MessageViewModel> GetAllByRequestId(string requestId);

        public Task AddMessageAsync(MessageViewModel model);
    }
}
