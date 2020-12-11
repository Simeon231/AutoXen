namespace AutoXen.Web.Hubs
{
    using System.Security.Claims;
    using System.Threading.Tasks;

    using AutoXen.Common;
    using AutoXen.Services.Data;
    using AutoXen.Web.ViewModels.Common;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.SignalR;

    [Authorize]
    public class ChatHub : Hub
    {
        private readonly IMessageService messageService;

        public ChatHub(IMessageService messageService)
        {
            this.messageService = messageService;
        }

        public async Task Send(string message, string requestId)
        {
            var isAdmin = this.Context.User.IsInRole(GlobalConstants.AdministratorRoleName);
            var userId = this.Context.User.FindFirstValue(ClaimTypes.NameIdentifier);

            var model = new MessageViewModel()
            {
                IsAdmin = isAdmin,
                Text = message,
                RequestId = requestId,
            };

            // TODO check if the user made this request!
            await this.messageService.AddMessageAsync(model);

            await this.Clients.OthersInGroup(requestId).SendAsync(
                "NewMessage",
                message);
        }

        public async Task JoinGroup(string requestId)
        {
            await this.Groups.AddToGroupAsync(this.Context.ConnectionId, requestId);
        }
    }
}
