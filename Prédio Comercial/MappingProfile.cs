using AutoMapper;
using Prédio_Comercial.Models;
using Prédio_Comercial.Models.DTO;

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

            CreateMap<LogsMensage, LogAuditoria>()
                .ForMember(dest => dest.NomeAtendente, opt => opt.MapFrom(src => src.Usuarios.Login));
            CreateMap<LogAuditoria, LogsMensage>();

            CreateMap<Visitantes, VisitantesDTO>();
            CreateMap<Proprietarios, ProprietariosDTO>();

            CreateMap<DashBoard, DashBoardDTO>()
                .ForMember(dest => dest.UsuariosLogin, opt => opt.MapFrom(src => src.Usuarios.Login))
                .ForMember(dest => dest.VisitantesName, opt => opt.MapFrom(a => a.Visitantes.Name))
                .ForMember(dest => dest.ProprietariosName, opt => opt.MapFrom(c => c.Proprietarios.Name));
        }
    }
}
