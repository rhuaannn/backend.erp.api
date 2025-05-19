using AutoMapper;
using backend.erp.Application.UsuarioDTO;
using backend.erp.Domain.Model;

namespace backend.erp.Application.Mapping
{
    public class MappingProfileUser : Profile
    {
        public MappingProfileUser()
        {
            CreateMap<ResponseUserDTO, Usuarios>()
                .ConstructUsing(src => new Usuarios
                {
                    Id = src.Id,
                    Nome = src.Nome,
                    Email = src.Email,
                    Situacao = src.Situacao
                });

            CreateMap<ResponseUserDTO, Usuarios>().ReverseMap()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Nome, opt => opt.MapFrom(src => src.Nome))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
                .ForMember(dest => dest.Situacao, opt => opt.MapFrom(src => src.Situacao));
        }

    } 
}