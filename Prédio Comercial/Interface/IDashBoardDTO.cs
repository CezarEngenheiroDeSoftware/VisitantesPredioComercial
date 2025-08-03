using Prédio_Comercial.Models;
using Prédio_Comercial.Models.DTO;

namespace Prédio_Comercial.Interface
{
    public interface IDashBoardDTO
    {
        Task<DashBoardDTO> GetDashBoardDTO();
        Task<DashBoardDTO> GetUserDate(DateTime date);
    }
}
