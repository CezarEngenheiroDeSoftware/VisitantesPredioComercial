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

        }
    }
}
