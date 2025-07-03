using AutoMapper;
using Prédio_Comercial.Models;

namespace Prédio_Comercial
{
    public class MappingProfile : Profile
    {
        public MappingProfile() 
        {
            CreateMap<Usuarios, UsuariosDTO>(); // Criação
            CreateMap<UsuariosDTO, Usuarios>(); // Leitura

            CreateMap<Acessos, AcessosGetDTO>()
            .ForMember(dest => dest.NomeUsuario, opt => opt.MapFrom(src => src.Usuarios!.Login))
            .ForMember(dest => dest.NomeVisitante, opt => opt.MapFrom(src => src.Visitante!.Name));
            CreateMap<AcessosGetDTO, Acessos>();


        }
    }
}
