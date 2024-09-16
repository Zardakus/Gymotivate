using Gymotivate.Data;
using Gymotivate.Helper;
using Gymotivate.Models;
using Gymotivate.Repositorio;
using Microsoft.AspNetCore.Mvc;

namespace Gymotivate.Controllers
{
    public class ConquistasController : Controller
    {
        private readonly BancoContext _context; // Injete o contexto do banco de dados
        private readonly ICadastreRepositorio _cadastreRepositorio;
        private readonly ISessao _sessao;
        private readonly IAcertosRepositorio _acertosRepositorio;
        List<int> _nameConquistasIdsDoUsuario;

        public ConquistasController(BancoContext context,
                                    ISessao sessao,
                                    ICadastreRepositorio cadastreRepositorio,
                                    IAcertosRepositorio acertosRepositorio)
        {
            _context = context;
            _cadastreRepositorio = cadastreRepositorio;
            _sessao = sessao;
            _acertosRepositorio = acertosRepositorio;
        }

        public IActionResult Conquistas()
        {
            CadastreModel usuario = _sessao.BuscarSessaoUsuario();

            GamesModel acertos = _acertosRepositorio.ObterAcertosDoUsuario(usuario.Id);

            if (acertos == null)
            {
                // Se não existir, crie um novo registro padrão
                acertos = _acertosRepositorio.CriarRegistroPadrao(usuario.Id);
            }

            int conquistasDesbloqueadasPeitos = CalcularConquistasGrupo(acertos.AcertosPeitos, usuario.Id, 1);
            int conquistasDesbloqueadasCostas = CalcularConquistasGrupo(acertos.AcertosCostas, usuario.Id, 2);
            int conquistasDesbloqueadasPernas = CalcularConquistasGrupo(acertos.AcertosPernas, usuario.Id, 3);
            int conquistasDesbloqueadasBracos = CalcularConquistasGrupo(acertos.AcertosBracos, usuario.Id, 4);

            ViewData["ConquistasDesbloqueadasPeitos"] = conquistasDesbloqueadasPeitos;
            ViewData["ConquistasDesbloqueadasCostas"] = conquistasDesbloqueadasCostas;
            ViewData["ConquistasDesbloqueadasPernas"] = conquistasDesbloqueadasPernas;
            ViewData["ConquistasDesbloqueadasBracos"] = conquistasDesbloqueadasBracos;

            int quantidadeExpPeitos = CalcularExpGrupo(acertos.AcertosPeitos, usuario.Id, 1);
            int quantidadeExpCostas = CalcularExpGrupo(acertos.AcertosCostas, usuario.Id, 2);
            int quantidadeExpPernas = CalcularExpGrupo(acertos.AcertosPernas, usuario.Id, 3);
            int quantidadeExpBracos = CalcularExpGrupo(acertos.AcertosBracos, usuario.Id, 4);

            ViewData["QuantidadeExpPeitos"] = quantidadeExpPeitos;
            ViewData["QuantidadeExpCostas"] = quantidadeExpCostas;
            ViewData["QuantidadeExpPernas"] = quantidadeExpPernas;
            ViewData["QuantidadeExpBracos"] = quantidadeExpBracos;

            int totalConquistas = CalcularTotalConquistas();

            ViewData["TotalConquistasHabilitadas"] = totalConquistas;

            _nameConquistasIdsDoUsuario = ObterNameConquistasIdDoUsuarioLogado(usuario.Id);

            ViewData["HabilitaConquistas"] = _nameConquistasIdsDoUsuario;

            return View();
        }

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
        private int CalcularConquistasGrupo(int acertosGrupo, int userId, int idGrupo)
        {
            int conquistasDesbloqueadas = 0;

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
                        conquistasDesbloqueadas++;
                    }

                    if (conquista != null && !conquista.PossuiConquista && acertosGrupo >= 6 * tier)
                    {
                        conquista.PossuiConquista = true;
                        _context.SaveChanges();
                        conquistasDesbloqueadas++;
                    }                   
                }
            }

            return conquistasDesbloqueadas;
        }
        public List<int> ObterNameConquistasIdDoUsuarioLogado(int usuarioId)
        {
            // Consulte o banco de dados para obter os IDs das conquistas do usuário com a coluna PossuiConquistas definida como true.
            List<int> nameConquistasIds = _context.Conquistas
                .Where(c => c.Usuario.Id == usuarioId && c.PossuiConquista == true)
                .Select(c => c.NameConquistas.NameConquistasId)
                .ToList();

            return nameConquistasIds;
        }

        private int CalcularTotalConquistas()
        {
            int totalConquistas = 0;

            // Adicione as conquistas desbloqueadas de cada grupo
            totalConquistas += ViewBag.ConquistasDesbloqueadasPeitos;
            totalConquistas += ViewBag.ConquistasDesbloqueadasCostas;
            totalConquistas += ViewBag.ConquistasDesbloqueadasPernas;
            totalConquistas += ViewBag.ConquistasDesbloqueadasBracos;

            return totalConquistas;
        }
    }
}
