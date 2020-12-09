namespace AutoXen.Web.Infrastructure.Profiles
{
    using AutoMapper;
    using AutoXen.Data.Models;
    using AutoXen.Web.ViewModels.Common;

    public class MessageProfile : Profile
    {
        public MessageProfile()
        {
            this.CreateMap<Message, MessageViewModel>()
                .ReverseMap();
        }
    }
}
