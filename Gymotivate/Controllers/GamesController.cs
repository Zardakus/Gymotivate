using Gymotivate.Data;
using Gymotivate.Helper;
using Gymotivate.Models;
using Gymotivate.Repositorio;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace Gymotivate.Controllers
{
    public class GamesController : Controller
    {
        private readonly IGamesService _gamesService;
        private readonly ISessao _sessao;
        private readonly ICadastreRepositorio _cadastreoRepositorio;
        private readonly IAcertosRepositorio _acertosRepositorio;

        public GamesController(IGamesService gamesService,
                               ISessao sessao,
                               ICadastreRepositorio cadastreoRepositorio,
                               IAcertosRepositorio acertosRepositorio)
        {
            _gamesService = gamesService;
            _sessao = sessao;
            _cadastreoRepositorio = cadastreoRepositorio;
            _acertosRepositorio = acertosRepositorio;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Perguntas(string botao)
        {
            ViewBag.BotaoClicado = botao;

            CadastreModel usuario = _sessao.BuscarSessaoUsuario();

            // Verifique se o usuário já possui um registro de acertos
            GamesModel acertos = _acertosRepositorio.ObterAcertosDoUsuario(usuario.Id);           

            if (acertos == null)
            {
                // Se não existir, crie um novo registro padrão
                acertos = _acertosRepositorio.CriarRegistroPadrao(usuario.Id);
            }

            return View(usuario);
        }

        [HttpPost]
        public IActionResult AtualizarAcertos(string grupoPerguntas, int acertos)
        {
            CadastreModel usuario = _sessao.BuscarSessaoUsuario();

            var user = _cadastreoRepositorio.BuscarPorId(usuario.Id);

            if (user != null)
            {
                _gamesService.AtualizarAcertos(user, grupoPerguntas, acertos);
            }

            return RedirectToAction("Index", "Games");
        }
    }
}
