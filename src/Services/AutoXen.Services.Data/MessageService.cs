namespace AutoXen.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using AutoMapper;
    using AutoXen.Data.Common.Repositories;
    using AutoXen.Data.Models;
    using AutoXen.Web.ViewModels.Common;

    public class MessageService : IMessageService
    {
        private readonly IRepository<Message> messageRepository;
        private readonly IMapper mapper;

        public MessageService(
            IRepository<Message> messageRepository,
            IMapper mapper)
        {
            this.messageRepository = messageRepository;
            this.mapper = mapper;
        }

        public async Task AddMessageAsync(MessageViewModel model)
        {
            var message = this.mapper.Map<Message>(model);

            await this.messageRepository.AddAsync(message);

            await this.messageRepository.SaveChangesAsync();
        }

        public List<MessageViewModel> GetAllByRequestId(string requestId)
        {
            return this.messageRepository
                .AllAsNoTracking()
                .Where(x => x.RequestId == requestId)
                .Select(x => this.mapper.Map<MessageViewModel>(x))
                .ToList();
        }
    }
}
