using Prédio_Comercial.Models;

namespace Prédio_Comercial.Interface
{
    public interface ILoggerService
    {
        Task<LogsMensage> MessagemLog(string message);
    }
}
