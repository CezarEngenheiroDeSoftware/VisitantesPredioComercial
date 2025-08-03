using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using Prédio_Comercial.Interface;
using Prédio_Comercial.Models;
using Prédio_Comercial.Models.DTO;
using Prédio_Comercial.Service;
using System.Diagnostics.CodeAnalysis;

namespace Prédio_Comercial.Repository
{
    public class DashBoardDTORepository : IDashBoardDTO
    {
        private ApplicationDbContext _context;
        private IMapper _mapper;
        private ISessionUsuary _sessionUsuary;
        public DashBoardDTORepository(ApplicationDbContext applicationDbContext, IMapper mapper, ISessionUsuary sessionUsuary)
        {
            _context = applicationDbContext;
            _mapper = mapper;
            _sessionUsuary = sessionUsuary;
        }
        public async Task<DashBoardDTO> GetDashBoardDTO()
        {

            var nomesUser = _context.Usuarios.Select(a => a.Login).ToList();
            var nomesPropr = _context.Proprietarios.Select(a => a.Name).ToList();
            var nomesVisitantes = _context.Visitantes.Select(a => a.Name).ToList();
            var dashBoardDTO = new DashBoardDTO
            {
                TotalUsuarios = await _context.Usuarios.Distinct().CountAsync(),
                TotalProprietarios = await _context.Proprietarios.Distinct().CountAsync(),
                TotalVisitantes = await _context.Visitantes.Distinct().CountAsync(),
                TotalOcorrencias = await _context.Ocorrencias.Distinct().CountAsync(),
                TotalAcessos = await _context.Acessos.Distinct().CountAsync(),
                UsuariosLogin = nomesUser.Distinct().ToList(),
                ProprietariosName = nomesPropr.Distinct().ToList(),
                VisitantesName = nomesVisitantes.Distinct().ToList(),
                DataInclusao = DateTime.Now,
            };

            return dashBoardDTO;
        }
        public async Task<DashBoardDTO> GetUserDate(DateTime date)
        {
            //date = date;
            var filterVisity = await _context.Visitantes.Where(a => a.Dataentrada.Date == date.Date).CountAsync();
            var filterUser = await _context.Usuarios.Where(a =>a.DataContratacao == date).CountAsync();
            
            DashBoardDTO dash = await GetDashBoardDTO();
            dash.TotalVisitantes = filterVisity;
            dash.TotalUsuarios = filterUser;
            return dash;

            //new DashBoardDTO
            //{
            //    TotalUsuarios = filter.Count(),
            //    TotalProprietarios = _context.Proprietarios.Distinct().Count(),
            //    TotalAcessos = _context.Acessos.Distinct().Count(),
            //    TotalVisitantes = _context.Visitantes.Distinct().Count(),
            //};
        }
    }

 
   }



