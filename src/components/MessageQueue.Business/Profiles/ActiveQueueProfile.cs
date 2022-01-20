using AutoMapper;
using MessageQueue.Domain.InputModels;
using MessageQueue.Domain.Models;
using MessageQueue.Domain.OutputModels;

namespace MessageQueue.Business.Profiles
{
    public class ActiveQueueProfile : Profile
    {
        public ActiveQueueProfile()
        {
            CreateMap<CreateActiveQueueInputModel, ActiveQueue>()
                .ForMember(
                    m => m.Id,
                    opt => opt.MapFrom(_ => Guid.NewGuid()))
                .ForMember(
                    m => m.Name,
                    opt => opt.MapFrom(q => q.Name))
                .ForMember(
                    m => m.DateCreatedUtc,
                    opt => opt.MapFrom(_ => DateTime.UtcNow))
                .ForMember(
                    m => m.Messages,
                    opt => opt.MapFrom(_ => new List<Message>()));

            CreateMap<ActiveQueue, ActiveQueueOutputModel>()
                .ForMember(
                    m => m.Id,
                    opt => opt.MapFrom(q => q.Id))
                .ForMember(
                    m => m.Name,
                    opt => opt.MapFrom(q => q.Name))
                .ForMember(
                    m => m.DateCreatedUtc,
                    opt => opt.MapFrom(q => q.DateCreatedUtc));
        }
    }
}
