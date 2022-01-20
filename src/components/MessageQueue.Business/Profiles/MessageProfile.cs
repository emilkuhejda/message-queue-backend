using AutoMapper;
using MessageQueue.Domain.InputModels;
using MessageQueue.Domain.Models;

namespace MessageQueue.Business.Profiles
{
    public class MessageProfile : Profile
    {
        public MessageProfile()
        {
            CreateMap<CreateMessageInputModel, Message>()
                .ForMember(
                    m => m.Id,
                    opt => opt.MapFrom(_ => Guid.NewGuid()))
                .ForMember(
                    m => m.ActiveQueueId,
                    opt => opt.Ignore())
                .ForMember(
                    m => m.Body,
                    opt => opt.MapFrom(c => c.Body))
                .ForMember(
                    m => m.DateExpiredInUtc,
                    opt => opt.MapFrom(c => c.DateExpiredInUtc))
                .ForMember(
                    m => m.DateProcessedUtc,
                    opt => opt.Ignore());
        }
    }
}
