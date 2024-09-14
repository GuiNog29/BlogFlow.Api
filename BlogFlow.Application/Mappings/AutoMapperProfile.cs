using AutoMapper;
using BlogFlow.Domain.Entities;
using BlogFlow.Application.Dtos;

namespace BlogFlow.Application.Mappings
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Usuario, UsuarioDto>().ReverseMap();
            CreateMap<Postagem, PostagemDto>().ReverseMap();
        }
    }
}
