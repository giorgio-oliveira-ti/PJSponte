using AutoMapper;
using Sponte.App.Dtos;
using Sponte.Sdn;

namespace Sponte.App.Helpers
{
    public class SponteProfile : Profile
    {
        public SponteProfile()
        {
            CreateMap<Instrutor, InstrutorDto>().ReverseMap();
            CreateMap<Live, LiveDto>().ReverseMap();
            CreateMap<Inscrito, InscritoDto>().ReverseMap();
            CreateMap<Inscricao, InscricaoDto>().ReverseMap();
        }
    }
}
