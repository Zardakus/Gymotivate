using Gymotivate.Data;
using Gymotivate.Helper;
using Gymotivate.Models;
using Gymotivate.Repositorio;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace Gymotivate.Controllers
{
    public class HomeController : Controller
    {
        private readonly BancoContext _context; // Injete o contexto do banco de dados
        private readonly ISessao _sessao;
        private readonly IAcertosRepositorio _acertosRepositorio;

        public HomeController(BancoContext context, 
                              ISessao sessao,
                              IAcertosRepositorio acertosRepositorio)
        {
            _context = context;
            _sessao = sessao;
            _acertosRepositorio = acertosRepositorio;
        }

        public IActionResult Index()
        {
            CadastreModel usuario = _sessao.BuscarSessaoUsuario();
            if (usuario != null)
            {
                // Chame o método para calcular o número total de conquistas habilitadas
                int totalConquistasHabilitadas = CalcularTotalConquistasHabilitadas(usuario.Id);
                int totalAcertos = CalcularTotalAcertos(usuario.Id);

                int totalExp = 0;
                if (totalConquistasHabilitadas >= 1)
                {
                    totalExp = CalcularTotalConquistas();
                }
                    
                // Armazene o número total de conquistas habilitadas em TempData
                ViewData["TotalConquistasHabilitadas"] = totalConquistasHabilitadas;
                ViewData["TotalAcertos"] = totalAcertos;
                ViewData["TotalExp"] = totalExp;
            

                return View();
            }

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        private int CalcularTotalConquistasHabilitadas(int id)
        {
            int totalConquistasHabilitadas = 0;

            totalConquistasHabilitadas = _context.Conquistas
                .Where(c => c.Usuario.Id == id && c.PossuiConquista)
                .Count();

            return totalConquistasHabilitadas;
        }

        private int CalcularTotalAcertos(int id)
        {
            int totalAcertos = 0;

            totalAcertos = _context.Acertos
                .Where(a => a.Usuario.Id == id)
                .Select(a => a.AcertosPeitos + a.AcertosCostas + a.AcertosPernas + a.AcertosBracos)
                .Sum();

            return totalAcertos;
        }

        //private int CalcularTotalExp(int id)
        //{

        //}

        private int CalcularExpGrupo(int acertosGrupo, int userId, int idGrupo)
        {
            int exp = 0;

            for (int tier = 1; tier <= 4; tier++)
            {
                int idConquista = _context.NameConquistas
                    .Where(nc => nc.GrupoConquistas.GroupId == idGrupo && nc.Tier == tier)
                    .Select(nc => nc.NameConquistasId)
                    .FirstOrDefault();

                if (idConquista != 0)
                {
                    ConquistasModel conquista = _context.Conquistas
                        .Where(c => c.Usuario.Id == userId && c.NameConquistas.NameConquistasId == idConquista)
                        .FirstOrDefault();
                    if (conquista.PossuiConquista)
                    {
                        exp += _context.NameConquistas
                            .Where(nc => nc.GrupoConquistas.GroupId == idGrupo && nc.Tier == tier)
                            .Select(nc => nc.ConquistaExp)
                            .FirstOrDefault();
                    }
                }
            }
            return exp;
        }

        private int CalcularTotalConquistas()
        {
            int userId = _sessao.BuscarSessaoUsuario().Id;
            int totalConquistas = 0;

            // Calcule a experiência de cada grupo e adicione ao total
            totalConquistas += CalcularExpGrupo(_acertosRepositorio.ObterAcertosDoUsuario(userId).AcertosPeitos, userId, 1);
            totalConquistas += CalcularExpGrupo(_acertosRepositorio.ObterAcertosDoUsuario(userId).AcertosCostas, userId, 2);
            totalConquistas += CalcularExpGrupo(_acertosRepositorio.ObterAcertosDoUsuario(userId).AcertosPernas, userId, 3);
            totalConquistas += CalcularExpGrupo(_acertosRepositorio.ObterAcertosDoUsuario(userId).AcertosBracos, userId, 4);

            return totalConquistas;
        }
    }
}