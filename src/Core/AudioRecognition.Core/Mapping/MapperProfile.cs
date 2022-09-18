using AudioRecognition.Core.Entities;
using AutoMapper;
using Telegram.Bot.Types;

namespace AudioRecognition.Core.Mapping
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<AppUser, Update>().ReverseMap();
            CreateMap<VoiceMessage, Update>().ReverseMap();
        }
    }
}
