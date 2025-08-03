using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Prédio_Comercial.Interface;
using Prédio_Comercial.Models;
using Prédio_Comercial.Service;

namespace Prédio_Comercial.Repository
{
    public class LogerServiceRepository : ILoggerService
    {
        private readonly ILogger<LogerServiceRepository> _logger;
        private readonly ApplicationDbContext _context;
        private readonly ISessionUsuary _ussuary;
        private readonly IMapper _mapper;
        public LogerServiceRepository(ILogger<LogerServiceRepository> logger, ApplicationDbContext applicationDbContext, ISessionUsuary sessionUsuary, IMapper mapper)
        {
            _logger = logger;   
            _context = applicationDbContext;
            _ussuary = sessionUsuary;
            _mapper = mapper;
        }
        public async Task<LogsMensage> MessagemLog(string message)
        {
            var usuario = _ussuary.BuscarSessao();
            var nomeUsuario = usuario.Login;
            _logger.LogInformation($"{message}");
            var Salve = new LogAuditoria
            {
                Menssage = message,
                // CreatedAt = DateTime.Now.Day,
                NomeAtendente = nomeUsuario,
                UsuarioId = usuario.Id
            };
            var LogMap = _mapper.Map<LogsMensage>(Salve);
            await _context.LogsMensage.AddAsync(LogMap);
            await _context.SaveChangesAsync();
            return LogMap;
        }
    }
}
