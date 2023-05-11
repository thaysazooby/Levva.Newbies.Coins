using AutoMapper;
using Levva.Newbies.Coins.Domain.Models;
using Levva.Newbies.Coins.Logic.Dtos;

namespace Levva.Newbies.Coins.Logic.MapperProfiles
{
    public class DefaultMapper : Profile
    {
        public DefaultMapper()
        {
            CreateMap<UsuarioDto, Usuario>().ReverseMap();
            CreateMap<TransacaoDto, Transacao>().ReverseMap();
            CreateMap<CategoriaDto, Categoria>().ReverseMap();
        }
    }
}
